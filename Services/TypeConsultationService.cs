using Microsoft.EntityFrameworkCore;
using STC.Data;
using STC.Interfaces;
using STC.Models;

namespace STC.Services
{
    public class TypeConsultationService : ITypeConsultationService
    {
        public async Task<TypeConsultation> CreateTypeConsultation(TypeConsultation model)
        {
            try
            {
                using var context = new DataContext();

                await context.TypeConsultation.AddAsync(model);
                await context.SaveChangesAsync();

                return model;
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
                using var context = new DataContext();

                var typeConsultations = await context.TypeConsultation
                    .AsNoTracking()
                    .ToListAsync();

                return typeConsultations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TypeConsultation> GetTypeConsultationsById(int typeId)
        {
            try
            {
                using var context = new DataContext();

                var type = await context.TypeConsultation
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.TypeId == typeId);

                return type;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}