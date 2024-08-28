using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Categories.DeleteCategory;

public record DeleteCategoryCommand(CategoryId Id) : IRequest<DeleteCategoryCommandResponse>;