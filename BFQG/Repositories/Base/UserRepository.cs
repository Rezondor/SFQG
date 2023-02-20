using BFQG.Entities;
using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories.Base;

public class UserRepository : IBaseRepository<UserModel>
{
    private readonly DbforqgsContext _db;

    public UserRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<UserModel> GetAll()
    {
        IQueryable<UserModel> users = _db.UsersInfos
            .Join(_db.UsersAuthenticationInfos,
            u => u.Id, u => u.Id,
            (ui, ua) => new UserModel
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

    public async Task Delete(UserModel entity)
    {
        _db.UsersInfos.Remove(
            _db.UsersInfos
            .Where(u => u.Id == entity.Id).First());
        await _db.SaveChangesAsync();
    }

    public async Task Create(UserModel entity)
    {
        await _db.UsersInfos.AddAsync(new UsersInfo()
        {
            Lastname = entity.LastName,
            Firstname = entity.FirstName,
            Patronomic = entity.Patronomic,
            Course = entity.Course,
            AccountTypeId = (int)entity.Role,
            GroupId = entity.GroupId,
        });
        await _db.SaveChangesAsync();
        await _db.UsersAuthenticationInfos.AddAsync(new UsersAuthenticationInfo
        {
            Id = _db.UsersInfos.
            Where(u =>
            u.Firstname == entity.FirstName &&
            u.Lastname == entity.LastName &&
            u.Course == entity.Course &&
            u.Patronomic == entity.Patronomic).First().Id,
            Email = entity.Email,
            Password = entity.Password
        });
        await _db.SaveChangesAsync();

    }

    public async Task<UserModel> Update(UserModel entity)
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
        _db.UsersAuthenticationInfos.Update(new UsersAuthenticationInfo
        {
            Id = id,
            Email = entity.Email,
            Password = entity.Password
        });
        await _db.SaveChangesAsync();

        return entity;
    }
}
