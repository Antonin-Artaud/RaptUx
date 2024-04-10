using System;

namespace RaptUx.Projects;

public class CreateUpdateProjectDto
{
    public Guid OwnerId { get; set; } = Guid.Empty;
    public string ImageBase64 { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Likes { get; set; } = 0;
    public Guid ChallengeId { get; set; } = Guid.Empty;
}