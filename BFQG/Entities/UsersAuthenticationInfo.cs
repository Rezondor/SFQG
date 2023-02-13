using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class UsersAuthenticationInfo
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual UsersInfo IdNavigation { get; set; } = null!;
}
