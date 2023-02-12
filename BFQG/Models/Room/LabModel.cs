namespace BFQG.Models;

public class LabModel
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Title { get; set; } = null!;

    public string? DocName { get; set; }

    public DateTime? Deadline { get; set; }

    public int? MaxScore { get; set; }

    public bool IsVisible { get; set; }

    public string? TestLink { get; set; }

}
