using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Product.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal Price,
    int Stock,
    Guid CategoryId) : ICommand<Guid>;
