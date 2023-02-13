using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class Group
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; } = new List<TeacherGroup>();

    public virtual ICollection<UsersInfo> UsersInfos { get; } = new List<UsersInfo>();
}
