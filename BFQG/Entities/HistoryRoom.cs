using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class HistoryRoom
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int ProvenLabCount { get; set; }

    public TimeOnly AvgProvenTime { get; set; }

    public int StudentsCount { get; set; }

    public string? LabsJson { get; set; }

    public virtual Room Room { get; set; } = null!;
}
