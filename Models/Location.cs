using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("LOCATIONS")]
public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string StreetName { get; set; } = string.Empty;
    public string? StreetNumber { get; set; }
    public int SuburbId { get; set; }
}
