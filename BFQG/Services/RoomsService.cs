namespace BFQG.Services
{
    public class RoomsService : IRoomsService
    {
        private List<RoomModel> _rooms;
        public RoomsService()
        {
            _rooms= new List<RoomModel>();
        }
        public async Task<BaseResponse<bool>> CloseRoomByGroupId(int groupId)
        {
            await Task.Delay(0);
            try
            {
                var removableRoom = _rooms.Where(r => r.GroupId == groupId).First();
                _rooms.Remove(removableRoom);
                //Установить в БД возле этой комнаты флаг закрыта.
                //Подсчитать статистику
                //Добавить всю статискику в таблицу истории
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

        public async Task<BaseResponse<RoomModel>> CreateRoom(CreateRoomDataModel entity)
        {
            //Создание комнаты в БД
            //Создание урока
            //Добавление в лист
            //Возврат комнаты если всё хорошо

            try
            {
                var room = new RoomModel();

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
