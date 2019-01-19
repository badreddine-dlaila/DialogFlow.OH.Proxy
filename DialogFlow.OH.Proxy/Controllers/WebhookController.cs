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
        [Route("devices")]
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
                var parameters =
                    request.QueryResult.Parameters.Fields.ToDictionary(pair => pair.Key,
                        value => value.Value.StringValue);

                var room = parameters["room"].ToLower();
                var device = parameters["device"].ToLower();
                var all = dict.ContainsKey("all") ? parameters["all"].ToLower() : "";
                var command = action.Split(".").Last().ToUpper();

                var items = await _openhabClient.GetItemsAsync();


                #region Lights
                if (intent.Contains("light"))
                {
                    var lights = items.Where(i => i.GroupNames.Contains("Light")).ToList();

                    // switch lights
                    if (intent.Contains("switch"))
                    {
                        if (string.IsNullOrEmpty(room) || all == "true" || room.ToLower().Equals("all"))
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
                        var dimmerValues =
                            request.QueryResult.Parameters.Fields.ToDictionary(pair => pair.Key,
                                v => v.Value.NumberValue);
                        var dimmerChangeValue =
                            dimmerValues.ContainsKey("change-value") ? dimmerValues["change-value"] : 0;
                        var dimmerFinalValue = dimmerValues["final-value"];
                        var dimmerValue = Math.Abs(dimmerFinalValue) < 0 ? dimmerChangeValue : dimmerFinalValue;

                        if (command != "SET")
                        {
                            fulfillmentText = $"Only SET operation is supported ( check your action name ;) )";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(room) || all == "true" || room.ToLower().Equals("all"))
                            {
                                var dimmableLights = items.Where(i =>
                                    i.Type == "Dimmer" && !i.Name.ToLower().Contains("hue"));
                                foreach (var dimmableLight in dimmableLights)
                                {
                                    await _openhabClient.PostItemCommandAsync(dimmableLight.Name,
                                        dimmerValue.ToString(CultureInfo.InvariantCulture));
                                    fulfillmentText = $"All lights brightness set on {dimmerValue}";
                                }
                            }

                            else
                            {
                                var itemNamePart = $"{room.Dehumanize().ToLower()}_light";
                                var light = lights.FirstOrDefault(i => i.Name.ToLower().Contains(itemNamePart));

                                if (light != null && light.Type == "Dimmer")
                                {
                                    await _openhabClient.PostItemCommandAsync(light.Name, dimmerValue.ToString(CultureInfo.InvariantCulture));
                                    fulfillmentText = $"Brightness set on {dimmerValue}";
                                }
                            }
                        }
                    }
                }
                #endregion

                #region heating
                if (intent.Contains("heating"))
                {
                    var heatings = items.Where(i => i.GroupNames.Contains("Heating"));
                    var heatingValues = request.QueryResult.Parameters.Fields.ToDictionary(pair => pair.Key, v => v.Value.NumberValue);
                    var heatingValue = heatingValues["final-value"];

                    if (command != "SET")
                    {
                        fulfillmentText = $"Only SET operation is supported ( check your action name ;) )";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(room) || all == "true" || room.ToLower().Equals("all"))
                        {

                            foreach (var heating in heatings)
                            {
                                await _openhabClient.PostItemCommandAsync(heating.Name,
                                    heatingValue.ToString(CultureInfo.InvariantCulture));
                                fulfillmentText = $"All HVAC set on {heatingValue}";
                            }
                        }

                        else
                        {
                            var itemNamePart = $"{room.Dehumanize().ToLower()}_heating";
                            var heating = heatings.FirstOrDefault(i => i.Name.ToLower().Contains(itemNamePart));

                            if (heating != null)
                            {
                                await _openhabClient.PostItemCommandAsync(heating.Name,
                                    heatingValue.ToString(CultureInfo.InvariantCulture));
                                fulfillmentText = $"HVAC set on {heatingValue}";
                            }
                        }

                    }
                }
                #endregion

                #region global controls
                if (intent.Contains("device"))
                {
                    var devices = items.Where(i => i.Name.ToLower().Contains(device.Dehumanize().ToLower()));

                    if (string.IsNullOrEmpty(room))
                    {
                        foreach (var d in devices)
                        {
                            await _openhabClient.PostItemCommandAsync(d.Name, command);
                            fulfillmentText = $"device switched {command}";
                        }
                    }
                    else
                    {
                        var devicesInRoom = devices.Where(i => i.GroupNames.Any(gn=>gn.ToLower().Contains(room.Dehumanize().ToLower())));
                        foreach (var d in devicesInRoom)
                        {
                            await _openhabClient.PostItemCommandAsync(d.Name, command);
                            fulfillmentText = $"device switched {command}";
                        }
                    }
                }
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
