using AutoMapper;
using PocketPharmacy.Controllers.Resources;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain models to API Resource

            CreateMap<Dosage, DosageResource>();
            CreateMap<Medicine, MedicineResource>();
            CreateMap<User, UserResource>();

            // API Resource to Domain model

            CreateMap<UserResource, User>();
        }
    }
}
