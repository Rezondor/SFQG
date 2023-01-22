using System;
using System.Collections.Generic;

namespace BFQG.Entities;

public partial class UsersAuthenticationInformation
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual UsersInfo IdNavigation { get; set; } = null!;
}
