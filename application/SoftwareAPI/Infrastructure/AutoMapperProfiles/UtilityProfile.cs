using AutoMapper;
using SoftwareAPI.Database.Models.Software;
using SoftwareAPI.DTOs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    public class UtilityProfile : Profile
    {
        public UtilityProfile()
        {
            this.CreateMap<Utility, GetUtilityDTO>()
                   .ForMember(utdto => utdto.Publisher, u => u.MapFrom(utility => utility.Publisher));

            this.CreateMap<IEnumerable<Utility>, GetAllUtilitiesDTO>()
                .ForMember(utdto => utdto.Utilities, u => u.MapFrom(utilities => utilities))
                .ForMember(utdto => utdto.UtilitiesCount, u => u.MapFrom(utilities => utilities.Count()));

            this.CreateMap<PostUtilityDTO, Utility>();
            this.CreateMap<PutUtilityDTO, Utility>();
        }
    }
}
