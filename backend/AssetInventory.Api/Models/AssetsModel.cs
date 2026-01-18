using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInventory.Api.Models
{
    [Table("Assets")]
    public class AssetsModel
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public string AssetName { get; set; } = string.Empty;
        public string? AssetCode { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public int CategoryId { get; set; }
        public CategoriesModel Category { get; set; } = null!;
        public int StatusId { get; set; }
        public StatusModel Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;

    }


    public class AssetsModelDTO
    {
        public int? AssetId { get; set; }

        [Required]
        public string AssetName { get; set; } = string.Empty;

        public string? AssetCode { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }

}
