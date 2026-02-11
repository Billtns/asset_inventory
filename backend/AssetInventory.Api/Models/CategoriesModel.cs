using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AssetInventory.Api.Models
{
    [Table("Categories")]
    [Index(nameof(CategoryName), IsUnique = true)]
    public class CategoriesModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string CategoryName { get; set; }  = string.Empty;
        public bool IsDelete { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<AssetsModel> Assets { get; set; } = new List<AssetsModel>();
    }


    public class CategoriesModelDTO
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }  = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
