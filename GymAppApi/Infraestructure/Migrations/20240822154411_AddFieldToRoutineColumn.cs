using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldToRoutineColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetExercises_Exercises_ExerciseId",
                table: "SetExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_SetExercises_Rutines_RoutineId",
                table: "SetExercises");

            migrationBuilder.DropIndex(
                name: "IX_SetExercises_ExerciseId",
                table: "SetExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rutines",
                table: "Rutines");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "SetExercises");

            migrationBuilder.RenameTable(
                name: "Rutines",
                newName: "Routines");

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routines",
                table: "Routines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetExercises_Routines_RoutineId",
                table: "SetExercises",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetExercises_Routines_RoutineId",
                table: "SetExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routines",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Routines",
                newName: "Rutines");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "SetExercises",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rutines",
                table: "Rutines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SetExercises_ExerciseId",
                table: "SetExercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetExercises_Exercises_ExerciseId",
                table: "SetExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetExercises_Rutines_RoutineId",
                table: "SetExercises",
                column: "RoutineId",
                principalTable: "Rutines",
                principalColumn: "Id");
        }
    }
}
