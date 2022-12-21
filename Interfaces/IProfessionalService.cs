using STC.Models;

namespace STC.Interfaces
{
    public interface IProfessionalService
    {
        public Task<Professional> CreateProfessional(Professional model);
        public Task<Professional> UpdateProfessional(Professional model);
        public Task<List<Professional>> GetAllProfessionals();
        public Task<Professional> GetProfessionalById(int profId);
    }
}