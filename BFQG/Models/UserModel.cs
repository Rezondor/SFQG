using NuGet.ContentModel;
using System.Data;
using BFQG.Enum;
using BFQG.Entities;

namespace BFQG.Models;

public class UserModel
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Patronomic { get; set; }
    public string Password { get; set; }
    public int? GroupId { get; set; }
    public string Email { get; set; }
    public int? Course { get; set; }
    public Role Role { get; set; }
}
