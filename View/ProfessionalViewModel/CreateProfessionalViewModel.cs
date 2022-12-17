using System.ComponentModel.DataAnnotations;

namespace STC.View.ProfessionalViewModel
{
    public class CreateProfessionalViewModel
    {

        public string ProfName { get; set; }

        public string ProfCell { get; set; }
        public string ProfJob { get; set; }
        public bool ProfConsultation { get; set; }
        public bool ProfActive { get; set; }
    }
}