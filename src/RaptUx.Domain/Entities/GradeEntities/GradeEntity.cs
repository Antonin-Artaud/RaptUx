using Volo.Abp.Domain.Entities;

namespace RaptUx.Entities.GradeEntities;

public class GradeEntity : Entity<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}