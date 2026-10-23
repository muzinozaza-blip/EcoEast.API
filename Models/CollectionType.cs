using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcoEast.API.Models;

[Table("COLLECTION_TYPES")]
public class CollectionType
{
    [Key]
    public int CollectionId { get; set; }
    public string CollectionName { get; set; } = string.Empty;
    public string? CollectionDescription { get; set; }
}
