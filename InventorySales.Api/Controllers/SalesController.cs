using AutoMapper;
using InventorySales.Api.DTOs;
using InventorySales.Data;
using InventorySales.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;

        public SalesController(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<SaleDto>> CreateSale(CreateSaleDto createSaleDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var sale = new Sale
                {
                    Date = DateTime.Now,
                    SalesDetails = new List<SalesDetail>()
                };

                decimal totalAmount = 0;

                foreach (var item in createSaleDto.Items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null)
                        return BadRequest($"Product with ID {item.ProductId} not found.");

                    if (product.StockQuantity < item.Quantity)
                        return BadRequest($"Insufficient stock for product {product.Name}. Available: {product.StockQuantity}");

                    // Deduct Stock
                    product.StockQuantity -= item.Quantity;
                    _context.Products.Update(product);

                    var detail = new SalesDetail
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = product.UnitPrice,
                        SubTotal = product.UnitPrice * item.Quantity
                    };
                    
                    sale.SalesDetails.Add(detail);
                    totalAmount += detail.SubTotal;
                }

                sale.TotalAmount = totalAmount + (totalAmount * 0.15m); // Subtotal + Tax
                sale.Tax = totalAmount * 0.15m; // 15% Tax
                sale.UserId = 1; // Default to admin for now, or get from User context

                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, _mapper.Map<SaleDto>(sale));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while processing the sale.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.SalesDetails)
                .ThenInclude(sd => sd.Product)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null) return NotFound();

            return Ok(_mapper.Map<SaleDto>(sale));
        }

        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetSalesReport([FromQuery] DateTime? date, [FromQuery] int? id)
        {
            var query = _context.Sales
                .Include(s => s.SalesDetails)
                .AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(s => s.Id == id.Value);
            }
            else if (date.HasValue)
            {
                // Filter by specific day
                query = query.Where(s => s.Date.Date == date.Value.Date);
            }

            var sales = await query.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SaleDto>>(sales));
        }
    }
}
