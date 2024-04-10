using System;
using Volo.Abp.Application.Dtos;

namespace RaptUx.Projects;

public class ProjectDto : EntityDto<Guid>
{
    public Guid OwnerId { get; set; } = Guid.Empty;
    public string ImageBase64 { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Likes { get; set; } = 0;
    public Guid ChallengeId { get; set; } = Guid.Empty;
}