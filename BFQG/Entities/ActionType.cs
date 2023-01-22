using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class ActionType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; } = new List<Log>();
}
