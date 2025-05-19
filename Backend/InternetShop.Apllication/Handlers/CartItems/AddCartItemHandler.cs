using System;
using InternetShop.Application.Commands.CartItems;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces;
using MediatR;

namespace InternetShop.Application.Handlers.CartItems;

public class AddCartItemHandler(IAnnouncementRepository announcementRepository, ICartRepository cartRepository) : IRequestHandler<AddCartItemCommand>
{
    public async Task Handle(AddCartItemCommand command, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.GetByIdAsync(
            command.AddItemDto.AnnouncementId,
            cancellationToken)
                ?? throw new NullReferenceException("Not found announcement");


        var cart = await cartRepository.GetToUserAsync(command.UserId, cancellationToken)
                ?? new Cart { UserId = command.UserId };

        cart.AddItem(announcement, command.AddItemDto.Quantity);

        if (cart.Id == Guid.Empty)
            await cartRepository.CreateAsync(cart, cancellationToken);
        else
            await cartRepository.UpdateAsync(cart, cancellationToken);


        
    }
}
