using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaptUx.Entities.ProjectEntities;
using RaptUx.Managers.ProjectManager;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Projects;

public class ProjectAppService(IRepository<ProjectEntity, Guid> repository, IProjectService projectManager)
    : CrudAppService<
        ProjectEntity,
        ProjectDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProjectDto
    >(repository), IProjectAppService
{
    public async Task<IEnumerable<ProjectDto>> GetTop3ProjectsAsync()
    {
        var projects = await projectManager.GetTop3ProjectsAsync();
        return ObjectMapper.Map<IEnumerable<ProjectEntity>, IEnumerable<ProjectDto>>(projects);
    }
}