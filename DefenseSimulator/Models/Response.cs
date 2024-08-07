using DefenseSimulator.Models;
using System.ComponentModel.DataAnnotations;

public class Response
{
    [Key]
    public int ResponseId { get; set; }

    [Required]
    public int ThreatId { get; set; }
    public Threat Threat { get; set; }
    [Required]
    public DateTime? InterceptTime { get; set; }
    public ResponseStatus Status { get; set; }
}
