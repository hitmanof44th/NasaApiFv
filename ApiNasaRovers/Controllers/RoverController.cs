using ApiNasaRovers.Data;
using ApiNasaRovers.Rovers;
using Microsoft.AspNetCore.Mvc;


namespace ApiNasaRovers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        public DefaultRover _rovDataAccess = DataAccessFactory.GetRoverDataAccessObj();


        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                // i wanted to use success return here but the requested return was different
                return await _rovDataAccess.GetLast10Image();
            }
            catch (Exception)
            {
                // log stuff 
                return returnstatus.Failed();
            }
        }


    }
}
