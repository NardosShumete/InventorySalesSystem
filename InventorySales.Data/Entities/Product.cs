using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySales.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int StockQuantity { get; set; }

        public int ReorderLevel { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        
        // Optional: Path to image or base64
        public string? ImageUrl { get; set; }
    }
}
