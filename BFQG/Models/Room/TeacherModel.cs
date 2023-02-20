namespace BFQG.Models;

public class Teacher
{
    public int TeacherId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronomic { get; set; }

    public ICollection<Group>? Groups { get; set; }

}
