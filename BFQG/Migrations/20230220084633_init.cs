using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BFQG.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "action_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_action_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronomic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    accounttypeid = table.Column<int>(name: "account_type_id", type: "integer", nullable: false),
                    groupid = table.Column<int>(name: "group_id", type: "integer", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_account_type",
                        column: x => x.accounttypeid,
                        principalTable: "account_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_groups",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "labs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    authorid = table.Column<int>(name: "author_id", type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    subjectid = table.Column<int>(name: "subject_id", type: "integer", nullable: false),
                    docname = table.Column<string>(name: "doc_name", type: "character varying", nullable: true),
                    deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    maxscore = table.Column<int>(name: "max_score", type: "integer", nullable: true),
                    isvisible = table.Column<bool>(name: "is_visible", type: "boolean", nullable: false),
                    testlink = table.Column<string>(name: "test_link", type: "character varying", nullable: true),
                    number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_labs", x => x.id);
                    table.ForeignKey(
                        name: "fk_labs_subject",
                        column: x => x.subjectid,
                        principalTable: "subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_labs_users",
                        column: x => x.authorid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subjectid = table.Column<int>(name: "subject_id", type: "integer", nullable: false),
                    authoruserid = table.Column<int>(name: "author_user_id", type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    groupid = table.Column<int>(name: "group_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lessons", x => x.id);
                    table.ForeignKey(
                        name: "fk_lessons_groups",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lessons_subject",
                        column: x => x.subjectid,
                        principalTable: "subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lessons_users",
                        column: x => x.authoruserid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    actiontypeid = table.Column<int>(name: "action_type_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_logs_action_type",
                        column: x => x.actiontypeid,
                        principalTable: "action_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_logs_users_info",
                        column: x => x.userid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teacher_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacherid = table.Column<int>(name: "teacher_id", type: "integer", nullable: false),
                    groupid = table.Column<int>(name: "group_id", type: "integer", nullable: false),
                    subjectid = table.Column<int>(name: "subject_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_teacher_groups_groups",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_teacher_groups_subject",
                        column: x => x.subjectid,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_groups_users_info",
                        column: x => x.teacherid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users_authentication_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_authentication_information", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_authentication_information",
                        column: x => x.id,
                        principalTable: "users_info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    labid = table.Column<int>(name: "lab_id", type: "integer", nullable: false),
                    handoverdate = table.Column<DateOnly>(name: "hand_over_date", type: "date", nullable: false),
                    mark = table.Column<int>(type: "integer", nullable: false),
                    handovertime = table.Column<TimeOnly>(name: "hand_over_time", type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evaluations", x => x.id);
                    table.ForeignKey(
                        name: "fk_evaluations_labs",
                        column: x => x.labid,
                        principalTable: "labs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_evaluations_users",
                        column: x => x.userid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lessonid = table.Column<int>(name: "lesson_id", type: "integer", nullable: false),
                    usercount = table.Column<int>(name: "user_count", type: "integer", nullable: true),
                    createdate = table.Column<DateTime>(name: "create_date", type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "timestamp with time zone", nullable: true),
                    isclose = table.Column<bool>(name: "is_close", type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                    table.ForeignKey(
                        name: "fk_rooms_lessons",
                        column: x => x.lessonid,
                        principalTable: "lessons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "student_visits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    lessonid = table.Column<int>(name: "lesson_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_visits", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_visits_lessons",
                        column: x => x.lessonid,
                        principalTable: "lessons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_student_visits_users_info",
                        column: x => x.userid,
                        principalTable: "users_info",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "history_rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomid = table.Column<int>(name: "room_id", type: "integer", nullable: false),
                    provenlabcount = table.Column<int>(name: "proven_lab_count", type: "integer", nullable: false),
                    avgproventime = table.Column<TimeOnly>(name: "avg_proven_time", type: "time without time zone", nullable: false),
                    studentscount = table.Column<int>(name: "students_count", type: "integer", nullable: false),
                    labsjson = table.Column<string>(name: "labs_json", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_history_rooms", x => x.id);
                    table.ForeignKey(
                        name: "fk_history_rooms_rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_lab_id",
                table: "evaluations",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_user_id",
                table: "evaluations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_history_rooms_room_id",
                table: "history_rooms",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_labs_author_id",
                table: "labs",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_labs_subject_id",
                table: "labs",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_author_user_id",
                table: "lessons",
                column: "author_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_group_id",
                table: "lessons",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_subject_id",
                table: "lessons",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_logs_action_type_id",
                table: "logs",
                column: "action_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_logs_user_id",
                table: "logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_lesson_id",
                table: "rooms",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_visits_lesson_id",
                table: "student_visits",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_visits_user_id",
                table: "student_visits",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_groups_group_id",
                table: "teacher_groups",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_groups_subject_id",
                table: "teacher_groups",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_groups_teacher_id",
                table: "teacher_groups",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_info_account_type_id",
                table: "users_info",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_info_group_id",
                table: "users_info",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.DropTable(
                name: "history_rooms");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "student_visits");

            migrationBuilder.DropTable(
                name: "teacher_groups");

            migrationBuilder.DropTable(
                name: "users_authentication_info");

            migrationBuilder.DropTable(
                name: "labs");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "action_type");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "users_info");

            migrationBuilder.DropTable(
                name: "account_type");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
