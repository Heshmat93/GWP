namespace CleanArchitecture.Application.Common.Mappings
{
    using AutoMapper;
    using CleanArchitecture.Application.Common.Models;
    using Domain.Dummy;
    using global::Application.Dummies.DTO;
    using global::Application.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dummy, GetDummyListDto>();
            CreateMap<AddDummyDto, Dummy>();
            CreateMap<UpdateDummyDto, Dummy>();
            CreateMap<GetDummyDetailsDto, Dummy>();
            CreateMap<Dummy,GetDummyListDto >();
        

        }

    }
}