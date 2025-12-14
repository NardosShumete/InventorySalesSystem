using AutoMapper;
using InventorySales.Api.DTOs;
using InventorySales.Data.Entities;
using InventorySales.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<Product> productRepo, IRepository<Category> categoryRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] string search = null)
        {
            var products = await _productRepo.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                products = products.Where(p => 
                    p.Name.ToLower().Contains(search) || 
                    p.Id.ToString() == search
                ).ToList();
            }

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepo.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, _mapper.Map<ProductDto>(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateProductDto updateProductDto)
        {
             var product = await _productRepo.GetByIdAsync(id);
             if (product == null) return NotFound();

             _mapper.Map(updateProductDto, product);
             await _productRepo.UpdateAsync(product);
             return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepo.DeleteAsync(id);
            return NoContent();
        }
        
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpPost("categories")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepo.AddAsync(category);
            return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, _mapper.Map<CategoryDto>(category));
        }
    }
}
