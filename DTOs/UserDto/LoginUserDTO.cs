using System.ComponentModel.DataAnnotations;

namespace STC.DTOs.UserDto;

public class LoginUserDTO
{
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail invalido;")]
    public string UserEmail { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string UserPassword { get; set; }
}