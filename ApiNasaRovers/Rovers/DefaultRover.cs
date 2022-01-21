using ApiNasaRovers.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiNasaRovers.Rovers
{

    public class DefaultRover:RoverDataAccess
    {
        /// <summary>
        /// here we extend the normal rover behavior by adding in GetLast10images
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
      public async Task<string> GetLast10Image()
        {
                #if DEBUG
                            Console.WriteLine("Running GetLast10");
                #endif

            if (cameraPermission.CheckCamera(Name, Camera))
            {

                List<ApiRoverData> roverdata = new List<ApiRoverData>();
                DateTime d1 = DateTime.Now;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        int num = -i;
                        string Date = d1.AddDays(num).ToString("yyyy-MM-dd");

                        if (cache.checkCache(Name,Camera,Date)==false)
                        {
                                #if DEBUG
                                Console.WriteLine("No cache getting new data");
                                #endif
                            string data = await roverapidata.GetData(Name, Camera,Date);
                            JObject json = JObject.Parse(data);
                            cache.addCache(Name, Camera, Date,data);
                            List<ApiRoverData> newdata = JsonConvert.DeserializeObject<List<ApiRoverData>>(json["photos"].ToString());
                            roverdata.AddRange(newdata.Take(3));
                        }
                        else
                        {

                                    #if DEBUG
                                    Console.WriteLine("getting cahced data");
                                    #endif
                            string data = cache.getCache(Name, Camera, Date);
                            JObject json = JObject.Parse(data);
                            cache.addCache(Name, Camera, Date, data);
                            List<ApiRoverData> newdata = JsonConvert.DeserializeObject<List<ApiRoverData>>(json["photos"].ToString());
                            roverdata.AddRange(newdata.Take(3));

                        }

                        string finalreturn = JsonConvert.SerializeObject(roverdata.Select(l => l.img_src).ToList());
                        return finalreturn;

                    }
                    catch (Exception ex)
                    {
                        // do some logging
                        return "no results";
                    }
                }


            }
            else
            {

                throw new InvalidOperationException("RoverCameraNotSupported");
     
            }

            // should never get here but lets be sure
            return "no results";
        }
        
    }
}
