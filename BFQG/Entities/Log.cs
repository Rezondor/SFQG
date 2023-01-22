using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class Log
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string? Text { get; set; }

    public int ActionTypeId { get; set; }

    public virtual ActionType ActionType { get; set; } = null!;

    public virtual UsersInfo User { get; set; } = null!;
}
