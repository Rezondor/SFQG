using System.ComponentModel.DataAnnotations;

namespace BFQG.Enum
{
    public enum Role
    {
        
        [Display(Name = "Модератор")]
        Moderator = 1,
        [Display(Name = "Преподаватель")]
        Teacher = 2,
        [Display(Name = "Студент")]
        Student = 3,
    }
}