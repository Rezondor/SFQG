namespace BFQG.Models;

public class LabStudent
{
    public int StudentId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public LabModel Lab { get; set; }
}
