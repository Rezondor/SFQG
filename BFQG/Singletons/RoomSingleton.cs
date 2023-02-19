using BFQG.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BFQG.Singletons;

public class RoomSingleton
{
    public List<RoomModel> Rooms;

    public RoomSingleton(IServiceScopeFactory scopeFactory)
	{
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DbforqgsContext>();
            var rooms = db.Rooms.Where(r => r.IsClose == false);
            Rooms = rooms.Join(
                db.Lessons,
                r => r.LessonId,
                l => l.Id,
                (r, les) => new RoomModel
                {
                    Id = r.Id,
                    SubjectId = les.SubjectId,
                    GroupId = les.GroupId,
                    Labs = db.Labs
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
                    Teacher = db.UsersInfos.Where(u => u.Id == les.AuthorUserId).Select(t => new Teacher
                    {
                        TeacherId = t.Id,
                        Firstname = t.Firstname,
                        Lastname = t.Lastname,
                        Patronomic = t.Patronomic,
                    }).First(),
                }).ToList();
        }
    }
}
