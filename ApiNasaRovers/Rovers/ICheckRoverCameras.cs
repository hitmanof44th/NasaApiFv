namespace ApiNasaRovers.Rovers
{
    public interface ICheckRoverCameras
    {
        List<RoverCameras> permissions { get; set; }
        bool CheckCamera(string Rover,string Cam);
    }
}
