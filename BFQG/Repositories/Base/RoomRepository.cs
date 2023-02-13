namespace BFQG.Repositories.Base;

public class RoomRepository : IBaseRepository<Room>
{

    private readonly DbforqgsContext _db;

    public RoomRepository(DbforqgsContext db)
    {
        _db = db;
    }
    public async Task Create(Room entity)
    {
        await _db.Rooms.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Room entity)
    {
        _db.Rooms.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Room> GetAll()
    {
        return _db.Rooms;
    }

    public async Task<Room> Update(Room entity)
    {
        _db.Rooms.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}