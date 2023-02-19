namespace BFQG.Controllers;

[ApiController]
[Route("api/[controller]/{roomId}")]
public class RoomController : ControllerBase
{
    private List<RoomModel> _rooms;
    private IBaseRepository<UserModel> _users;


    public RoomController(RoomSingleton rooms, IBaseRepository<UserModel> users)
    {
        _rooms = rooms.Rooms.ToList();
        _users = users;

    }

    [HttpPost("AddStudent")]
    public async Task<IActionResult> AddStudent(int roomId, LabsStudent student)
    {
        try
        {
            var _room = _rooms.Where(r => r.Id == roomId).First();

            if (!CheckAuth() || !CheckInRoom(roomId))
                throw new Exception();

            var user = _users.GetAll().Where(u => u.Id == int.Parse(User.Identity.Name) && u.Id == student.StudentId).First();


            if (CheckStudentInQueue(roomId, student))
                throw new Exception("Такой студент уже в очереди!");


            if (_room.LessoStart != true)
            {
                _room.PrepareStudent.Add(student);
            }
            else
            {
                var studentLab = PrepareLabsData.Prepare(new() { student }, _room.Labs.Count);
                _room.QueueLabs = _room.QueueLabs.Concat(QueueGenerator.GenerateQueueLabDown(studentLab, _room.Labs)).ToList();
            }
            return Ok();
        }
        catch
        {
            //Добавить запись в лог
            return BadRequest();
        }
    }

    [HttpPost("StartLesson")]
    public async Task<IActionResult> StartLesson(int roomId)
    {
        try
        {
            var _room = _rooms.Where(r => r.Id == roomId).First();
            _room = _rooms.Where(r => r.Id == roomId).First();

            if (!CheckAuth() || CheckStudent() || !CheckInRoom(roomId))
                throw new Exception();


            if (_room.LessoStart == false)
            {
                var prepData = PrepareLabsData.Prepare(_room.PrepareStudent, _room.Labs.Count);
                _room.QueueLabs = QueueGenerator.GenerateQueueLabDown(prepData, _room.Labs);
                _room.PrepareStudent = new List<LabsStudent>();
                _room.StartTime = new TimeOnly(DateTime.Now.TimeOfDay.Ticks);
            }
            _room.LessoStart = true;
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
        
    }

    [NonAction]
    public void SetMark(int roomId, int mark)
    {
        var _room = _rooms.Where(r => r.Id == roomId).First();
        if (!CheckAuth() || CheckStudent() || !CheckInRoom(roomId))
            throw new Exception();

        LabStudent student = _room.QueueLabs[0];
        _room.QueueLabs.Remove(student);
        //SetMarkInDB(student, mark);
        _room.SumTime = new TimeOnly(DateTime.Now.TimeOfDay.Ticks - _room.StartTime.Ticks);
        _room.CompleteLabs.Add(new CompleteLaboratoryModel()
        {
            CompliteDate = new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc),
            LabNumber = student.Lab.Number,
            Mark = mark,
            StudentId = student.StudentId,
        });
    }
    [HttpGet("GetQueue")]
    public List<LabStudent> GetQueue(int roomId)
    {
        var _room = _rooms.Where(r => r.Id == roomId).First();
        if (!CheckAuth() || !CheckInRoom(roomId))
            throw new Exception();
        return _room.QueueLabs;
    }
    [NonAction]
    /*public List<LabsStudent> GetLabsStudents()
    {
        return _room.PrepareStudent;
    }*/

    [HttpPost("ReturnToQueue")]
    public void ReturnToQueue(int roomId)
    {

        if (!CheckAuth() || CheckStudent() || !CheckInRoom(roomId))
            throw new Exception();

        var _room = _rooms.Where(r => r.Id == roomId).First();

        var students = _room.QueueLabs.Where(s => s.StudentId == _room.QueueLabs[0].StudentId);
        foreach (var labStudent in students)
        {
            _room.QueueLabs.Remove(labStudent);
            _room.QueueLabs.Add(labStudent);
        }
    }
    [NonAction]
    private void SetMarkInDB(LabStudent labStudent, int mark)
    {
    }

    [HttpGet("GetAvgTime")]
    public TimeOnly GetAvgTime(int roomId)
    {
        try
        {

            if (!CheckAuth() || !CheckInRoom(roomId))
                throw new Exception();
            var _room = _rooms.Where(r => r.Id == roomId).First();
            return _room.AvgTime;
        }
        catch (Exception)
        {
            return new TimeOnly();
        }

    }

    [NonAction]
    private bool CheckStudentInQueue(int roomId, LabsStudent student)
    {
        var _room = _rooms.Where(r => r.Id == roomId).First();
        return _room.PrepareStudent.Select(s => s.StudentId).Contains(student.StudentId);
    }

    [NonAction]
    private bool CheckStudent()
    {
        if (User.Identity.AuthenticationType == "Student")
            return true;
        return false;
    }

    [NonAction]
    private bool CheckTeacher()
    {
        if (User.Identity.AuthenticationType == "Teacher")
            return true;
        return false;
    }

    [NonAction]
    private bool CheckModerator()
    {
        if (User.Identity.AuthenticationType == "Moderator")
            return true;
        return false;
    }

    [NonAction]
    private bool CheckAuth()
    {
        if (User.Identity.IsAuthenticated)
            return true;
        return false;
    }

    [NonAction]
    private bool CheckInRoom(int roomId)
    {
        int userId = int.Parse(User.Identity.Name);
        var _room = _rooms.Where(r => r.Id == roomId).First();
        if (_users.GetAll().Where(u => u.Id == userId).First().GroupId == _room.GroupId || _room.Teacher.TeacherId == userId)
            return true;
        return false;
    }
}
