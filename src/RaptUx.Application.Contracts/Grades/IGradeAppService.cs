using RaptUx.GradeDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RaptUx.Grades;

public interface IGradeAppService 
    : ICrudAppService<
        GradeDto,
        int, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateGradeDto>
{
    
}