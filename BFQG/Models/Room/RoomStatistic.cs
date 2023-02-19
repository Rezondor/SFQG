namespace BFQG.Models.Room;

public class RoomStatistic
{
    public int Id { get; set; }
    public int ProvenLabCount { get; set; }
    public TimeOnly AvgProvenTime { get; set; }
    public int StudentCount { get; set; }
    public string LabsJson { get; set; }
}
