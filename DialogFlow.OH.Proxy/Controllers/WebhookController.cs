using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Openhab.Clinet;
using Openhab.Clinet.Models;

namespace DialogFlow.OH.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IOpenhabClient _openhabClient;
        private static readonly JsonParser JsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

        public WebhookController(IOpenhabClient openhabClient)
        {
            _openhabClient = openhabClient;
        }

        [HttpGet]
        public async Task<IEnumerable<EnrichedItemDTO>> GetItems()
        {
            return await _openhabClient.GetItemsAsync();
        }

        [HttpPost]
        public async Task<ContentResult> DialogAction()
        {
            var fulfillmentText = "Error: Unkown device or room :(";

            // Parse the body of the request using the Protobuf JSON parser,
            // *not* Json.NET.
            using (var reader = new StreamReader(Request.Body))
            {
                var request = JsonParser.Parse<WebhookRequest>(reader);
                var intent = request.QueryResult.Intent.DisplayName.ToLower();
                var action = request.QueryResult.Action.ToLower();
                var parameters = request.QueryResult.Parameters.Fields.ToDictionary(pair => pair.Key, value => value.Value.StringValue);

                var room = parameters["room"].ToLower();
                var device = parameters["device"].ToLower();
                var all = parameters["all"].ToLower();
                var command = action.Split(".").Last().ToUpper();

                var items = await _openhabClient.GetItemsAsync();


                #region Lights
                if (intent.Contains("light"))
                {
                    var lights = items.Where(i => i.GroupNames.Contains("Light")).ToList();

                    // switch lights
                    if (intent.Contains("switch"))
                        {
                        if (string.IsNullOrEmpty(room) || all=="true")
                        {
                            await _openhabClient.PostItemCommandAsync("Light", command);
                            fulfillmentText = $"All lights switched {command.Humanize(LetterCasing.LowerCase)}";
                        }

                        else
                        {
                            var itemNamePart = $"{room.Dehumanize().ToLower()}_light";
                            var light = lights.FirstOrDefault(i => i.Name.ToLower().Contains(itemNamePart));

                            if (light != null)
                            {
                                await _openhabClient.PostItemCommandAsync(light.Name, command);
                                fulfillmentText = $"Switched {command.Humanize(LetterCasing.LowerCase)}";
                            }
                        }
                    }

                    // dimmer Lights
                    if (intent.Contains("brightness"))
                    {
                        var values = request.QueryResult.Parameters.Fields.ToDictionary(pair => pair.Key, v => v.Value.NumberValue);
                        var changeValue = values.ContainsKey("change-value") ? values["change-value"] : 0;
                        var finalValue = values["final-value"];
                        var value = Math.Abs(finalValue) < 0 ? changeValue : finalValue;

                        if (command == "SET")
                        {
                            if (string.IsNullOrEmpty(room) || all == "true")
                            {
                                var dimmableLights = items.Where(i => i.Type == "Dimmer" && !i.Name.ToLower().Contains("hue"));
                                foreach (var dimmableLight in dimmableLights)
                                {
                                    await _openhabClient.PostItemCommandAsync(dimmableLight.Name, value.ToString(CultureInfo.InvariantCulture));
                                    fulfillmentText = $"All lights brightness set on {value}";
                                }
                            }

                            else
                            {
                                var itemNamePart = $"{room.Dehumanize().ToLower()}_light";
                                var light = lights.FirstOrDefault(i => i.Name.ToLower().Contains(itemNamePart));

                                if (light != null && light.Type == "Dimmer")
                                {
                                    await _openhabClient.PostItemCommandAsync(light.Name, value.ToString(CultureInfo.InvariantCulture));
                                    fulfillmentText = $"Brightness set on {value}";
                                }
                            }
                        }
                    }
                }

                #endregion

                #region devices
                //if (intent.Contains("device.switch"))
                //{
                //    if (parameters.All(pair => string.IsNullOrEmpty(pair.Value)) || !string.IsNullOrEmpty(all) && string.IsNullOrEmpty(device))
                //    {
                //        var switchableItems = await _openhabClient.GetItemsAsync(tags: "Switch,Switchable");
                //        var lightingItems = await _openhabClient.GetItemsAsync(tags: "Lighting");
                //        var allDevices = switchableItems.Concat(lightingItems).ToList();
                //        if (!string.IsNullOrEmpty(room))
                //        {
                //            var items = allDevices.Where(i => i.GroupNames.Any(s => s.Contains(room, StringComparison.OrdinalIgnoreCase)));
                //            foreach (var item in items)
                //            {
                //                await _openhabClient.PostItemCommandAsync(item.Name, command);
                //            }
                //        }
                //        else
                //        {
                //            foreach (var item in allDevices)
                //            {
                //                await _openhabClient.PostItemCommandAsync(item.Name, command);
                //            }
                //        }
                //    }

                //    if (device == "outlet")
                //    {
                //        var items = (await _openhabClient.GetItemsAsync()).Where(item => item.Category == "poweroutlet_us").ToList();
                //        foreach (var item in items)
                //        {
                //            await _openhabClient.PostItemCommandAsync(item.Name, command);
                //        }

                //        if (!string.IsNullOrEmpty(room))
                //        {
                //            var item = items.FirstOrDefault(i => i.GroupNames.Any(s => s.Contains(room, StringComparison.OrdinalIgnoreCase)));
                //            await _openhabClient.PostItemCommandAsync(item?.Name, command);
                //        }
                //    }
                //}
                #endregion
            }

            // Populate the response
            var response = new WebhookResponse
            {
                FulfillmentText = fulfillmentText
            };

            // Ask Protobuf to format the JSON to return.
            // Again, we don't want to use Json.NET - it doesn't know how to handle Struct
            // values etc.
            var responseJson = response.ToString();
            return Content(responseJson, "application/json");
        }
    }
}