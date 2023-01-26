using Homework5.DB;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Homework5.Migrations
{
	[DbContext(typeof(DBContext))]
	[Migration("20230118152500_Init")]
	public class Initial_Create : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Directors",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table => { table.PrimaryKey("PK_Directors", x => x.Id); });

			migrationBuilder.CreateTable(
				name: "Schools",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Number = table.Column<int>(type: "int", nullable: false),
					DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Schools", x => x.Id);
				});
			migrationBuilder.AddForeignKey(
				name: "FK_Schools_Directors_DirectorId",
				table: "Schools",
				column: "DirectorId",
				principalTable: "Directors",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.CreateTable(
				name: "Teachers",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Teachers", x => x.Id);
					
				});

			migrationBuilder.AddForeignKey(
				name: "Fk_Teachers_Schools_SchoolId",
				table: "Teachers",
				column: "SchoolId",
				principalTable: "Schools",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.CreateTable(name: "Classes",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					number = table.Column<int>(type: "int", nullable: false),
					liter = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Classes", x => x.Id);
				});

			migrationBuilder.AddForeignKey(
				name: "Fk_Clases_Schools_SchoolId",
				table: "Classes",
				column: "SchoolId",
				principalTable: "Schools",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "Fk_Clases_Teachers_TeacherId",
				table: "Classes",
				column: "TeacherId",
				principalTable: "Teachers",
				principalColumn: "Id",
				onDelete: ReferentialAction.NoAction);

			migrationBuilder.CreateTable(name: "ClassesTeachers",
				columns: table => new
				{
					TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.ForeignKey(
						name: "FK_ClassesTeachers_Teachers_TeacherId",
						column: x => x.TeacherId,
						principalTable: "Teachers",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_ClassesTeachers_Classes_TeacherId",
						column: x => x.ClassId,
						principalTable: "Classes",
						principalColumn: "Id");
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Classes");

			migrationBuilder.DropTable(
				name: "Teachers");

			migrationBuilder.DropTable(
				name: "Schools");

			migrationBuilder.DropTable(
				name: "Directors");
		}
	}
}
