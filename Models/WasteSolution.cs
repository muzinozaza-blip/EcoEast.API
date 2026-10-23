using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("WASTE_SOLUTIONS")]
public class WasteSolution
{
    [Key]
    public int WasteSolId { get; set; }
    public string WasteSolName { get; set; } = string.Empty;
    public string? ContactEmail { get; set; }
    public string? CellphoneNumber { get; set; }
}
