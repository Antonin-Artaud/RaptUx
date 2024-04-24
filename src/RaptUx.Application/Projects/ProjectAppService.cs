using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using RaptUx.Entities.ProjectEntities;
using RaptUx.Permissions.Project;
using RaptUx.Managers.ProjectManager;
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
    private ILogger<ProjectAppService> _logger { get; set; }
    public IProjectService ProjectManager { get; set; }

    public ProjectAppService(IRepository<ProjectEntity, Guid> repository, ILogger<ProjectAppService> logger, IProjectService projectManager) : base(repository)
    {
        _logger = logger;
        ProjectManager = projectManager;
        CreatePolicyName = ProjectPermission.Projects.Create;
        UpdatePolicyName = ProjectPermission.Projects.Edit;
        DeletePolicyName = ProjectPermission.Projects.Delete;
    }
    
    public async Task<IEnumerable<ProjectDto>> GetTop3ProjectsAsync()
    {
        var projects = await ProjectManager.GetTop3ProjectsAsync();
        return ObjectMapper.Map<IEnumerable<ProjectEntity>, IEnumerable<ProjectDto>>(projects);
    }

    public async Task<bool> GetUserProjectByChallengeId(Guid challengeId)
    {
        try
        {
            return await Repository.AnyAsync(project =>
                project.OwnerId == CurrentUser.Id && project.ChallengeId == challengeId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }
}