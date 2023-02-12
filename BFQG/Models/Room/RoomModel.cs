namespace BFQG.Models;

public class RoomModel
{
    public Teacher Teacher { get; set; }

    public List<Student> Students { get; set; } = new List<Student>();

    public int SubjectId { get; set; }

    public List<LabModel> Labs { get; set; } = new List<LabModel>();

    public List<CompleteLaboratoryModel> CompleteLabs { get; set; } = new List<CompleteLaboratoryModel>();

    public TimeOnly SumTime { get; set; }

    public List<LabStudent> QueueLabs { get; set; } = new List<LabStudent>();

    public List<LabsStudent> PrepareStudent { get; set; } = new List<LabsStudent>();

    public bool LessoStart { get; set; } = false;

    public TimeOnly StartTime { get; set; }

}
