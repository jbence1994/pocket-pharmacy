using AutoMapper;
using PocketPharmacy.Controllers.Resources.Dosage;
using PocketPharmacy.Controllers.Resources.Medicine;
using PocketPharmacy.Controllers.Resources.User;
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
            CreateMap<User, AuthenticatedUserResource>();
            CreateMap<User, RegisteredUserResource>();

            // API Resource to Domain model

            CreateMap<DosageResource, Dosage>();
            CreateMap<SaveMedicineResource, Medicine>();
            CreateMap<RegisterOrAuthenticateUserResource, User>();
        }
    }
}
