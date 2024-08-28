using MediatR;

namespace Application.Commands.Categories.CreateCategory;

public record CreateCategoryCommand(string Name) : IRequest<CreateCategoryCommandResponse>;