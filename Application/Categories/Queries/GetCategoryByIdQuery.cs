

namespace Application.Categories.Queries;
public sealed record GetCategoryByIdQuery(int categoryId, bool trackChanges) : IRequest<CategoryDto>;
