using System.Reflection;
using Application.Queries.Categories.GetCategories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(GetCategoriesMappings).Assembly); });
        services.AddValidatorsFromAssembly(typeof(GetCategoriesMappings).Assembly);

        return services;
    }
}