using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("ITEM_CATEGORIES")]
public class ItemCategory
{
    [Key]
    public int ItemCategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
