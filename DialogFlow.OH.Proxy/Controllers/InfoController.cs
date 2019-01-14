using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DialogFlow.OH.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        [Route("status")]

        public ActionResult<string> Get()
        {
            return "Proxy service up and running !";
        }

        [HttpGet]
        public ActionResult<dynamic> Info()
        {
            return new
            {
                HomeDashboard = "http://176.130.227.69:8080/basicui/app",
                Webhook = "https://smarthome-proxy.azurewebsites.net/api/webhook/",
                DialogFlowProjectExtract = "https://1drv.ms/u/s!Apf2dopMaxbdn69ZjebWXIiRcpctLQ",
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
                    new { Device = "Light", Command = "0-100", Room = "LivingDining" },
                    new { Device = "Light", Command = "0-100", Room = "MasterBedroom" },
                    new { Device = "Light", Command = "on-off", Room = "Entryway" },
                    new { Device = "Light", Command = "on-off", Room = "Kitchen" },
                    new { Device = "Light", Command = "on-off", Room = "LaundryRoom" },
                    new { Device = "Light", Command = "on-off", Room = "Toilet" },
                    new { Device = "Light", Command = "on-off", Room = "Bathroom" },
                    new { Device = "Light", Command = "on-off", Room = "Bedroom" },

                    new { Device = "Heating", Command = "0-100", Room = "LivingDining" },
                    new { Device = "Heating", Command = "0-1OO", Room = "Bathroom" },

                    new { Device = "Energy", Command = "on-off", Room = "All" },
                }
            };
        }

    }
}
