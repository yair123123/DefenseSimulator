using System.ComponentModel.DataAnnotations;

namespace DefenseSimulator.Models
{
    public class CountTil
    {
        public int Id { get; set; }
        public int ElectronicJamming { get; set; }
        public int AntiAirSystem { get; set; }
        public int InterceptorMissile { get; set; }
    }
}
