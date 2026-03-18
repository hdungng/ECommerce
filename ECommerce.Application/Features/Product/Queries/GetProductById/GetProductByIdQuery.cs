using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Product.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductDto?>;

public sealed record ProductDto(Guid Id, string Name, decimal Price, int Stock, Guid CategoryId);
