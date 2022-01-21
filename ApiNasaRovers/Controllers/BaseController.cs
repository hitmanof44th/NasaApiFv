using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNasaRovers
{
    [Route("/")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string version = "API_VERSION - "+ Assembly.GetEntryAssembly().GetName().Version.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return version;
        }

    }
}
