using System.ComponentModel.DataAnnotations;

namespace STC.DTOs.Professional
{
    public class UpdateProfessionalDTO
    {
        [Required(ErrorMessage = "O nome do profissional é obrigatório")]
        public int ProfId { get; set; }
        public string ProfName { get; set; }
        public string ProfCell { get; set; }
        public string ProfJob { get; set; }
        public bool ProfConsultation { get; set; }
        public bool ProfActive { get; set; }
    }
}