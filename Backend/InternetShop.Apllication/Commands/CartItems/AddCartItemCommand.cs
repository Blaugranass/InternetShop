using InternetShop.Application.Dtos;
using MediatR;

namespace InternetShop.Application.Commands.CartItems;

public record class AddCartItemCommand(Guid UserId, AddItemInCartDto AddItemDto) : IRequest;
