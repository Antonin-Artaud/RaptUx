using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RaptUx.Entities.ProjectEntities;
using RaptUx.Permissions.Project;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Projects;

public class ProjectAppService
    : CrudAppService<
        ProjectEntity, 
        ProjectDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProjectDto
    >, IProjectAppService
{
    private IRepository<ProjectEntity, Guid> ProjectRepository { get; set; }
    private ILogger<ProjectAppService> _logger { get; set; }

    public ProjectAppService(IRepository<ProjectEntity, Guid> repository, IRepository<ProjectEntity, Guid> projectRepository, ILogger<ProjectAppService> logger) : base(repository)
    {
        ProjectRepository = projectRepository;
        _logger = logger;
        CreatePolicyName = ProjectPermission.Projects.Create;
        UpdatePolicyName = ProjectPermission.Projects.Edit;
        DeletePolicyName = ProjectPermission.Projects.Delete;
    }

    public async Task<bool> GetUserProjectByChallengeId(Guid challengeId)
    {
        try
        {
            return await ProjectRepository.AnyAsync(project =>
                project.OwnerId == CurrentUser.Id && project.ChallengeId == challengeId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }
}