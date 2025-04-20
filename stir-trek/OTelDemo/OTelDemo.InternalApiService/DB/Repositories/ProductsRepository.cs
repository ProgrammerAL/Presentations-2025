using Microsoft.EntityFrameworkCore;

using OpenTelemetry.Trace;

using OTelDemo.InternalApiService.DB.EFEntities;

namespace OTelDemo.InternalApiService.DB.Repositories;

public interface IProductsRepository
{
    ValueTask CreateProductAsync(string id, string name, int cost, string currencyCountry);
    ValueTask<IReadOnlyCollection<ProductEntity>> AllProductsAsync();
}

public class ProductsRepository : IProductsRepository
{
    private readonly ServiceDbContext _context;
    private readonly Tracer _tracer;

    public ProductsRepository(ServiceDbContext context, Tracer tracer)
    {
        _context = context;
        _tracer = tracer;
    }

    public async ValueTask CreateProductAsync(string id, string name, int cost, string currencyCountry)
    {
        using var span = _tracer.StartSpan("create-product-entity");
        _ = span.SetAttribute("my.product-id", id);

        _ = await _context.Products.AddAsync(new ProductEntity
        {
            CreatedUtc = DateTime.UtcNow,
            Enabled = true,
            Id = id,
            Name = name,
            Cost = cost,
            CurrencyCountry = currencyCountry
        });

        _ = await _context.SaveChangesAsync();
    }

    public async ValueTask<IReadOnlyCollection<ProductEntity>> AllProductsAsync()
    {
        using var span = _tracer.StartSpan("query-all-products");

        //Simulate this taking a long time
        await Task.Delay(3_000);

        var products = await _context.Products.ToListAsync();
        span.SetAttribute("my.product-count", products.Count);

        return products;
    }
}
