using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Openhab.Clinet;

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

        [HttpPost]
        public async Task<ContentResult> DialogAction()
        {
            var fulfillmentText = string.Empty;

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
                var color = parameters["color"].ToLower();
                var all = parameters["all"].ToLower();
                var command = action.Split(".").Last().ToUpper();

                var items = await _openhabClient.GetItemsAsync();


                #region Lights
                // switch

                if (intent.Contains("light"))
                {
                    var lights = items.Where(i => i.GroupNames.Contains("Light")).ToList();

                    if (intent.Contains("switch"))
                    {
                        if (string.IsNullOrEmpty(room) || bool.Parse(all))
                            await _openhabClient.PostItemCommandAsync("Light", command);

                        var itemNamePart = $"{room.Humanize(LetterCasing.Title)}_{"light".Humanize(LetterCasing.Title)}";
                        var light = lights.FirstOrDefault(i => i.Name.Contains(itemNamePart));
                        if (light != null)
                        {
                            await _openhabClient.PostItemCommandAsync(light.Name, command);
                            fulfillmentText = $"{light.Name.Replace("_", string.Empty).Humanize()} switch {command.Humanize(LetterCasing.AllCaps)}";
                        }
                        else
                        {
                            fulfillmentText = "Error: Unkown device or room :(";
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