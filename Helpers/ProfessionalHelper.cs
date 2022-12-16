using STC.Models;
using STC.Services;
using STC.View.ProfessionalViewModel;

namespace STC.Helpers
{
    public class ProfessionalHelper
    {
        private ProfessionalService professionalService = new ProfessionalService();

        public async Task<Professional> CreateProfessionalAsync(CreateProfessionalViewModel model)
        {
            try
            {
                Professional professional = new Professional
                {
                    ProfName = model.ProfName,
                    ProfCell = model.ProfCell,
                    ProfJob = model.ProfJob,
                    ProfConsultation = model.ProfConsultation,
                    ProfActive = model.ProfActive
                };

                await professionalService.CreateProfessional(professional);
                return professional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}