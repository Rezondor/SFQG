﻿// <auto-generated />
using System;
using BFQG;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BFQG.Migrations
{
    [DbContext(typeof(DbforqgsContext))]
    [Migration("20230130205558_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BFQG.Entities.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_account_type");

                    b.ToTable("account_type", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.ActionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_action_type");

                    b.ToTable("action_type", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("HandOverDate")
                        .HasColumnType("date")
                        .HasColumnName("hand_over_date");

                    b.Property<TimeOnly>("HandOverTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("hand_over_time");

                    b.Property<int>("LabId")
                        .HasColumnType("integer")
                        .HasColumnName("lab_id");

                    b.Property<int>("Mark")
                        .HasColumnType("integer")
                        .HasColumnName("mark");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_evaluations");

                    b.HasIndex("LabId");

                    b.HasIndex("UserId");

                    b.ToTable("evaluations", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.HistoryRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AvgProvenTime")
                        .HasColumnType("real")
                        .HasColumnName("avg_proven_time");

                    b.Property<int>("ProvenLabCount")
                        .HasColumnType("integer")
                        .HasColumnName("proven_lab_count");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.Property<int>("StudentsCount")
                        .HasColumnType("integer")
                        .HasColumnName("students_count");

                    b.HasKey("Id")
                        .HasName("pk_history_rooms");

                    b.HasIndex("RoomId");

                    b.ToTable("history_rooms", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("DocName")
                        .HasColumnType("character varying")
                        .HasColumnName("doc_name");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean")
                        .HasColumnName("is_visible");

                    b.Property<int?>("MaxScore")
                        .HasColumnType("integer")
                        .HasColumnName("max_score");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer")
                        .HasColumnName("subject_id");

                    b.Property<string>("TestLink")
                        .HasColumnType("character varying")
                        .HasColumnName("test_link");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_labs");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("labs", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("author_user_id");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer")
                        .HasColumnName("subject_id");

                    b.HasKey("Id")
                        .HasName("pk_lessons");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("lessons", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("action_type_id");

                    b.Property<string>("Text")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_logs");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("logs", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<bool?>("IsClose")
                        .HasColumnType("boolean")
                        .HasColumnName("is_close");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer")
                        .HasColumnName("lesson_id");

                    b.Property<int?>("UserCount")
                        .HasColumnType("integer")
                        .HasColumnName("user_count");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.HasIndex("LessonId");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.StudentVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("integer")
                        .HasColumnName("lesson_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_student_visits");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("student_visits", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_subject");

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.TeacherGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id");

                    b.HasKey("Id")
                        .HasName("pk_teacher_groups");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("teacher_groups", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.UsersAuthenticationInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_user_authentication_information");

                    b.ToTable("users_authentication_info", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.UsersInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('users_id_seq'::regclass)");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("account_type_id");

                    b.Property<int?>("Course")
                        .HasColumnType("integer")
                        .HasColumnName("course");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("firstname");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("lastname");

                    b.Property<string>("Patronomic")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("patronomic");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("GroupId");

                    b.ToTable("users_info", (string)null);
                });

            modelBuilder.Entity("BFQG.Entities.Evaluation", b =>
                {
                    b.HasOne("BFQG.Entities.Lab", "Lab")
                        .WithMany("Evaluations")
                        .HasForeignKey("LabId")
                        .IsRequired()
                        .HasConstraintName("fk_evaluations_labs");

                    b.HasOne("BFQG.Entities.UsersInfo", "User")
                        .WithMany("Evaluations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_evaluations_users");

                    b.Navigation("Lab");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BFQG.Entities.HistoryRoom", b =>
                {
                    b.HasOne("BFQG.Entities.Room", "Room")
                        .WithMany("HistoryRooms")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("fk_history_rooms_rooms");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BFQG.Entities.Lab", b =>
                {
                    b.HasOne("BFQG.Entities.UsersInfo", "Author")
                        .WithMany("Labs")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("fk_labs_users");

                    b.HasOne("BFQG.Entities.Subject", "Subject")
                        .WithMany("Labs")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("fk_labs_subject");

                    b.Navigation("Author");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("BFQG.Entities.Lesson", b =>
                {
                    b.HasOne("BFQG.Entities.UsersInfo", "AuthorUser")
                        .WithMany("Lessons")
                        .HasForeignKey("AuthorUserId")
                        .IsRequired()
                        .HasConstraintName("fk_lessons_users");

                    b.HasOne("BFQG.Entities.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("fk_lessons_groups");

                    b.HasOne("BFQG.Entities.Subject", "Subject")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("fk_lessons_subject");

                    b.Navigation("AuthorUser");

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("BFQG.Entities.Log", b =>
                {
                    b.HasOne("BFQG.Entities.ActionType", "ActionType")
                        .WithMany("Logs")
                        .HasForeignKey("ActionTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_logs_action_type");

                    b.HasOne("BFQG.Entities.UsersInfo", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_logs_users_info");

                    b.Navigation("ActionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BFQG.Entities.Room", b =>
                {
                    b.HasOne("BFQG.Entities.Lesson", "Lesson")
                        .WithMany("Rooms")
                        .HasForeignKey("LessonId")
                        .IsRequired()
                        .HasConstraintName("fk_rooms_lessons");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("BFQG.Entities.StudentVisit", b =>
                {
                    b.HasOne("BFQG.Entities.Lesson", "Lesson")
                        .WithMany("StudentVisits")
                        .HasForeignKey("LessonId")
                        .IsRequired()
                        .HasConstraintName("fk_student_visits_lessons");

                    b.HasOne("BFQG.Entities.UsersInfo", "User")
                        .WithMany("StudentVisits")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_student_visits_users_info");

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BFQG.Entities.TeacherGroup", b =>
                {
                    b.HasOne("BFQG.Entities.Group", "Group")
                        .WithMany("TeacherGroups")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("fk_teacher_groups_groups");

                    b.HasOne("BFQG.Entities.UsersInfo", "Teacher")
                        .WithMany("TeacherGroups")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("fk_teacher_groups_users_info");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("BFQG.Entities.UsersAuthenticationInfo", b =>
                {
                    b.HasOne("BFQG.Entities.UsersInfo", "IdNavigation")
                        .WithOne("UsersAuthenticationInfo")
                        .HasForeignKey("BFQG.Entities.UsersAuthenticationInfo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_authentication_information");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("BFQG.Entities.UsersInfo", b =>
                {
                    b.HasOne("BFQG.Entities.AccountType", "AccountType")
                        .WithMany("UsersInfos")
                        .HasForeignKey("AccountTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_users_account_type");

                    b.HasOne("BFQG.Entities.Group", "Group")
                        .WithMany("UsersInfos")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_users_groups");

                    b.Navigation("AccountType");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BFQG.Entities.AccountType", b =>
                {
                    b.Navigation("UsersInfos");
                });

            modelBuilder.Entity("BFQG.Entities.ActionType", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("BFQG.Entities.Group", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("TeacherGroups");

                    b.Navigation("UsersInfos");
                });

            modelBuilder.Entity("BFQG.Entities.Lab", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("BFQG.Entities.Lesson", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("StudentVisits");
                });

            modelBuilder.Entity("BFQG.Entities.Room", b =>
                {
                    b.Navigation("HistoryRooms");
                });

            modelBuilder.Entity("BFQG.Entities.Subject", b =>
                {
                    b.Navigation("Labs");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("BFQG.Entities.UsersInfo", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Labs");

                    b.Navigation("Lessons");

                    b.Navigation("Logs");

                    b.Navigation("StudentVisits");

                    b.Navigation("TeacherGroups");

                    b.Navigation("UsersAuthenticationInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
