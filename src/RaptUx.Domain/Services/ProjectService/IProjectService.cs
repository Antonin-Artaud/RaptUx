using System.Collections.Generic;
using System.Threading.Tasks;
using RaptUx.Entities.ProjectEntities;
using Volo.Abp.Domain.Services;

namespace RaptUx.Managers.ProjectManager;

public interface IProjectService : IDomainService
{
    Task<IEnumerable<ProjectEntity>> GetTop3ProjectsAsync();
}