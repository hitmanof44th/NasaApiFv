using System.Net;

namespace ApiNasaRovers.Data
{
    public class GetApiDataRover : IHTTPRoverGetRequest
    {
   /// <summary>
   /// get rover data from remote source 
   /// </summary>
   /// <param name="rover"></param>
   /// <param name="camera"></param>
   /// <param name="date"></param>
   /// <returns></returns>
   /// <exception cref="InvalidOperationException"></exception>
        public async Task<string> GetData(string rover,string camera,string date)
        {
            string url = "https://api.nasa.gov/mars-photos/api/v1/rovers/" + rover + "/photos?earth_date="+date+"&camera=" + camera + "&api_key=DEMO_KEY";

            #if DEBUG
                        Console.WriteLine("URL:"+url);
            #endif
            string rjson = string.Empty;
            using var client = new HttpClient();
            var result = await client.GetAsync(url);
            var contents = await result.Content.ReadAsStringAsync();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException("FailedGettingRemoteApiData");
            }

            return contents.ToString();
            
        }
    }
}



