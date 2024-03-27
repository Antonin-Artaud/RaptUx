using RaptUx.Entities.GradeEntities;
using RaptUx.GradeDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Grades;

public class GradeAppService
    : CrudAppService<
        GradeEntity,
        GradeDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateGradeDto>,
        IGradeAppService
{
    public GradeAppService(IRepository<GradeEntity, int> repository) : base(repository)
    {
    }
}