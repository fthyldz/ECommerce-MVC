using Application.Abstractions.Repositories.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions.Repositories;

public interface ICategoryRepository : IGenericRepository<Category, CategoryId>
{
}