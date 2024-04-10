using RaptUx.Entities.GradeEntities;
using RaptUx.GradeDtos;
using RaptUx.Permissions;
using RaptUx.Permissions.Grades;
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
        GetPolicyName = GradePermission.Grades.Default;
        GetListPolicyName = GradePermission.Grades.Default;
        CreatePolicyName = GradePermission.Grades.Create;
        UpdatePolicyName = GradePermission.Grades.Edit;
        DeletePolicyName = GradePermission.Grades.Delete;
    }
}