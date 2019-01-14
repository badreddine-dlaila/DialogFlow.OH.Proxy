using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DialogFlow.OH.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Proxy service up and running !";
        }

        [HttpGet]
        [Route("Info")]
        public ActionResult<dynamic> Info()
        {
            return new
            {
                HomeDashboard = "http://176.130.227.69:8080",
                Webhook = "https://smarthome-proxy.azurewebsites.net/api/webhook/",
                DialogFlowProjectExtract = "",
                Rooms = new List<string>
                {
                    "Entryway",
                    "LivingDining",
                    "Kitchen",
                    "LaundryRoom",
                    "Toilet",
                    "MasterBedroom",
                    "Bedroom",
                    "Bathroom",
                    "Toilet",
                    "Garage"
                },
                SupportedDevices = new List<dynamic>
                {
                    new { Device = "Light", Command = "brightness", Room = "LivingDining" },
                    new { Device = "Light", Command = "brightness", Room = "MasterBedroom" },
                    new { Device = "Light", Command = "0-100", Room = "Entryway" },
                    new { Device = "Light", Command = "0-100", Room = "Kitchen" },
                    new { Device = "Light", Command = "0-100", Room = "LaundryRoom" },
                    new { Device = "Light", Command = "0-100", Room = "Toilet" },
                    new { Device = "Light", Command = "0-100", Room = "Bathroom" },
                    new { Device = "Light", Command = "0-100", Room = "Bedroom" },

                    new { Device = "Heating", Command = "0-100", Room = "LivingDining" },
                    new { Device = "Heating", Command = "0-1OO", Room = "Bathroom" },
                }
            };
        }

    }
}
