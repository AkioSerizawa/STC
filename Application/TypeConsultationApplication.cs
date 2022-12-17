using STC.DTOs.TypeConsultation;
using STC.Models;
using STC.Services;

namespace STC.Application
{
    public class TypeConsultationApplication
    {
        #region Properties

        private TypeConsultationService typeConsultationService = new TypeConsultationService();

        #endregion Properties

        #region Methods

        public async Task<TypeConsultation> CreateTypeConsultationAsync(CreateTypeConsultationDTO model)
        {
            var typeConsultation = new TypeConsultation
            {
                TypeName = model.TypeName,
                TypePrice = model.TypePrice,
                TypeActive = model.TypeActive
            };

            var typeCreated = await typeConsultationService.CreateTypeConsultation(typeConsultation);
            return typeCreated;
        }

        public async Task<List<TypeConsultation>> GetTypeConsultationsAsync()
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

        #endregion Methods
    }
}