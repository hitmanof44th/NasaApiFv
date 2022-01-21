using ApiNasaRovers.Rovers;

namespace ApiNasaRovers
{
    public class DataAccessFactory
    {
        public static DefaultRover GetRoverDataAccessObj()
        {
            return new DefaultRover();
        }
    }
}
