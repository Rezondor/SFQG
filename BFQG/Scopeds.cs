namespace BFQG;

public class Scopeds
{
    public static void Add(IServiceCollection? Services)
    {
        Services.AddScoped<IBaseRepository<AccountType>, AccountTypeRepository>();
        Services.AddScoped<IBaseRepository<ActionType>, ActionTypeRepository>();
        Services.AddScoped<IBaseRepository<Evaluation>, EvaluationRepository>();
        Services.AddScoped<IBaseRepository<Group>, GroupRepository>();
        Services.AddScoped<IBaseRepository<HistoryRoom>, HistoryRoomRepository>();
        Services.AddScoped<IBaseRepository<Lab>, LabRepository>();
        Services.AddScoped<IBaseRepository<Lesson>, LessonRepository>();
        Services.AddScoped<IBaseRepository<Log>, LogRepository>();
        Services.AddScoped<IBaseRepository<Room>, RoomRepository>();
        Services.AddScoped<IBaseRepository<StudentVisit>, StudentVisitRepository>();
        Services.AddScoped<IBaseRepository<Subject>, SubjectRepository>();
        Services.AddScoped<IBaseRepository<TeacherGroup>, TeacherGroupSubjectRepository>();
        Services.AddScoped<IBaseRepository<UserModel>, UserRepository>();

        Services.AddScoped<IAccountService, AccountService>();
        Services.AddScoped<IActionRoomRepository, ActionRoomRepository>();
        Services.AddScoped<IRoomsService, RoomsService>();
        Services.AddScoped<IMarkService, MarkService>();
    }
}
