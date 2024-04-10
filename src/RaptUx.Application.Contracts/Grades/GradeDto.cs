using Volo.Abp.Application.Dtos;

namespace RaptUx.GradeDtos;

public class GradeDto : EntityDto<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}