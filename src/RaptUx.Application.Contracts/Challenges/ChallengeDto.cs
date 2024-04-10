using System;
using System.Collections.Generic;
using RaptUx.Courses;
using RaptUx.Projects;
using Volo.Abp.Application.Dtos;

namespace RaptUx.Challenges;

public class ChallengeDto : EntityDto<Guid>
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public string Context { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime AvailabilityDate { get; set; }
    
    public List<Guid> UserIds { get; set; } = [];
    public List<CourseDto> Courses { get; set; } = [];
    public List<ProjectDto> Projects { get; set; } = [];
}