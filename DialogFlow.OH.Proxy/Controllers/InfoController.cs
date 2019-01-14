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
        public ActionResult<dynamic> Info()
        {
            return new
            {
                Status = "Proxy service up and running",
                Webhook = "https://smarthome-proxy.azurewebsites.net/api/webhook/",
                HomeDashboard = "http://176.130.227.69:8080/basicui/app",
                DialogFlowProjectExtract = "https://1drv.ms/u/s!Apf2dopMaxbdn69ZjebWXIiRcpctLQ",
                invocationExamples = new List<string>()
                    {
                        "turn on all lights",
                        "light on in kitchen",
                        "turn on lights in laundry room",
                        "turn off all lights",

                        "set lights brightness to 25 in master bedroom",
                        "set lights brightness to 25 in living room",
                        "set all lights brightness to 90",

                        "switch siren on",
                        "turn on power outlet in entryway",
                        "turn on air conditioner",
                        "turn on all power outlets",
                        "turn off all power",
                        "turn on all fan",

                        "set heating in the bathroom till 40 degrees",
                        "turn thermostat at 40 % in the living room"
                    }
            };
        }

    }
}
