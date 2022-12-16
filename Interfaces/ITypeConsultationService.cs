using STC.Models;

namespace STC.Interfaces
{
    public interface ITypeConsultationService
    {
        public Task<TypeConsultation> CreateTypeConsultation(TypeConsultation model);
    }
}