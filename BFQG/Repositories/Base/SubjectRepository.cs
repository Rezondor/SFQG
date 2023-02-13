using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories.Base;

public class SubjectRepository : IBaseRepository<Subject>
{
    private readonly DbforqgsContext _db;

    public SubjectRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<Subject> GetAll()
    {
        IQueryable<Subject> subjects = _db.Subjects;
        return subjects;
    }

    public async Task Delete(Subject entity)
    {
        _db.Subjects.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Create(Subject entity)
    {
        await _db.Subjects.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<Subject> Update(Subject entity)
    {
        _db.Subjects.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
