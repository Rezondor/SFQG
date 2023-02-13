namespace BFQG.Repositories.Base;

public class StydentVisitRepository : IBaseRepository<StudentVisit>
{

    private readonly DbforqgsContext _db;

    public StydentVisitRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(StudentVisit entity)
    {
        await _db.StudentVisits.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(StudentVisit entity)
    {
        _db.StudentVisits.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<StudentVisit> GetAll()
    {
        return _db.StudentVisits;
    }

    public async Task<StudentVisit> Update(StudentVisit entity)
    {
        _db.StudentVisits.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
