using System;
using InternetShop.Application.Queries.Carts;
using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Handlers.Carts;

public class GetCartCookiesHandler : IRequestHandler<GetCartQuery, Cart>
{
    public async Task<Cart> Handle(GetCartQuery query, CancellationToken cancellationToken)
    {
        await   Task.Delay(0);
        return new Cart();
    }
}
