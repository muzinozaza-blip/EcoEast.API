using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("CITIES")]
public class City
{
    [Key]
    public int CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
}
