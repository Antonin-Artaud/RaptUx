using System;
using System.Collections.Generic;
using RaptUx.Entities.ChallengeEntities;
using Volo.Abp.Domain.Entities;

namespace RaptUx.Entities.ProjectEntities;

public class ProjectEntity : Entity<Guid>
{
    public Guid OwnerId { get; set; }
    public string ImageBase64 { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Likes { get; set; }
    public ChallengeEntity Challenge { get; set; }
}