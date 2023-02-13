using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class Lesson
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int AuthorUserId { get; set; }

    public DateTime? Date { get; set; }

    public int GroupId { get; set; }

    public virtual UsersInfo AuthorUser { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<StudentVisit> StudentVisits { get; } = new List<StudentVisit>();

    public virtual Subject Subject { get; set; } = null!;
}
