namespace ApiNasaRovers.Cache
{
    public class FileCahce : ICache
    {
        /// <summary>
        /// add data to file cache
        /// </summary>
        /// <param name="name"></param>
        /// <param name="camera"></param>
        /// <param name="date"></param>
        /// <param name="data"></param>
        public void addCache(string name, string camera, string date, string data)
        {
        
            try
            {
                File.WriteAllText(makeCacheFilename(name, camera, date), data);
            }
            catch (Exception ex)
            {
                // log error but lets continue 

            }
        }

        /// <summary>
        /// check cache if file exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="camera"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool checkCache(string name, string camera, string date)
        {
            try
            {
                return File.Exists(makeCacheFilename(name, camera, date));
            }
            catch (Exception)
            {
                // log error but let the user  continue and get live data fix things
                return false;
            }
        }

        /// <summary>
        /// get data from cache file 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="camera"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string getCache(string name, string camera, string date)
        {
           return File.ReadAllText(makeCacheFilename(name, camera,date));
        }

        /// <summary>
        /// make cache file name so we can keep it uniform 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="camera"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string makeCacheFilename(string name, string camera, string date)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"/";
            return path + name + "_" + camera + "_" + date + ".cache";
        }
    }
}
