using Application.Abstractions.Repositories.Common;
using Application.Commands.Products.CreateProduct.DTOs;
using Application.Queries.Products.GetProducts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Products.CreateProduct;

public class CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var product = mapper.Map<Product>(request);
        await unitOfWork.Products.AddAsync(product, cancellationToken);
        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new CreateProductCommandResponse(true);
    }
}