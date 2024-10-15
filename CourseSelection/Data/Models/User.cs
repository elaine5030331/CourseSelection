using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Student Student { get; set; }

    public virtual Teacher Teacher { get; set; }
}
