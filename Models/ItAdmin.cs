using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("IT_ADMINS")]
public class ItAdmin
{
    [Key]
    public int ItadminId { get; set; }
    public int WasteSolId { get; set; }
}
