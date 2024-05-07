using System;
using System.Collections.Generic;

namespace learn_basic_csharp_web.Models.EF;

public partial class Instructor
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Department { get; set; }

    public string? Specialization { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User? User { get; set; }
}
