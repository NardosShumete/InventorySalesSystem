using InventorySales.Api.DTOs;
using InventorySales.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ReportsController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetLowStockRoutes()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.StockQuantity < p.ReorderLevel)
                .ToListAsync();

            // Manual mapping or use Mapper
            // Using manual projection for example or Mapper if available. 
            // I'll assume MappingProfile handles Product -> ProductDto
            // But I need to inject Mapper. Let's do simple projection for speed or use Mapper if injected.
            // I'll stick to Mapper pattern if I injected it. 
            // Wait, I didn't inject Mapper here. I'll construct DTOs manually for this method to vary it up or just inject it.
            // Let's inject Mapper.
            return Ok(products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                StockQuantity = p.StockQuantity,
                ReorderLevel = p.ReorderLevel,
                CategoryName = p.Category.Name,
                UnitPrice = p.UnitPrice
            }));
        }

        [HttpGet("daily-sales")]
        public async Task<ActionResult<decimal>> GetDailySales([FromQuery] DateTime date)
        {
            var total = await _context.Sales
                .Where(s => s.Date.Date == date.Date)
                .SumAsync(s => s.TotalAmount);

            return Ok(total);
        }
        
        [HttpGet("dashboard")]
        public async Task<ActionResult<object>> GetDashboardSummary()
        {
            var today = DateTime.Today;
            
            var dailyTotal = await _context.Sales
                .Where(s => s.Date.Date == today)
                .SumAsync(s => s.TotalAmount);
                
            var lowStockCount = await _context.Products
                .CountAsync(p => p.StockQuantity < p.ReorderLevel);
                
            var productCount = await _context.Products.CountAsync();
            
            return Ok(new 
            {
                DailySales = dailyTotal,
                LowStockCount = lowStockCount,
                TotalProducts = productCount
            });
        }
    }
}
