using InternetShop.Application.Dtos;
using MediatR;

namespace InternetShop.Application.Commands.Administrators;

public record class LoginAdministratorCommand(LoginAdminDto LoginAdmin) : IRequest;
