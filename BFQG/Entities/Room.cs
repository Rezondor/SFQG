using System;
using System.Collections.Generic;

namespace BFQG;

public partial class Room
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int? UserCount { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool? IsClose { get; set; }

    public virtual ICollection<HistoryRoom> HistoryRooms { get; } = new List<HistoryRoom>();

    public virtual Lesson Lesson { get; set; } = null!;
}
