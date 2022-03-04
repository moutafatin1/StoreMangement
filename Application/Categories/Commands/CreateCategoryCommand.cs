

namespace Application.Categories.Commands;
public sealed record CreateCategoryCommand(CreateCategoryDto category) : IRequest<CategoryDto>;

