using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("SERVICE_REQUESTS")]
public class ServiceRequest
{
    [Key]
    public int RequestId { get; set; }
    public int ResidentId { get; set; }
    public int WsId { get; set; }
    public int RequestTypeId { get; set; }
    public int StatusId { get; set; }
    public string? Description { get; set; }
    public DateTime? ScheduledDate { get; set; }
}
