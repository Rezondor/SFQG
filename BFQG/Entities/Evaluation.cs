using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class Evaluation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LabId { get; set; }

    public DateOnly HandOverDate { get; set; }

    public int Mark { get; set; }

    public TimeOnly HandOverTime { get; set; }

    public virtual Lab Lab { get; set; } = null!;

    public virtual UsersInfo User { get; set; } = null!;
}
