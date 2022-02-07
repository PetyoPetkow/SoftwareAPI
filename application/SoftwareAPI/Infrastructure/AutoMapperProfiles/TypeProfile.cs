namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    using AutoMapper;
    using SoftwareAPI.DTOs.Type;
    using System.Collections.Generic;
    using System.Linq;

    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            this.CreateMap<Database.Models.Software.Type, GetTypeDTO>();
            this.CreateMap<IEnumerable<Database.Models.Software.Type>, GetAllTypesDTO>()
                .ForMember(utdto => utdto.Types, u => u.MapFrom(types => types))
                .ForMember(utdto => utdto.TypesCount, u => u.MapFrom(types => types.Count()));
            this.CreateMap<PostTypeDTO, Database.Models.Software.Type>();
            this.CreateMap<PutTypeDTO, Database.Models.Software.Type>();
        }
    }
}
