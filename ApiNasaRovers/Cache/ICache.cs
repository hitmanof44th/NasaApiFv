namespace ApiNasaRovers.Cache
{
    public interface ICache
    {

        abstract bool checkCache(string name,string camera,string date);
        abstract void addCache(string name, string camera, string date, string data);
        abstract string getCache(string name, string camera, string date);
        abstract string makeCacheFilename(string name, string camera, string date);
    }
}
