using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RaptUx.Courses;

public interface ICourseAppService
    : ICrudAppService<
        CourseDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCourseDto
    >
{
    
}