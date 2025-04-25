using InternetShop.Domain.Entities;
using MediatR;

namespace InternetShop.Application.Quaries;

public record class GetProductByIdQuery(Guid Id) : IRequest<Product>;