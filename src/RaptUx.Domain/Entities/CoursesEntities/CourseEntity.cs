using System;
using Volo.Abp.Domain.Entities;

namespace RaptUx.Entities.CoursesEntities;

public class CourseEntity : Entity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}