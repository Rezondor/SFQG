using BFQG.Entities;
using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories;

public class TeacherGroupRepository : IBaseRepository<TeacherGroupModel>
{
    private readonly DbforqgsContext _db;

    public TeacherGroupRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<TeacherGroupModel> GetAll()
    {
        return _db.TeacherGroups
            .GroupBy(e=>e.TeacherId)
            .Select(t=> new TeacherGroupModel() { TeacherId = t.Key, GroupsId = t.Select(e=>e.GroupId).ToList()});
    }

    public async Task Delete(TeacherGroupModel entity)
    {
        _db.TeacherGroups.RemoveRange(_db.TeacherGroups.Where(e=>e.TeacherId==entity.TeacherId && entity.GroupsId.Contains(e.GroupId)));
        await _db.SaveChangesAsync();
    }

    public async Task Create(TeacherGroupModel entity)
    {
        foreach (var item in entity.GroupsId)
        {
            await _db.TeacherGroups.AddAsync(new TeacherGroup()
            {
                TeacherId = entity.TeacherId,
                GroupId = item
            });
        }
        await _db.SaveChangesAsync();
    }

    public async Task<TeacherGroupModel> Update(TeacherGroupModel entity)
    {
        throw new NotImplementedException();
    }
}
