using STC.DTOs.Professional;
using STC.Models;
using STC.Services;
using STC.View.ProfessionalViewModel;

namespace STC.Application
{
    public class ProfessionalApplication
    {
        #region Properties

        private ProfessionalService professionalService = new ProfessionalService();

        #endregion Properties

        #region Methods
        public async Task<ProfessionalViewModel> CreateProfessionalAsync(CreateProfessionalDTO model)
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
                var professionalViewModel = new ProfessionalViewModel
                {
                    ProfId = professional.ProfId,
                    ProfName = professional.ProfName,
                    ProfCell = professional.ProfCell,
                    ProfJob = professional.ProfJob,
                    ProfConsultation = professional.ProfConsultation,
                    ProfActive = professional.ProfActive
                };

                return professionalViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateProfessionalAsync(UpdateProfessionalDTO model)
        {
            Professional professionalValidated = await professionalService.GetProfessionalById(model.ProfId);

            professionalValidated.ProfName = model.ProfName;
            professionalValidated.ProfCell = model.ProfCell;
            professionalValidated.ProfJob = model.ProfJob;
            professionalValidated.ProfConsultation = model.ProfConsultation;
            professionalValidated.ProfActive = model.ProfActive;

            await professionalService.UpdateProfessional(professionalValidated);

            return model.ProfId;
        }

        public async Task<List<ProfessionalViewModel>> GetAllProfessionalsAsync()
        {
            List<Professional> professionals = await professionalService.GetAllProfessionals();

            List<ProfessionalViewModel> professionalViewModel = new List<ProfessionalViewModel>();
            foreach (var item in professionals)
            {
                ProfessionalViewModel model = new ProfessionalViewModel();
                model.ProfId = item.ProfId;
                model.ProfName = item.ProfName;
                model.ProfCell = item.ProfCell;
                model.ProfJob = item.ProfJob;
                model.ProfConsultation = item.ProfConsultation;
                model.ProfActive = item.ProfActive;

                professionalViewModel.Add(model);
            }
            return professionalViewModel;
        }

        public async Task<ProfessionalViewModel> GetProfessionalByIdAsync(int profId)
        {
            Professional professional = await professionalService.GetProfessionalById(profId);
            var professionalView = new ProfessionalViewModel
            {
                ProfId = professional.ProfId,
                ProfName = professional.ProfName,
                ProfCell = professional.ProfCell,
                ProfJob = professional.ProfJob,
                ProfConsultation = professional.ProfConsultation,
                ProfActive = professional.ProfActive
            };
            return professionalView;
        }

        #endregion Methods
    }
}