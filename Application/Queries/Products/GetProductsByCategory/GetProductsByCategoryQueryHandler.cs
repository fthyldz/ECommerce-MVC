using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.Products.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler(IUnitOfWork unitOfWork, IRoleStore<Role> roleStore, IMapper mapper)
    : IRequestHandler<GetProductsByCategoryQuery, GetProductsByCategoryQueryResponse>
{
    public async Task<GetProductsByCategoryQueryResponse> Handle(GetProductsByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var products =
            await unitOfWork.Products.GetAllWithCategoryByCategoryIdAsync(request.CategoryId, cancellationToken);
        var role = await roleStore.FindByNameAsync(request.RoleName.ToUpper(), cancellationToken);

        var discounts =
            await unitOfWork.Discounts.GetAllByRoleId(role.Id, cancellationToken);

        var productsDto = mapper.Map<List<ProductCheckableDto>>(products, opt =>
        {
            opt.AfterMap((src, desc) =>
            {
                for (int i = 0; i < desc.Count; i++)
                {
                    var discount = discounts.FirstOrDefault(d => d.ProductId == ProductId.Of(desc[i].Id));
                    if (discount is not null)
                    {
                        desc[i].Price -= (desc[i].Price * discount.Rate) / 100;
                    }
                }
            });
        });
        return new GetProductsByCategoryQueryResponse(productsDto);
    }
}