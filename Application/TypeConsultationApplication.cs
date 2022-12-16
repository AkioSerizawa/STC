using STC.DTOs.TypeConsultation;
using STC.Models;
using STC.Services;
using STC.View.TypeConsultationViewModel;

namespace STC.Application
{
    public class TypeConsultationApplication
    {
        private TypeConsultationService typeConsultationService = new TypeConsultationService();

        public async Task<TypeConsultation> CreateTypeConsultation(CreateTypeConsultationDTO model)
        {
            try
            {
                var typeConsultation = new TypeConsultation
                {
                    TypeName = model.TypeName,
                    TypePrice = model.TypePrice,
                    TypeActive = model.TypeActive
                };

                await typeConsultationService.CreateTypeConsultation(typeConsultation);
                return typeConsultation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TypeConsultation>> GetTypeConsultations()
        {
            try
            {
                List<TypeConsultation> typeConsultations = await typeConsultationService.GetTypeConsultations();

                return typeConsultations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TypeConsultation> GetTypeById(int typeId)
        {
            var typeConsultation = await typeConsultationService.GetTypeConsultationsById(typeId);

            return typeConsultation;
        }
    }
}