using System.ComponentModel.DataAnnotations;

namespace STC.View.ClientViewModel
{
    public class CreateClienteViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(80, ErrorMessage = "Atingiu o número máximo de caracteres")]
        [MinLength(3, ErrorMessage = "O nome está muito pequeno")]
        public string CliName { get; set; }
        public string CliNameMother { get; set; }
        public string CliNameFather { get; set; }
        public DateTime CliBirthDate { get; set; }
        public string CliAddressStreet { get; set; }
        public string CliAddressNeighborhood { get; set; }
        public string CliAddressFull { get; set; }
        public string CliAddressNumber { get; set; }
        public string CliAddressCity { get; set; }
        public string CliSchool { get; set; }
        public string CliSchoolGrade { get; set; }
        public string CliSchoolCity { get; set; }
        public string CliSchoolState { get; set; }
        public string CliPhoneNumber { get; set; }
        public string CliPhoneCell { get; set; }
        public string CliNote { get; set; }
        
        [Required(ErrorMessage = "Precisa informar se o cliente está ativo ou não")]
        public bool CliActive { get; set; }
    }
}