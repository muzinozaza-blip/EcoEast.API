using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("RESIDENTS_WASTE_SOLUTION")]
public class ResidentsWasteSolution
{
    [Key]
    public int RwsId { get; set; }
    public int ResidentId { get; set; }
    public int WasteSolId { get; set; }
    public string? LoyaltyNo { get; set; }
}
