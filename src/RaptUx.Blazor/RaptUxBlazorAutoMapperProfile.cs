using AutoMapper;
using RaptUx.GradeDtos;

namespace RaptUx.Blazor;

public class RaptUxBlazorAutoMapperProfile : Profile
{
    public RaptUxBlazorAutoMapperProfile()
    {
        CreateMap<GradeDto, CreateUpdateGradeDto>();
    }
}