using STC.Models;

namespace STC.Interfaces
{
    public interface IProfessionalService
    {
        public Task<Professional> CreateProfessional(Professional model);
        public Task<List<Professional>> GetProfessionals();
        public Task<Professional> GetProfessionalById(int profId);
    }
}