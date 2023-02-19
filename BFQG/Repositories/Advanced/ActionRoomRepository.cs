using BFQG.Models.Room;
using System.Text.Json;

namespace BFQG.Repositories.Advanced;

public class ActionRoomRepository : IActionRoomRepository
{
    private IBaseRepository<Lesson> _lessons;
    private IBaseRepository<Room> _rooms;
    private IBaseRepository<HistoryRoom> _historyRooms;
    private IBaseRepository<UserModel> _users;
    private IBaseRepository<Lab> _labs;

    public ActionRoomRepository(
        IBaseRepository<Lesson> lessons, 
        IBaseRepository<Room> rooms, 
        IBaseRepository<HistoryRoom> historyRooms, 
        IBaseRepository<Lab> labs,
        IBaseRepository<UserModel> users)
    {
        _lessons = lessons;
        _rooms = rooms;
        _historyRooms = historyRooms;
        _labs = labs;
        _users = users;
    }
    public async Task<bool> AddStatistic(RoomModel room)
    {
        try
        {
            await _historyRooms.Create(new HistoryRoom
            {
                RoomId = room.Id,
                AvgProvenTime = room.AvgTime,
                StudentsCount = GetStudentCount(room.CompleteLabs),
                ProvenLabCount = room.CompleteLabs.Count,
                LabsJson = GetSerializableLab(room.CompleteLabs),
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public async Task<bool> Close(int id)
    {
        try
        {
            var room = _rooms.GetAll().Where(r => r.Id == id).First();
            room.IsClose = true;
            room.EndDate = new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc);
            await _rooms.Update(room);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<RoomModel> Create(CreateRoomDataModel createRoomDataModel)
    {
        try
        {
            var date = new DateTime(DateTime.Now.Ticks,DateTimeKind.Utc);
            var tempLesson = new Lesson
            {
                AuthorUserId = createRoomDataModel.TeacherId,
                Date = date,
                GroupId = createRoomDataModel.GroupId,
                SubjectId = createRoomDataModel.SubjectId
            };

            await _lessons.Create(tempLesson);
            var lesson = _lessons.GetAll()
                .Where(l => l.GroupId == tempLesson.GroupId &&
                l.SubjectId == tempLesson.SubjectId &&
                l.Date == date).First();

            await _rooms.Create(new Room
            {
                LessonId = lesson.Id,
                CreateDate = date,
                IsClose = false,
                UserCount = _users.GetAll().Where(u => u.GroupId == createRoomDataModel.GroupId).Count()
            });

            var tempRoom = _rooms.GetAll().Where(r => r.LessonId == tempLesson.Id && r.CreateDate == date).First();
            var roomModel = new RoomModel
            {
                Id = tempRoom.Id,
                SubjectId = tempLesson.SubjectId,
                GroupId = tempLesson.GroupId,
                Labs = _labs.GetAll().Where(l => l.IsVisible == true && l.SubjectId == createRoomDataModel.SubjectId).Select(l => new LabModel
                {
                    Id = l.Id,
                    IsVisible = l.IsVisible,
                    Deadline = l.Deadline,
                    DocName = l.DocName,
                    MaxScore = l.MaxScore,
                    Number = l.Number,
                    TestLink = l.TestLink,
                    Title = l.Title,
                }).ToList(),
                Teacher = _users.GetAll().Where(u => u.Id == createRoomDataModel.TeacherId).Select(t => new Teacher
                {
                    TeacherId = t.Id,
                    Firstname = t.FirstName,
                    Lastname = t.LastName,
                    Patronomic = t.Patronomic,
                }).First(),
            };
            return roomModel;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка!");
        }

    }
    private int GetStudentCount(List<CompleteLaboratoryModel> labs)
    {
        HashSet<int> students = new HashSet<int>();

        foreach (var lab in labs)
            students.Add(lab.StudentId);

        return students.Count;
    }
    private string GetSerializableLab(List<CompleteLaboratoryModel> compliteLabs)
    {
        Dictionary<int, int> labs = new Dictionary<int, int>();
        foreach (var lab in compliteLabs)
        {
            if (!labs.Keys.Contains(lab.LabNumber))
            {
                labs.Add(lab.LabNumber, 1);
            }
            else
            {
                labs[lab.LabNumber]++;
            }
        }
        return JsonSerializer.Serialize(labs);
    }

    public IQueryable<RoomModel> GetAll()
    {
        var rooms = _rooms.GetAll().Where(r => r.IsClose == false);
        return rooms.Join(
            _lessons.GetAll(),
            r => r.LessonId,
            l => l.Id,
            (r, les) => new RoomModel
            {
                Id = r.Id,
                SubjectId = les.SubjectId,
                GroupId = les.GroupId,
                Labs = _labs.GetAll()
                .Where(l => l.IsVisible == true && l.SubjectId == les.SubjectId)
                .Select(l => new LabModel
                {
                    Id = l.Id,
                    IsVisible = l.IsVisible,
                    Deadline = l.Deadline,
                    DocName = l.DocName,
                    MaxScore = l.MaxScore,
                    Number = l.Number,
                    TestLink = l.TestLink,
                    Title = l.Title,
                }).ToList(),
                Teacher = _users.GetAll().Where(u => u.Id == les.AuthorUserId).Select(t => new Teacher
                {
                    TeacherId = t.Id,
                    Firstname = t.FirstName,
                    Lastname = t.LastName,
                    Patronomic = t.Patronomic,
                }).First(),
            });            
    }
}
