namespace InternetShop.Application.Dtos;

public record class RegisterClientDto
(
    string Mail,
    string PhoneNumber,
    string Password
);