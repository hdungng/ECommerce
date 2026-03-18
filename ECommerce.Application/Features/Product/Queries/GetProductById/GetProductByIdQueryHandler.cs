using ECommerce.Application.Abstractions.Messaging;
using ECommerce.Application.Abstractions.Persistence;

namespace ECommerce.Application.Features.Product.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        return product is null
            ? null
            : new ProductDto(product.Id, product.Name, product.Price, product.Stock, product.CategoryId);
    }
}
