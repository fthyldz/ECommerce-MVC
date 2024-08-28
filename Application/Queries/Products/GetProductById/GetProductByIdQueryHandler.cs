using Application.Abstractions.Repositories.Common;
using Application.Exceptions;
using Application.Queries.Products.GetProducts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.Products.GetProductById;

public class GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IRoleStore<Role> roleStore, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
{
    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.GetByIdWithCategoryAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException("Product", request.ProductId.Value);
        }

        var role = await roleStore.FindByNameAsync(request.RoleName.ToUpper(), cancellationToken);

        var discount =
            await unitOfWork.Discounts.GetByProductIdAndRoleId(request.ProductId, role.Id, cancellationToken);

        var productDto = mapper.Map<ProductDto>(product, opt =>
        {
            if (discount is not null)
            {
                opt.Items["Price"] = product.Price.Price - (product.Price.Price * discount.Rate) / 100;
            }
        });


        return mapper.Map<GetProductByIdQueryResponse>(productDto);
    }
}