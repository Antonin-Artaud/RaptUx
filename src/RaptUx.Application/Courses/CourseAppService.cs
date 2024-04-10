using System;
using RaptUx.Entities.CoursesEntities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Courses;

public class CourseAppService
    : CrudAppService<
        CourseEntity, 
        CourseDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCourseDto
    >, ICourseAppService
{
    public CourseAppService(IRepository<CourseEntity, Guid> repository) : base(repository)
    {
    }
}