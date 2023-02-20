namespace BFQG.Services;

public class MarkService : IMarkService
{
    private readonly IBaseRepository<Evaluation> _evaluation;
    public MarkService(IBaseRepository<Evaluation> evaluation)
    {
        _evaluation = evaluation;
    }
    public async Task<bool> SetMark(CompletedLabModel completedLab)
    {
        try
        {
            var time = completedLab.HandOverTime;
            await _evaluation.Create(new Evaluation
            {
                UserId = completedLab.StudentId,
                LabId = completedLab.LabId,
                Mark = completedLab.Mark,
                HandOverDate = new DateOnly(time.Year, time.Month, time.Day),
                HandOverTime = new TimeOnly(time.Hour, time.Minute, time.Second)
            });

            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<IQueryable<Evaluation>> GetMark(int userId)
    {
        try
        {
            return _evaluation.GetAll().Where(e => e.UserId == userId);
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}