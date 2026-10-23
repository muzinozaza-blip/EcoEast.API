using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("WASTE_SOLUTIONS_SUBURBS")]
public class WasteSolutionsSuburb
{
    [Key]
    public int WsId { get; set; }
    public int WasteSolId { get; set; }
    public int SuburbId { get; set; }
}
