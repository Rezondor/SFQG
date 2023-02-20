using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class Lab
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public string Title { get; set; } = null!;

    public int SubjectId { get; set; }

    public string? DocName { get; set; }

    public DateTime? Deadline { get; set; }

    public int? MaxScore { get; set; }

    public bool IsVisible { get; set; }

    public string? TestLink { get; set; }

    public int Number { get; set; }

    public virtual UsersInfo Author { get; set; } = null!;

    public virtual ICollection<Evaluation> Evaluations { get; } = new List<Evaluation>();

    public virtual Subject Subject { get; set; } = null!;
}
