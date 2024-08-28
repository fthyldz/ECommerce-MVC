using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.Products.GetProducts;

public class GetProductsQueryHandler(IUnitOfWork unitOfWork, IRoleStore<Role> roleStore, IMapper mapper)
    : IRequestHandler<GetProductsQuery, GetProductsQueryResponse>
{
    public async Task<GetProductsQueryResponse> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Products.GetAllWithCategoryAsync(cancellationToken);

        var role = await roleStore.FindByNameAsync(request.RoleName.ToUpper(), cancellationToken);

        var discounts =
            await unitOfWork.Discounts.GetAllByRoleId(role.Id, cancellationToken);

        var productsDto = mapper.Map<List<ProductDto>>(products, opt =>
        {
            opt.AfterMap((src, dest) =>
            {
                for (int i = 0; i < dest.Count; i++)
                {
                    var discount = discounts.FirstOrDefault(d => d.ProductId == ProductId.Of(dest[i].Id));
                    if (discount is not null)
                    {
                        dest[i].Price -= (dest[i].Price * discount.Rate) / 100;
                    }
                }
            });
        });
        return new GetProductsQueryResponse(productsDto);
    }
}