namespace BFQG.Models;

public class LabsStudent
{
    public int StudentId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public List<int> Labs { get; set; }
}
