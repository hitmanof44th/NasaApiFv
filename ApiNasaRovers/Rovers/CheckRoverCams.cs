namespace ApiNasaRovers.Rovers
{
    public class CheckRoverCams : ICheckRoverCameras
    {
        public List<RoverCameras> permissions { get; set; }

        public bool CheckCamera(string Rover, string Cam)
        {
            return permissions.Any(k => k.abbreviation == Cam && k.access.Contains(Rover));
        }
    }
}
