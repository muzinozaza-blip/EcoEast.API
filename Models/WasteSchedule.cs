using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("WASTE_SCHEDULES")]
public class WasteSchedule
{
    [Key]
    public int ScheduleId { get; set; }
    public int WorkerId { get; set; }
    public int RequestId { get; set; }
    public int CollectionTypeId { get; set; }
    public DateTime CollectionDate { get; set; } = DateTime.Now;
    public TimeSpan CollectionTime { get; set; }
}
