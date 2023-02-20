namespace BFQG.Repositories.Base;

public class HistoryRoomRepository : IBaseRepository<HistoryRoom>
{

    private readonly DbforqgsContext _db;

    public HistoryRoomRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(HistoryRoom entity)
    {
        await _db.HistoryRooms.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(HistoryRoom entity)
    {
        _db.HistoryRooms.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<HistoryRoom> GetAll()
    {
        return _db.HistoryRooms;
    }

    public async Task<HistoryRoom> Update(HistoryRoom entity)
    {
        _db.HistoryRooms.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
