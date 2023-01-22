using BFQG.Entities;
using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories;

public class UserRepository : IBaseRepository<User>
{
    private readonly DbforqgsContext _db;

    public UserRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<User> GetAll()
    {
        IQueryable<User> users = _db.UsersInfos
            .Join(_db.UsersAuthenticationInfo,
            u => u.Id, u => u.Id,
            (ui, ua) => new User
            {
                Id = ui.Id,
                FirstName = ui.Firstname,
                LastName = ui.Lastname,
                Patronomic = ui.Patronomic,
                Course = ui.Course,
                Role = (Role)ui.AccountTypeId,
                GroupId = ui.GroupId,
                Email = ua.Email,
                Password = ua.Password

            });
        return users;
    }

    public async Task Delete(User entity)
    {
        _db.UsersInfos.Remove(
            _db.UsersInfos
            .Where(u => u.Id == entity.Id).First());
        await _db.SaveChangesAsync();
    }

    public async Task Create(User entity)
    {
        await _db.UsersInfos.AddAsync(new UsersInfo() 
        {
            Lastname=entity.LastName,
            Firstname = entity.FirstName,
            Patronomic = entity.Patronomic,
            Course = entity.Course,
            AccountTypeId = (int)entity.Role,
            GroupId = entity.GroupId,
        });
        await _db.SaveChangesAsync();
        int id = _db.UsersInfos.Last().Id;
        await _db.UsersAuthenticationInfo.AddAsync(new UsersAuthenticationInfo
        {
            Id= id,
            Email= entity.Email,
            Password= entity.Password
        });
        await _db.SaveChangesAsync();

    }

    public async Task<User> Update(User entity)
    {
        _db.UsersInfos.Update(new UsersInfo()
        {
            Id = entity.Id,
            Lastname = entity.LastName,
            Firstname = entity.FirstName,
            Patronomic = entity.Patronomic,
            Course = entity.Course,
            AccountTypeId = (int)entity.Role,
            GroupId = entity.GroupId,
        });
        await _db.SaveChangesAsync();
        int id = _db.UsersInfos.Last().Id;
        _db.UsersAuthenticationInfo.Update(new UsersAuthenticationInfo
        {
            Id = id,
            Email = entity.Email,
            Password = entity.Password
        });
        await _db.SaveChangesAsync();

        return entity;
    }
}
