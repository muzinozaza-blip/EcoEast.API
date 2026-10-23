using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("RESIDENT")]
public class Resident
{
    [Key]
    public int ResidentId { get; set; }
}
