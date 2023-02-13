
namespace BFQG.Interfaces;

public interface IRoomsService
{ 
    Task<BaseResponse<RoomModel>> CreateRoom(CreateRoomDataModel entity);

    Task<BaseResponse<bool>> CloseRoomByGroupId(int groupId);

    Task<BaseResponse<RoomModel>> GetRoomByGroupId(int groupId);
}
