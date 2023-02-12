using System;
using System.Collections.Generic;

namespace BFQG;

public partial class StudentVisit
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LessonId { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual UsersInfo User { get; set; } = null!;
}
