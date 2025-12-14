using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public List<SalesDetailDto> Details { get; set; }
    }

    public class SalesDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }

    public class CreateSaleDto
    {
        [Required]
        public List<CreateSalesDetailDto> Items { get; set; }
    }

    public class CreateSalesDetailDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
