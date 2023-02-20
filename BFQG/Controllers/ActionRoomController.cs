using BFQG.Models.Room;
using System.Xml.Linq;

namespace BFQG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionRoomController : ControllerBase
{
    private IRoomsService _roomsService;
    private IBaseRepository<UserModel> _users;
    private IBaseRepository<TeacherGroup> _teacherSubjectGroup;
    public ActionRoomController(IRoomsService roomsService, IBaseRepository<UserModel> users)
    {
        _roomsService = roomsService;
        _users = users;
    }

    // POST api/<ActionRoomController>
    [HttpPost("Create")]
    public async Task<RoomModel?> Create([FromBody] CreateRoomDataModel createRoomDataModel)
    {
        try
        {
            if (!CheckAuth() || CheckStudent())
                throw new Exception();

            if (int.Parse(User.Identity.Name) != createRoomDataModel.TeacherId)
                throw new Exception();

            var response = await _roomsService.CreateRoom(createRoomDataModel);
            if (response.StatusCode == Enum.StatusCode.OK)
                return response.Data;

            throw new Exception();
        }
        catch (Exception)
        {
            return null;
        }
    }

    [HttpPost("{groupId}")]
    public async Task<RoomModel?> GetRoom(int groupId)
    {

        try
        {
            if (!CheckAuth())
                throw new Exception();

            var user = _users.GetAll().Where(u => u.Id == int.Parse(User.Identity.Name)).First();

            int? userGroupId = user.GroupId;
            if (userGroupId != null && userGroupId != groupId)
                throw new Exception();

            var response = await _roomsService.GetRoomByGroupId(groupId);
            if (response.StatusCode == Enum.StatusCode.OK)
                return response.Data;

            throw new Exception();
        }
        catch (Exception)
        {
            return null;
        }
        

    }
     
    // DELETE api/<ActionRoomController>/5
    [HttpDelete("{groupId}")]
    public async Task<IActionResult> Close(int groupId)
    {
        try
        {
            if (!CheckAuth() || CheckStudent())
                throw new Exception();

            var response = await _roomsService.CloseRoomByGroupId(groupId);

            if(response.StatusCode== Enum.StatusCode.OK)
                return Ok();
            else
                return BadRequest();
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    [NonAction]
    private bool CheckAuth()
    {
        if (User.Identity.IsAuthenticated)
            return true;
        return false;
    }

    [NonAction]
    private bool CheckStudent()
    {
        if (User.Identity.AuthenticationType == "Student")
            return true;
        return false;
    }

    [NonAction]
    private bool CheckTeacher()
    {
        if (User.Identity.AuthenticationType == "Teacher")
            return true;
        return false;
    }

    [NonAction]
    private bool CheckModerator()
    {
        if (User.Identity.AuthenticationType == "Moderator")
            return true;
        return false;
    }
}
