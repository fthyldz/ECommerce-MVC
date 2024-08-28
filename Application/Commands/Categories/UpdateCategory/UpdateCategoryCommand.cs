using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Categories.UpdateCategory;

public record UpdateCategoryCommand(CategoryId Id, string Name) : IRequest<UpdateCategoryCommandResponse>;