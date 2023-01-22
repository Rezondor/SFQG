using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class TeacherGroup
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual UsersInfo Teacher { get; set; } = null!;
}
