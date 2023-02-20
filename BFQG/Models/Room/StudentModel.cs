namespace BFQG.Models;

public class Student
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronomic { get; set; }

    public int? GroupId { get; set; }

    public int? Course { get; set; }

}
