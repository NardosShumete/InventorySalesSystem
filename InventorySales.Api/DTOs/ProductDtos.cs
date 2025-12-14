using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsLowStock => StockQuantity < ReorderLevel;
    }

    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
