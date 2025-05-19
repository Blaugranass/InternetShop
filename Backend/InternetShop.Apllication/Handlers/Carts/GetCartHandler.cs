using System;
using InternetShop.Application.Queries.Carts;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.Carts;

public class GetCartHandler(ICartRepository repository) : IRequestHandler<GetCartQuery, Cart>
{
    public async Task<Cart> Handle(GetCartQuery query, CancellationToken cancellationToken)
    {
        return await repository.GetToUserAsync(query.UserId);
    }

}