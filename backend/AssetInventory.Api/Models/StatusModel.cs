using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInventory.Api.Models
{
    [Table("Statuses")]
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string StatusName { get; set; } = string.Empty;

        public bool IsDelete { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<AssetsModel> Assets { get; set; } = new List<AssetsModel>();
    }

    public class StatusModelDTO
    {
        public int StatusId { get; set; }

        [Required]
        public string StatusName { get; set; } = string.Empty;

    }
}
