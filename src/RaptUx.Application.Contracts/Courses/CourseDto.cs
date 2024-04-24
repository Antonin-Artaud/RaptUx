using System;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace RaptUx.Courses;

public class CourseDto : EntityDto<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public string GetVideoId() => Link.Split('=').Last();
}