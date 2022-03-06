

namespace Application.Products.Queries;
public sealed record GetProductsForCategoryQuery(int CategoryId, bool TrackChanges) : IRequest<IEnumerable<ProductDto>>;


