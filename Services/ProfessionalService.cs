using Microsoft.EntityFrameworkCore;
using STC.Data;
using STC.Interfaces;
using STC.Models;

namespace STC.Services
{
    public class ProfessionalService : IProfessionalService
    {
        public async Task<Professional> CreateProfessional(Professional model)
        {
            try
            {
                using var context = new DataContext();

                await context.Professional.AddAsync(model);
                await context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Professional> GetProfessionalById(int profId)
        {
            try
            {
                using var context = new DataContext();

                var professional = await context.Professional
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ProfId == profId);

                return professional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Professional>> GetProfessionals()
        {
            try
            {
                using var context = new DataContext();

                List<Professional> professionals = await context.Professional
                    .AsNoTracking()
                    .ToListAsync();

                return professionals;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}