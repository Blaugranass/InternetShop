using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Queries.Carts;

public record class GetCartQuery(Guid UserId) : IRequest<Cart>;
