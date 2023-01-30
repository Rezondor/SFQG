using BFQG.Entities;

namespace BFQG.Models
{
    public class TeacherGroupModel
    {
        public int TeacherId { get; set; }
        public List<int> GroupsId { get; set; }
    }
}
