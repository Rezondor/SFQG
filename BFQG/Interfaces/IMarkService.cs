namespace BFQG.Interfaces
{
    public interface IMarkService
    {
        Task<IQueryable<Evaluation>> GetMark(int userId);
        Task<bool> SetMark(CompletedLabModel completedLab);
    }
}