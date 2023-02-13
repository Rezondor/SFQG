namespace BFQG.Repositories.Base;

public class ActionTypeRepository : IBaseRepository<ActionType>
{

    private readonly DbforqgsContext _db;

    public ActionTypeRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(ActionType entity)
    {
        await _db.ActionTypes.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(ActionType entity)
    {
        _db.ActionTypes.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<ActionType> GetAll()
    {
        return _db.ActionTypes;
    }

    public async Task<ActionType> Update(ActionType entity)
    {
        _db.ActionTypes.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
