using InternetShop.Application.Quaries;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery id, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(id.Id);

        if(product is not null)
        {
            return product;
        }

        throw new NullReferenceException();
    }
}