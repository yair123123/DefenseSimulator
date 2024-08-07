using DefenseSimulator.Models;
using System.ComponentModel.DataAnnotations;

public class Threat
{
    
    public int ThreatId { get; set; }
    public int StateId { get; set; }
    public States? State { get; set; }
    public string Target {  get; set; } 
    public int CityId { get; set; }
    public Cities City { get; set; }
    public DateTime LaunchTime { get; set; }
    public int WeaponId { get; set; }
    public Weapon Weapon { get; set; }
    public ThreadStatus Status { get; set; }
}
