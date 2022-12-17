using System.ComponentModel.DataAnnotations;

namespace STC.DTOs.Professional
{
    public class CreateProfessionalDTO
    {
        [Required(ErrorMessage = "O nome do profissional é obrigatório")]
        [MaxLength(80, ErrorMessage = "")]
        [MinLength(3, ErrorMessage = "O nome está muito pequeno")]
        public string ProfName { get; set; }

        public string ProfCell { get; set; }
        public string ProfJob { get; set; }

        [Required(ErrorMessage = "Precisa definir se esse profissional pode fazer consultas")]
        public bool ProfConsultation { get; set; }

        [Required(ErrorMessage = "Precisa informar se o profissional está ativo")]
        public bool ProfActive { get; set; }
    }
}