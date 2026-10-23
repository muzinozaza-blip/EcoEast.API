using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("FIELD_WORKERS")]
public class FieldWorker
{
    [Key]
    public int WorkerId { get; set; }
    public int WasteSolId { get; set; }
}
