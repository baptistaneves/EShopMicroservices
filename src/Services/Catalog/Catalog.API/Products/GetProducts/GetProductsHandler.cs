namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? pageNumber = 1, int? pageSize = 10) : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);

public class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.pageNumber ?? 1, query.pageSize ?? 10, cancellationToken);

        return new GetProductResult(products);
    }
}
