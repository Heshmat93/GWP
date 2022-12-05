namespace CleanArchitecture.Application.Common.Mappings
{
    using AutoMapper;
    using Domain.Dummy;
    using global::Application.Dummies.DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dummy, GetDummyListDto>();
            CreateMap<AddDummyDto, Dummy>();

        }


    }
}