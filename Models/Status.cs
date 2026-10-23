using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("STATUSES")]
public class Status
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
}
