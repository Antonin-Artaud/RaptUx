using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RaptUx.Entities.ChallengeEntities;
using RaptUx.Entities.ProjectEntities;
using RaptUx.Permissions.Challenges;
using RaptUx.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Challenges;

public class ChallengeAppService
    : CrudAppService<
        ChallengeEntity, 
        ChallengeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateChallengeDto
    >, IChallengeAppService
{
    private IRepository<ChallengeEntity, Guid> ChallengeRepository { get; set; }
    private ILogger<ChallengeAppService> _logger { get; set; }
    public ChallengeAppService(IRepository<ChallengeEntity, Guid> repository, ILogger<ChallengeAppService> logger) : base(repository)
    {
        CreatePolicyName = ChallengePermission.Challenges.Create;
        UpdatePolicyName = ChallengePermission.Challenges.Edit;
        DeletePolicyName = ChallengePermission.Challenges.Delete;

        ChallengeRepository = repository;
        _logger = logger;
    }

    public async Task<ChallengeDto?> GetMonthlyChallengeAsync()
    {
        ChallengeEntity? challenge = await ChallengeRepository.FindAsync(challenge =>
            challenge.AvailabilityDate.Month == DateTime.Now.AddMonths(1).Month);

        return ObjectMapper.Map<ChallengeEntity?, ChallengeDto?>(challenge);
    }

    public async Task AddProject(Guid challengeId, ProjectDto project)
    {
        try
        {
            ChallengeEntity? challenge = await ChallengeRepository.FindAsync(challenge => challenge.Id == challengeId);

            project.OwnerId = (Guid) CurrentUser.Id;
            
            ProjectEntity? projectEntity = ObjectMapper.Map<ProjectDto?, ProjectEntity?>(project);
        
            challenge.Projects.Add(projectEntity);

            await ChallengeRepository.UpdateAsync(challenge);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error during AddProject in ChallengeAppService : {e.Message}");
            throw;
        }
        
    }
}