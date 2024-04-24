using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    Task<IEnumerable<ProjectDto>> GetTop3ProjectsAsync();
    Task<bool> GetUserProjectByChallengeId(Guid challengeId);
}