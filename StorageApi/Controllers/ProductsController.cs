using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTOs;
using StorageApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StorageContext _context;
    public ProductsController(StorageContext context)
    {
        _context = context;
    }

    // GET: api/products?category=KategoriNamn&name=Namn
    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetProduct(
        [FromQuery] string category = "",
        [FromQuery] string name = "")
    {
        return await _context.Product.Where(p =>
            (category.Length == 0 || p.Category == category) &&
            (name.Length == 0 || p.Name == name)).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Count = p.Count
            }).ToListAsync();
    }

    // GET: api/products/stats
    [HttpGet("stats")]
    public async Task<ActionResult<ProductStatsDTO>> GetProductStats()
    {
        List<Product> products = await _context.Product.ToListAsync();
        if (products.Count == 0)
        {
            return new ProductStatsDTO
            {
                NumberOfProducts = 0,
                TotalInventoryValue = 0,
                AveragePrice = 0
            };
        }

        return new ProductStatsDTO
        {
            NumberOfProducts = products.Count,
            TotalInventoryValue = products.Sum(p => p.Price * p.Count),
            AveragePrice = Math.Round(products.Average(p => p.Price), 2)
        };
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Count = product.Count
        };
    }

    // PUT: api/products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int? id, CreateProductDTO product)
    {
        if (id == null)
        {
            return BadRequest();
        }

        Product p = new()
        {
            Id = (int)id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            Shelf = product.Shelf,
            Count = product.Count,
            Description = product.Description
        };
        _context.Entry(p).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> PostProduct(CreateProductDTO product)
    {
        Product p = new()
        {
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            Shelf = product.Shelf,
            Count = product.Count,
            Description = product.Description
        };
        _context.Product.Add(p);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = p.Id },
            new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Count = p.Count
            });
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int? id)
    {
        return _context.Product.Any(e => e.Id == id);
    }
}
