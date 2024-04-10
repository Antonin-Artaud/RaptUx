using System;
using System.Collections.Generic;
using RaptUx.Entities.CoursesEntities;
using RaptUx.Entities.ProjectEntities;
using Volo.Abp.Domain.Entities;

namespace RaptUx.Entities.ChallengeEntities;

public class ChallengeEntity : Entity<Guid>
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public string Context { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime AvailabilityDate { get; set; }
    
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
    public IEnumerable<CourseEntity> Courses { get; set; } = new List<CourseEntity>();
    public IEnumerable<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
}