using System;
using System.Threading.Tasks;
using RaptUx.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RaptUx.Challenges;

public interface IChallengeAppService
    : ICrudAppService<
        ChallengeDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateChallengeDto
    >
{
    public Task<ChallengeDto?> GetMonthlyChallengeAsync();
    public Task AddProject(Guid challengeId, ProjectDto project);
}