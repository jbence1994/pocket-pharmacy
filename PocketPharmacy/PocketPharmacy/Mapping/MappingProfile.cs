using AutoMapper;
using PocketPharmacy.Controllers.Resources;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain model to API Resource

            CreateMap<Dosage, DosageResource>();
            CreateMap<Medicine, GetMedicineResource>();
            CreateMap<User, GetUserResource>();

            // API Resource to Domain model

            CreateMap<SaveMedicineResource, Medicine>();
            CreateMap<GetUserResource, User>();
        }
    }
}
