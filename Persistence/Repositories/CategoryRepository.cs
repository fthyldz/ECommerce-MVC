using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class CategoryRepository(ApplicationDbContext context)
    : GenericRepository<Category, CategoryId>(context), ICategoryRepository
{
}