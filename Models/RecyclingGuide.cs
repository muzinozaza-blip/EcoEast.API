using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("RECYCLING_GUIDES")]
public class RecyclingGuide
{
    [Key]
    public int RecyclingId { get; set; }
    public int ItemCategoryId { get; set; }
    public bool IsRecyclable { get; set; }
    public int ManagerId { get; set; }
    public string? DisposalRule { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.Now;
}
