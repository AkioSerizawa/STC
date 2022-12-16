using System.ComponentModel.DataAnnotations;

namespace STC.View.TypeConsultationViewModel
{
    public class CreateTypeConsultationViewModel
    {
        [Required(ErrorMessage = "O nome do tipo de atendimento é obrigatório!")]
        [MaxLength(40, ErrorMessage = "Atingiu o número máximo de caracteres")]
        [MinLength(3, ErrorMessage = "O nome está muito pequeno")]
        public string TypeName { get; set; }

        [Required(ErrorMessage = "O valor do tipo de atendimento é obrigatório!")]
        public decimal TypePrice { get; set; }

        [Required(ErrorMessage = "Precisa informar se o tipo de atendimento está ativo ou não")]
        public bool TypeActive { get; set; }
    }
}