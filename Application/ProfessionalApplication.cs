using STC.DTOs.Professional;
using STC.Models;
using STC.Services;
using STC.View.ProfessionalViewModel;

namespace STC.Application
{
    public class ProfessionalApplication
    {
        private ProfessionalService professionalService = new ProfessionalService();

        public async Task<Professional> CreateProfessionalAsync(CreateProfessionalDTO model)
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

        public async Task<List<Professional>> GetAllProfessionalsAsync()
        {
            List<Professional> professionals = await professionalService.GetAllProfessionals();
            return professionals;
        }

        public async Task<Professional> GetProfessionalByIdAsync(int profId)
        {
            Professional professional = await professionalService.GetProfessionalById(profId);
            return professional;
        }
    }
}