using System;
using System.Collections.Generic;

namespace learn_basic_csharp_web.Models.EF;

public partial class Student
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Major { get; set; }

    public int? EnrollmentYear { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User? User { get; set; }
}
