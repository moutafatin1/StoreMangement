

namespace Application.Categories.Queries;
public sealed record GetCategoryByIdQuery(int CategoryId, bool TrackChanges) : IRequest<CategoryDto>;
