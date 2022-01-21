using ApiNasaRovers.Cache;
using ApiNasaRovers.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiNasaRovers.Rovers
{
    /// <summary>
    /// this is what every rover inherits 
    /// </summary>
    public abstract class RoverDataAccess
    {

        public ICache cache { get; set; }
        public ICheckRoverCameras cameraPermission { get; set; }
        public IHTTPRoverGetRequest roverapidata { get; set; }
        public string Name { get; set; }
        public string Camera { get; set; }

        public RoverDataAccess()
        {
            Name = "Curiosity";
            Camera = "FHAZ";
            cache = new FileCahce();
            cameraPermission = new CheckRoverCams();
            roverapidata = new GetApiDataRover();
            cameraPermission.permissions =new List<RoverCameras>();
            cameraPermission.permissions.Add(new RoverCameras() { abbreviation = "FHAZ", camera = "Front Hazard Avoidance Camera", access = new List<string>() { "Curiosity" } });
        }


        public async Task<List<string>> GetImages(string date)
        {
            if (cameraPermission.CheckCamera(Name,Camera))
            {

                List<ApiRoverData> roverdata = new List<ApiRoverData>();

                if (cache.checkCache(Name, Camera, date) == false)
                {
                    string data = await roverapidata.GetData(Name, Camera,date);
                    JObject json = JObject.Parse(data);
                    cache.addCache(Name, Camera, date, data);
                    List<ApiRoverData> newdata = JsonConvert.DeserializeObject<List<ApiRoverData>>(json["photos"].ToString());
                    roverdata.AddRange(newdata);
                }
                else
                {

                    string data = cache.getCache(Name, Camera, date);
                    JObject json = JObject.Parse(data);
                    cache.addCache(Name, Camera, date, data);
                    List<ApiRoverData> newdata = JsonConvert.DeserializeObject<List<ApiRoverData>>(json["photos"].ToString());
                    roverdata.AddRange(newdata);

                }


        
                return roverdata.Select(l => l.img_src).ToList();

            }
            else
            {
                throw new InvalidOperationException("RoverCameraNotSupported");
            }
        }

    }


}
