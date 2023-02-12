using System;
using System.Collections.Generic;

namespace BFQG;

public partial class Subject
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Lab> Labs { get; } = new List<Lab>();

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; } = new List<TeacherGroup>();

}
