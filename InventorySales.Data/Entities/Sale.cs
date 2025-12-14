using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySales.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; } // Example field if not calculating on fly

        public int? UserId { get; set; } // Who processed the sale
        public User User { get; set; }

        public ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
