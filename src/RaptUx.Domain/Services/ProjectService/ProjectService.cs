using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaptUx.Entities.ProjectEntities;
using RaptUx.Managers.ProjectManager;
using Volo.Abp.Domain.Repositories;

namespace RaptUx.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly IReadOnlyRepository<ProjectEntity> _projectRepository;

    public ProjectService(IReadOnlyRepository<ProjectEntity> projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectEntity>> GetTop3ProjectsAsync()
    {
        var ctx = await _projectRepository.GetQueryableAsync();

        var projects = ctx.OrderByDescending(p => p.Likes).Take(3);

        return projects.ToList();
    }
}