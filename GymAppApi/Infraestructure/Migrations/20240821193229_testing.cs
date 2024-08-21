using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseRoutine");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SetExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdRoutine = table.Column<int>(type: "INTEGER", nullable: false),
                    IdExercise = table.Column<int>(type: "INTEGER", nullable: false),
                    Set = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: true),
                    RoutineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SetExercises_Rutines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Rutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetExercises_ExerciseId",
                table: "SetExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_SetExercises_RoutineId",
                table: "SetExercises",
                column: "RoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetExercises");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "ExerciseRoutine",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    RutineListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRoutine", x => new { x.ExercisesId, x.RutineListId });
                    table.ForeignKey(
                        name: "FK_ExerciseRoutine_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseRoutine_Rutines_RutineListId",
                        column: x => x.RutineListId,
                        principalTable: "Rutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRoutine_RutineListId",
                table: "ExerciseRoutine",
                column: "RutineListId");
        }
    }
}
