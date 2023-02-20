namespace BFQG.Helpers;

public class PrepareLabsData
{

    //Фиксануть это ||||
    public static List<LabsStudent> Prepare(in List<LabsStudent> prepareStudent, int countEnableLabs, DbforqgsContext context)
    {
        var students = prepareStudent.ToList();
        var preparedData = new List<LabsStudent>();

        foreach (var student in students)
        {
            //Получить все сданные лабы студента
            //Проверяем какие он хочет сдавать 
            //Если все лабы идут по порядку, то всё хорошо
            //Заполняем промежуток до 1 и после -1 а всё что хочет сдавать 0 
            //Если лабы шли не по порядку, тогда добавить только доступные (которые может сдавать по очереди)

            var labs = context.Evaluations
                .Where(e => e.UserId == student.StudentId)
                .Join(context.Labs, e => e.LabId, l => l.Id, (e, l) => new { e.UserId, l.SubjectId, e.LabId, l.Number }).ToList();

            int labMax = labs.Count != 0 ? labs.Max(e => e.Number) : 0;

            if (labMax + 1 != student.Labs.Min())
                continue;

            bool inRow = true;
            int numberInRow = 0;
            for (int numb = 0, i = student.Labs[numb]; i < student.Labs.Count - student.Labs[0] - 1; numb++, i = student.Labs[numb])
            {
                if (i == numb)
                    continue;

                inRow = false;
                numberInRow = numb - 1;
            }

            int countLabHandOver = student.Labs.Count;

            if (!inRow)
                countLabHandOver = numberInRow;

            List<int> preparedLabs =
                Enumerable.Range(0, labs.Count).Select(e => 1)
                .Concat(Enumerable.Range(0, countLabHandOver).Select(e => 0))
                .Concat(Enumerable.Range(0, countEnableLabs - labs.Count - countLabHandOver).Select(e => -1)).ToList();

            preparedData.Add(new LabsStudent
            {
                StudentId = student.StudentId,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Labs = preparedLabs,
            });
        }

        return preparedData;
    }
}
