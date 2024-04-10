using System;
using System.Collections.Generic;
using RaptUx.Courses;
using RaptUx.Projects;

namespace RaptUx.Challenges;

public class CreateUpdateChallengeDto
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public string Context { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime AvailabilityDate { get; set; }
    
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
    public IEnumerable<CourseDto> Courses { get; set; } = new List<CourseDto>();
    public IEnumerable<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
}