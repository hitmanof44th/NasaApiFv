namespace ApiNasaRovers.Data
{
    public interface IHTTPRoverGetRequest
    {
        public Task<string> GetData(string rover, string camera, string date);

    }
}
