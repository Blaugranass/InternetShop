using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Queries;

public record class GetProductByIdQuery(Guid Id) : IRequest<Product>;