using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class AccountType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<UsersInfo> UsersInfos { get; } = new List<UsersInfo>();
}
