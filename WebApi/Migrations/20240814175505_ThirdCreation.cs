using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseCategories_CategoryId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Exercise_ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_Name",
                table: "Exercises",
                newName: "IX_Exercises_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_CategoryId",
                table: "Exercises",
                newName: "IX_Exercises_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(8986), new DateTime(2024, 7, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9003), new DateTime(2024, 6, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9005), new DateTime(2024, 8, 11, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9010), new DateTime(2024, 8, 4, 20, 55, 4, 735, DateTimeKind.Local).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5146), new DateTime(2024, 8, 4, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5154), new DateTime(2024, 8, 9, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5156), new DateTime(2024, 8, 7, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5158), new DateTime(2024, 8, 11, 20, 55, 4, 736, DateTimeKind.Local).AddTicks(5158) });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategories_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategories_CategoryId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_Name",
                table: "Exercise",
                newName: "IX_Exercise_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercise",
                newName: "IX_Exercise_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(964), new DateTime(2024, 7, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(982), new DateTime(2024, 6, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(982) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(984), new DateTime(2024, 8, 11, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(985) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(991), new DateTime(2024, 8, 4, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 8, 4, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8412), new DateTime(2024, 8, 9, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8415), new DateTime(2024, 8, 7, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8417), new DateTime(2024, 8, 11, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8417) });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseCategories_CategoryId",
                table: "Exercise",
                column: "CategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Exercise_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
