using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("REPORT_CATEGORIES")]
public class ReportCategory
{
    [Key]
    public int RepCategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
