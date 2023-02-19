namespace BFQG.Interfaces;

public interface IActionRoomRepository
{
    Task<RoomModel> Create(CreateRoomDataModel createRoomDataModel);
    Task<bool> Close(int id);
    Task<bool> AddStatistic(RoomModel roomStatistic);
    IQueryable<RoomModel> GetAll();
}
