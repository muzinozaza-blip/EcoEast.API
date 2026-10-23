using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("REQUEST_TYPES")]
public class RequestType
{
    [Key]
    public int RequestTypeId { get; set; }
    public string RequestName { get; set; } = string.Empty;
}
