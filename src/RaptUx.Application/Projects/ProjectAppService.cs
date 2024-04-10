using System;
using RaptUx.Entities.ProjectEntities;
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
    public ProjectAppService(IRepository<ProjectEntity, Guid> repository) : base(repository)
    {
    }
}