using BFQG.Entities;
using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories;

public class GroupRepository : IBaseRepository<Group>
{
    private readonly DbforqgsContext _db;

    public GroupRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<Group> GetAll()
    {
        IQueryable<Group> groups = _db.Groups;
        return groups;
    }

    public async Task Delete(Group entity)
    {
        _db.Groups.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Create(Group entity)
    {
        await _db.Groups.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<Group> Update(Group entity)
    {
        _db.Groups.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
