using AutoMapper;
using RaptUx.Challenges;
using RaptUx.Courses;
using RaptUx.Entities.ChallengeEntities;
using RaptUx.Entities.CoursesEntities;
using RaptUx.Entities.GradeEntities;
using RaptUx.GradeDtos;

namespace RaptUx;

public class RaptUxApplicationAutoMapperProfile : Profile
{
    public RaptUxApplicationAutoMapperProfile()
    {
        CreateMap<GradeEntity, GradeDto>();
        CreateMap<CreateUpdateGradeDto, GradeEntity>();
        
        CreateMap<CourseEntity, CourseDto>();
        CreateMap<CreateUpdateCourseDto, CourseEntity>();
        
        CreateMap<ChallengeEntity, ChallengeDto>();
        CreateMap<CreateUpdateChallengeDto, ChallengeEntity>();
        
        
    }
}
