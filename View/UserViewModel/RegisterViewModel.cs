using System.ComponentModel.DataAnnotations;

namespace STC.View.UserViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O Nome do Usuário é obrigatório")]
        [MaxLength(80, ErrorMessage = "Atingiu o número máximo de caracteres")]
        [MinLength(3, ErrorMessage = "O nome está muito pequeno")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O E-mail do Usuário é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail Invalido")]
        [MaxLength(220, ErrorMessage = "Atingiu o número máximo de caracteres")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "A Senha do Usuário é obrigatório")]
        [MaxLength(400, ErrorMessage = "Atingiu o número máximo de caracteres")]
        [MinLength(4, ErrorMessage = "A senha é muito pequena")]
        public string UserPassword { get; set; }
    }
}
