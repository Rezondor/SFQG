
namespace BFQG.Interfaces
{
    public interface IRoomsService
    {
        //Task CreateRoom(T entity);

        Task CloseRoomByGroupId(int groupId);

        Task<RoomModel> GetRoomByGroupId(int groupId);
    }
}
