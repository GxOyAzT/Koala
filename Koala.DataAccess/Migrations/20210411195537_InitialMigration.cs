using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Koala.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalModels_ContactModels_ContactModelId",
                        column: x => x.ContactModelId,
                        principalTable: "ContactModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipalModels_PersonModels_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentModels_ContactModels_ContactModelId",
                        column: x => x.ContactModelId,
                        principalTable: "ContactModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentModels_PersonModels_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherModels_ContactModels_ContactModelId",
                        column: x => x.ContactModelId,
                        principalTable: "ContactModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherModels_PersonModels_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupModels_SemesterModels_SemesterModelId",
                        column: x => x.SemesterModelId,
                        principalTable: "SemesterModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudentModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudentModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupStudentModels_GroupModels_GroupModelId",
                        column: x => x.GroupModelId,
                        principalTable: "GroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupStudentModels_StudentModels_StudentModelId",
                        column: x => x.StudentModelId,
                        principalTable: "StudentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectGroupModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroupModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectGroupModels_GroupModels_GroupModelId",
                        column: x => x.GroupModelId,
                        principalTable: "GroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectGroupModels_SubjectModels_SubjectModelId",
                        column: x => x.SubjectModelId,
                        principalTable: "SubjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectGroupTeacherModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectGroupModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroupTeacherModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectGroupTeacherModels_SubjectGroupModels_SubjectGroupModelId",
                        column: x => x.SubjectGroupModelId,
                        principalTable: "SubjectGroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectGroupTeacherModels_TeacherModels_TeacherModelId",
                        column: x => x.TeacherModelId,
                        principalTable: "TeacherModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeTitleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectGroupTeacherModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeTitleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeTitleModels_SubjectGroupTeacherModels_SubjectGroupTeacherModelId",
                        column: x => x.SubjectGroupTeacherModelId,
                        principalTable: "SubjectGroupTeacherModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeTitleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeModels_GradeTitleModels_GradeTitleModelId",
                        column: x => x.GradeTitleModelId,
                        principalTable: "GradeTitleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeModels_StudentModels_StudentModelId",
                        column: x => x.StudentModelId,
                        principalTable: "StudentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeModels_GradeTitleModelId",
                table: "GradeModels",
                column: "GradeTitleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModels_StudentModelId",
                table: "GradeModels",
                column: "StudentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeTitleModels_SubjectGroupTeacherModelId",
                table: "GradeTitleModels",
                column: "SubjectGroupTeacherModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupModels_SemesterModelId",
                table: "GroupModels",
                column: "SemesterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudentModels_GroupModelId",
                table: "GroupStudentModels",
                column: "GroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudentModels_StudentModelId",
                table: "GroupStudentModels",
                column: "StudentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalModels_ContactModelId",
                table: "PrincipalModels",
                column: "ContactModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalModels_PersonModelId",
                table: "PrincipalModels",
                column: "PersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModels_ContactModelId",
                table: "StudentModels",
                column: "ContactModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModels_PersonModelId",
                table: "StudentModels",
                column: "PersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupModels_GroupModelId",
                table: "SubjectGroupModels",
                column: "GroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupModels_SubjectModelId",
                table: "SubjectGroupModels",
                column: "SubjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupTeacherModels_SubjectGroupModelId",
                table: "SubjectGroupTeacherModels",
                column: "SubjectGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupTeacherModels_TeacherModelId",
                table: "SubjectGroupTeacherModels",
                column: "TeacherModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherModels_ContactModelId",
                table: "TeacherModels",
                column: "ContactModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherModels_PersonModelId",
                table: "TeacherModels",
                column: "PersonModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeModels");

            migrationBuilder.DropTable(
                name: "GroupStudentModels");

            migrationBuilder.DropTable(
                name: "PrincipalModels");

            migrationBuilder.DropTable(
                name: "GradeTitleModels");

            migrationBuilder.DropTable(
                name: "StudentModels");

            migrationBuilder.DropTable(
                name: "SubjectGroupTeacherModels");

            migrationBuilder.DropTable(
                name: "SubjectGroupModels");

            migrationBuilder.DropTable(
                name: "TeacherModels");

            migrationBuilder.DropTable(
                name: "GroupModels");

            migrationBuilder.DropTable(
                name: "SubjectModels");

            migrationBuilder.DropTable(
                name: "ContactModels");

            migrationBuilder.DropTable(
                name: "PersonModels");

            migrationBuilder.DropTable(
                name: "SemesterModels");
        }
    }
}
