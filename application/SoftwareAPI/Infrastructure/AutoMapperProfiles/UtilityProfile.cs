namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    using AutoMapper;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Utility;
    using System.Collections.Generic;
    using System.Linq;

    public class UtilityProfile : Profile
    {
        public UtilityProfile()
        {
            this.CreateMap<Utility, GetUtilityDTO>()
                   .ForMember(utdto => utdto.Publisher, u => u.MapFrom(utility => utility.Publisher))
                   .ForMember(utdto => utdto.TypeName, u => u.MapFrom(utility => utility.Type.Name));
            this.CreateMap<IEnumerable<Utility>, GetAllUtilitiesDTO>()
                .ForMember(utdto => utdto.Utilities, u => u.MapFrom(utilities => utilities))
                .ForMember(utdto => utdto.UtilitiesCount, u => u.MapFrom(utilities => utilities.Count()));
            this.CreateMap<PatchUtilityDTO, Utility>()
                .ForMember(utility => utility.TypeId, u => u.MapFrom(pudto => pudto.TypeId));
            this.CreateMap<PostUtilityDTO, Utility>();
            this.CreateMap<PutUtilityDTO, Utility>();
        }
    }
}
