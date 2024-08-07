using DefenseSimulator.Models;
using System.ComponentModel.DataAnnotations;

public class Weapon
{
    [Key]
    public int WeaponId { get; set; }
    [Required]
    public string Type { get; set; }
    public int Speed { get; set; }
    [Required]
    public string CounterMeasure { get; set; }
}
