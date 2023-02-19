namespace BFQG.Services
{
    public class RoomsService : IRoomsService
    {
        private List<RoomModel> _rooms;
        private IActionRoomRepository _actionRoomRepository;
        public RoomsService(IActionRoomRepository actionRoomRepository)
        {
            _rooms = new List<RoomModel>();
            _actionRoomRepository = actionRoomRepository;
        }


        // ++
        public async Task<BaseResponse<bool>> CloseRoomByGroupId(int groupId)
        {
            try
            {
                var removableRoom = _rooms.Where(r => r.GroupId == groupId).First();
                _rooms.Remove(removableRoom);

                //Установить в БД возле этой комнаты флаг закрыта.
                await _actionRoomRepository.Close(removableRoom.Id);

                //Подсчитать статистику
                //Добавить всю статискику в таблицу истории
                await _actionRoomRepository.AddStatistic(removableRoom);
               
                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Закрытие комнаты произошло успешно!"
                };
            }
            catch (Exception)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Во время закрытия комнаты произошла ошибка!"
                };
            }
            
        }


        // ++
        public async Task<BaseResponse<RoomModel>> CreateRoom(CreateRoomDataModel entity)
        {
            //Создание комнаты в БД
            //Создание урока 
            //Добавление в лист
            //Возврат комнаты если всё хорошо

            try
            {
                var room = await _actionRoomRepository.Create(entity);
                _rooms.Add(room);
                return new BaseResponse<RoomModel>
                {
                    Data = room,
                    StatusCode = StatusCode.OK,
                    Description = "Комната создана успешно!"
                };
            }
            catch (Exception)
            {

                return new BaseResponse<RoomModel>
                {
                    Data = null,
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Во время создание комнаты произошла ошибка!"
                };
            }
        }


        // ++
        public async Task<BaseResponse<RoomModel>> GetRoomByGroupId(int groupId)
        {
            //Поиск комнаты по id группы 
            //И возврат если всё хорошо
            try
            {
                var room = _rooms.Where(r => r.GroupId == groupId).First();

                return new BaseResponse<RoomModel>
                {
                    Data = room,
                    StatusCode = StatusCode.OK,
                    Description = "Комната найдена!"
                }; 
            }
            catch (Exception)
            {

                return new BaseResponse<RoomModel>
                {
                    Data = null,
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Комната не найдена!"
                };
            }
        }
    }
}
