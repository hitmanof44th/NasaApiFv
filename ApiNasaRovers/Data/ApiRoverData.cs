namespace ApiNasaRovers.Data
{


    public class ApiRoverData
    {
      public int id { get; set; }
      public int sol { get; set; }
      public string? img_src { get; set; }
      public string? earth_date { get; set; }
      public ApiRoverCameraData? camera { get; set; }
      public ApiTheRoverData? rover { get; set; }

}
}
