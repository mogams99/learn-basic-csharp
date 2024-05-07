using System;
using System.Collections.Generic;

namespace learn_basic_csharp_web.Models.EF;

public partial class Class
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? StudentId { get; set; }

    public int Semester { get; set; }

    public int Year { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
