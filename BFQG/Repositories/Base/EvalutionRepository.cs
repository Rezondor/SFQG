namespace BFQG.Repositories.Base;

public class EvalutionRepository : IBaseRepository<Evaluation>
{

    private readonly DbforqgsContext _db;

    public EvalutionRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(Evaluation entity)
    {
        await _db.Evaluations.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Evaluation entity)
    {
        _db.Evaluations.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Evaluation> GetAll()
    {
        return _db.Evaluations;
    }

    public async Task<Evaluation> Update(Evaluation entity)
    {
        _db.Evaluations.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
