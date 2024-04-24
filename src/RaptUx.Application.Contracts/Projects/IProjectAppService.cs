using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RaptUx.Projects;

public interface IProjectAppService
    : ICrudAppService<
        ProjectDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProjectDto
    >
{
    Task<bool> GetUserProjectByChallengeId(Guid challengeId);
}