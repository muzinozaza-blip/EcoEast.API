using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("REPORT_SUBMISSIONS")]
public class ReportSubmission
{
    [Key]
    public int ReportId { get; set; }
    public int ResidentId { get; set; }
    public int WsId { get; set; }
    public int CategoryId { get; set; }
    public int StatusId { get; set; }
    public string? Description { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.Now;
}
