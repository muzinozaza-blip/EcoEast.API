using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("MANAGERS")]
public class Manager
{
    [Key]
    public int ManagerId { get; set; }
    public int WasteSolId { get; set; }
}
