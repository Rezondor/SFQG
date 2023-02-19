using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BFQG;

public partial class DbforqgsContext : DbContext
{
    public DbforqgsContext()
    {
    }

    public DbforqgsContext(DbContextOptions<DbforqgsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<HistoryRoom> HistoryRooms { get; set; }

    public virtual DbSet<Lab> Labs { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<StudentVisit> StudentVisits { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<TeacherGroup> TeacherGroups { get; set; }

    public virtual DbSet<UsersAuthenticationInfo> UsersAuthenticationInfos { get; set; }

    public virtual DbSet<UsersInfo> UsersInfos { get; set; }

/*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dbforqgs;Username=postgres;Password=root");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_account_type");

            entity.ToTable("account_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_action_type");

            entity.ToTable("action_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(60)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_evaluations");

            entity.ToTable("evaluations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HandOverDate).HasColumnName("hand_over_date");
            entity.Property(e => e.HandOverTime).HasColumnName("hand_over_time");
            entity.Property(e => e.LabId).HasColumnName("lab_id");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lab).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.LabId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_evaluations_labs");

            entity.HasOne(d => d.User).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_evaluations_users");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_groups");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<HistoryRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_history_rooms");

            entity.ToTable("history_rooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvgProvenTime).HasColumnName("avg_proven_time");
            entity.Property(e => e.LabsJson).HasColumnName("labs_json");
            entity.Property(e => e.ProvenLabCount).HasColumnName("proven_lab_count");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StudentsCount).HasColumnName("students_count");

            entity.HasOne(d => d.Room).WithMany(p => p.HistoryRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_history_rooms_rooms");
        });

        modelBuilder.Entity<Lab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_labs");

            entity.ToTable("labs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.DocName)
                .HasColumnType("character varying")
                .HasColumnName("doc_name");
            entity.Property(e => e.IsVisible).HasColumnName("is_visible");
            entity.Property(e => e.MaxScore).HasColumnName("max_score");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TestLink)
                .HasColumnType("character varying")
                .HasColumnName("test_link");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Labs)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_labs_users");

            entity.HasOne(d => d.Subject).WithMany(p => p.Labs)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_labs_subject");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lessons");

            entity.ToTable("lessons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorUserId).HasColumnName("author_user_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.AuthorUser).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.AuthorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lessons_users");

            entity.HasOne(d => d.Group).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lessons_groups");

            entity.HasOne(d => d.Subject).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lessons_subject");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_logs");

            entity.ToTable("logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.Text)
                .HasMaxLength(250)
                .HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ActionType).WithMany(p => p.Logs)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_logs_action_type");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_logs_users_info");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_rooms");

            entity.ToTable("rooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsClose).HasColumnName("is_close");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.UserCount).HasColumnName("user_count");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rooms_lessons");
        });

        modelBuilder.Entity<StudentVisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_student_visits");

            entity.ToTable("student_visits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.StudentVisits)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_student_visits_lessons");

            entity.HasOne(d => d.User).WithMany(p => p.StudentVisits)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_student_visits_users_info");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_subject");

            entity.ToTable("subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<TeacherGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_teacher_groups");

            entity.ToTable("teacher_groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Group).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_groups_groups");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("fk_teacher_groups_subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_groups_users_info");
        });

        modelBuilder.Entity<UsersAuthenticationInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user_authentication_information");

            entity.ToTable("users_authentication_info");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.UsersAuthenticationInfo)
                .HasForeignKey<UsersAuthenticationInfo>(d => d.Id)
                .HasConstraintName("fk_user_authentication_information");
        });

        modelBuilder.Entity<UsersInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.ToTable("users_info");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('users_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(100)
                .HasColumnName("patronomic");

            entity.HasOne(d => d.AccountType).WithMany(p => p.UsersInfos)
                .HasForeignKey(d => d.AccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_account_type");

            entity.HasOne(d => d.Group).WithMany(p => p.UsersInfos)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("fk_users_groups");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
