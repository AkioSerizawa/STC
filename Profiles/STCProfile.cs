using AutoMapper;
using STC.Models;
using STC.View.ProfessionalViewModel;
using STC.View.TypeConsultationViewModel;

namespace STC.Profiles
{
    public class STCProfile : Profile
    {
        public STCProfile()
        {
            CreateMap<TypeConsultation, CreateTypeConsultationViewModel>();
            // CreateMap<Professional, ProfessionalViewModel>().ReverseMap();
        }
    }
}