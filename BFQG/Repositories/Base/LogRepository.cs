namespace BFQG.Repositories.Base;

public class LogRepository : IBaseRepository<Log>
{

    private readonly DbforqgsContext _db;

    public LogRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(Log entity)
    {
        await _db.Logs.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Log entity)
    {
        _db.Logs.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Log> GetAll()
    {
        return _db.Logs;
    }

    public async Task<Log> Update(Log entity)
    {
        _db.Logs.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
