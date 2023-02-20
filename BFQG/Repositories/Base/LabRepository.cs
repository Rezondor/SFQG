namespace BFQG.Repositories.Base;

public class LabRepository : IBaseRepository<Lab>
{

    private readonly DbforqgsContext _db;

    public LabRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(Lab entity)
    {
        await _db.Labs.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Lab entity)
    { 
        _db.Labs.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Lab> GetAll()
    {
        return _db.Labs;
    }

    public async Task<Lab> Update(Lab entity)
    {
        _db.Labs.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
