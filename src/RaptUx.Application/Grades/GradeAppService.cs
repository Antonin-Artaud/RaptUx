using RaptUx.Entities.GradeEntities;
using RaptUx.GradeDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Grades;

public class GradeAppService(IRepository<GradeEntity, int> repository) : CrudAppService<
        GradeEntity,
        GradeDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateGradeDto>(repository),
    IGradeAppService;