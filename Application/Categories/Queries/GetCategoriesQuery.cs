

namespace Application.Categories.Queries;
public sealed record GetCategoriesQuery(bool trackChanges) : IRequest<IEnumerable<CategoryDto>>;

