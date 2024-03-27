using AutoMapper;
using RaptUx.Entities.GradeEntities;
using RaptUx.GradeDtos;

namespace RaptUx;

public class RaptUxApplicationAutoMapperProfile : Profile
{
    public RaptUxApplicationAutoMapperProfile()
    {
        CreateMap<GradeEntity, GradeDto>();
        CreateMap<CreateUpdateGradeDto, GradeEntity>();
    }
}
