namespace BFQG.Repositories.Base;

public class LessonRepository : IBaseRepository<Lesson>
{

    private readonly DbforqgsContext _db;

    public LessonRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(Lesson entity)
    {
        await _db.Lessons.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Lesson entity)
    {
        _db.Lessons.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Lesson> GetAll()
    {
        return _db.Lessons;
    }

    public async Task<Lesson> Update(Lesson entity)
    {
        _db.Lessons.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
