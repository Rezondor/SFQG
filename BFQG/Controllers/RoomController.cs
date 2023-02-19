 namespace BFQG.Controllers;
//Пока не работает
public class RoomController
{
    private RoomModel _room;

    public RoomController(RoomModel room)
    {
        _room = room;
    }

    public bool AddStudent(LabsStudent student)
    {
        try
        {
            if (CheckStudentInQueue(student))
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
            return true;
        }
        catch
        {
            //Добавить запись в лог
            return false;
        }
    }


    public void StartLesson()
    {
        if (_room.LessoStart == false)
        {
            var prepData = PrepareLabsData.Prepare(_room.PrepareStudent, _room.Labs.Count);
            Console.WriteLine("Prep data");
            foreach (var item in prepData)
            {
                Console.WriteLine($"Id - {item.StudentId,-4} | {item.Lastname} {item.Firstname} {string.Join(' ', item.Labs)}");
            }
            _room.QueueLabs = QueueGenerator.GenerateQueueLabDown(prepData, _room.Labs);
            _room.PrepareStudent = new List<LabsStudent>();
            _room.StartTime = new TimeOnly(DateTime.Now.TimeOfDay.Ticks);
        }
        _room.LessoStart = true;
    }


    public void SetMark(int mark)
    {
        LabStudent student = _room.QueueLabs[0];
        _room.QueueLabs.Remove(student);
        SetMarkInDB(student, mark);
        _room.SumTime = new TimeOnly(DateTime.Now.TimeOfDay.Ticks - _room.StartTime.Ticks);
        _room.CompleteLabs.Add(new CompleteLaboratoryModel()
        {
            CompliteDate = DateTime.Now,
            LabNumber = student.Lab.Number,
            Mark = mark,
            StudentId = student.StudentId,
        });
    }

    public List<LabStudent> GetQueue()
    {
        return _room.QueueLabs;
    }
    public List<LabsStudent> GetLabsStudents()
    {
        return _room.PrepareStudent;
    }


    public void ReturnToQueue()
    {
        var students = _room.QueueLabs.Where(s => s.StudentId == _room.QueueLabs[0].StudentId);
        foreach (var labStudent in students)
        {
            _room.QueueLabs.Remove(labStudent);
            _room.QueueLabs.Add(labStudent);
        }
    }

    private void SetMarkInDB(LabStudent labStudent, int mark)
    {
        //Добавление записи в БД
    }


    public TimeOnly GetAvgTime()
    {
        return _room.AvgTime;
    }

    private bool CheckStudentInQueue(LabsStudent student)
    {
        return _room.PrepareStudent.Select(s => s.StudentId).Contains(student.StudentId);
    }
}
