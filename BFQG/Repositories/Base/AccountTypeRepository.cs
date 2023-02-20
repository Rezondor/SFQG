using BFQG.Enum;
using BFQG.Interfaces;
using BFQG.Models;

namespace BFQG.Repositories.Base;

public class AccountTypeRepository : IBaseRepository<AccountType>
{
    private readonly DbforqgsContext _db;

    public AccountTypeRepository(DbforqgsContext db)
    {
        _db = db;
    }

    public IQueryable<AccountType> GetAll()
    {
        IQueryable<AccountType> groups = _db.AccountTypes;
        return groups;
    }

    public async Task Delete(AccountType entity)
    {
        _db.AccountTypes.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Create(AccountType entity)
    {
        await _db.AccountTypes.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<AccountType> Update(AccountType entity)
    {
        _db.AccountTypes.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
