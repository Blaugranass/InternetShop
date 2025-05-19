using InternetShop.Application.Dtos;
using MediatR;

namespace InternetShop.Application.Commands.Clients;

public record class LoginClientCommand(LoginClientDto Client) : IRequest;
