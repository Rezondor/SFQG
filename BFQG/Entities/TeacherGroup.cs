using System;
using System.Collections.Generic;

namespace BFQG;

public partial class TeacherGroup
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int GroupId { get; set; }

    public int SubjectId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual UsersInfo Teacher { get; set; } = null!;
}
