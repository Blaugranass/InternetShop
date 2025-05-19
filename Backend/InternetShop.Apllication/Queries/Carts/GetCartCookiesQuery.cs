using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Queries.Carts;

public class GetCartCookiesQuery() : IRequest<Cart>;