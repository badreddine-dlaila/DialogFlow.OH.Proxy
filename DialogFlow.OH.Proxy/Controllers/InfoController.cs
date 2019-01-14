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
                DialogFlowProjectExtract = "https://1drv.ms/u/s!Apf2dopMaxbdn69ZjebWXIiRcpctLQ"
            };
        }

    }
}
