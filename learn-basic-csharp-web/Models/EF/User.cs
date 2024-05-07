using System;
using System.Collections.Generic;

namespace learn_basic_csharp_web.Models.EF;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual Student? Student { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
