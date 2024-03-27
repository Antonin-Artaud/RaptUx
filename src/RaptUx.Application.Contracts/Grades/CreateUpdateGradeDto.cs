using System.ComponentModel.DataAnnotations;

namespace RaptUx.GradeDtos;

public class CreateUpdateGradeDto
{
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
}