

namespace Application.Products.Queries;
public sealed record GetProductByIdQuery(int CategoryId, int ProductId, bool TrackChanges) : IRequest<ProductDto>;

