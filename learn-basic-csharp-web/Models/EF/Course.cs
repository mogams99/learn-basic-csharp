using System;
using System.Collections.Generic;

namespace learn_basic_csharp_web.Models.EF;

public partial class Course
{
    public int Id { get; set; }

    public int? InstructorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Instructor? Instructor { get; set; }
}
