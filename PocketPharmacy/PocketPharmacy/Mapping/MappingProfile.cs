using AutoMapper;
using PocketPharmacy.Controllers.Resources;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dosage, DosageResource>();
            CreateMap<Medicine, MedicineResource>();
            CreateMap<User, UserResource>();
        }
    }
}
