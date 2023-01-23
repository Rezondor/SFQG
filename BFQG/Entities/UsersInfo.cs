using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class UsersInfo
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronomic { get; set; }

    public int AccountTypeId { get; set; }

    public int? GroupId { get; set; }

    public int? Course { get; set; }

    public virtual AccountType AccountType { get; set; } = null!;

    public virtual ICollection<Evaluation> Evaluations { get; } = new List<Evaluation>();

    public virtual Group? Group { get; set; }

    public virtual ICollection<Lab> Labs { get; } = new List<Lab>();

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<StudentVisit> StudentVisits { get; } = new List<StudentVisit>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; } = new List<TeacherGroup>();

    public virtual UsersAuthenticationInfo? UsersAuthenticationInfo { get; set; }
}
