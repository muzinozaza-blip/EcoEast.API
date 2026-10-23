using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("SUBURBS")]
public class Suburb
{
    [Key]
    public int SuburbId { get; set; }
    public string SuburbName { get; set; } = string.Empty;
    public int CityId { get; set; }
}
