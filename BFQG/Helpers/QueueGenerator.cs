namespace BFQG.Helpers;

public static class QueueGenerator
{
    public static List<LabStudent> GenerateQueueLabDown(List<LabsStudent> labsStudents, List<LabModel> availableLabs)
    {
        List<LabStudent> queue = new();

        int max = labsStudents.Max(l => l.Labs.Count);

        for (int i = max - 1; i >= 0; i--)
        {
            foreach (var student in labsStudents)
            {
                List<int> labs = student.Labs;
                if (labs[i] != 0)
                    continue;
                bool isLabsSubmitted = true;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (labs[j] != 1)
                    {
                        isLabsSubmitted = false;
                        break;
                    }
                }

                if (!isLabsSubmitted)
                    continue;

                for (int k = i; k < max; k++)
                {
                    if (labs[k] != 0)
                        continue;

                    queue.Add(new LabStudent()
                    {
                        StudentId = student.StudentId,
                        Firstname = student.Firstname,
                        Lastname = student.Lastname,
                        Lab = availableLabs[k]
                    });
                }
            }
        }
        return queue;
    }
}
