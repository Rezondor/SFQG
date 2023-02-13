namespace BFQG.Repositories.Base
{
    public class TeacherGroupSubjectRepository : IBaseRepository<TeacherGroup>
    {

        private readonly DbforqgsContext _db;

        public TeacherGroupSubjectRepository(DbforqgsContext db)
        {
            _db = db;
        }
        public async Task Create(TeacherGroup entity)
        {
            await _db.TeacherGroups.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(TeacherGroup entity)
        {
            _db.TeacherGroups.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<TeacherGroup> GetAll()
        {
            return _db.TeacherGroups;
        }

        public async Task<TeacherGroup> Update(TeacherGroup entity)
        {
            _db.TeacherGroups.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
