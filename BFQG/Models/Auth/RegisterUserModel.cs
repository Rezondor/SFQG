using BFQG.Entities;
using BFQG.Enum;

namespace BFQG.Models.Auth
{
    public class RegisterUserModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronomic { get; set; }
        public string Password { get; set; }
        public int? GroupId { get; set; }
        public string Email { get; set; }
        public int? Course { get; set; }
        public Role Role { get; set; }
    }
}
