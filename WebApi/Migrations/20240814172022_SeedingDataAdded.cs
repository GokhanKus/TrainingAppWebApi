using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercise",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

			migrationBuilder.Sql("ALTER TABLE BodyMeasurements ADD CONSTRAINT CK_BodyMeasurement_Weight CHECK (Weight > 0)");
            migrationBuilder.InsertData(
                table: "BodyMeasurements",
                columns: new[] { "Id", "BodyFatPercentage", "CreatedTime", "Date", "MuscleMass", "WaistCircumference", "Weight" },
                values: new object[,]
                {
                    { 1, 15f, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(964), new DateTime(2024, 7, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(974), 35f, 85f, 70f },
                    { 2, 16f, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(982), new DateTime(2024, 6, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(982), 34f, 87f, 68f },
                    { 3, 14f, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(984), new DateTime(2024, 8, 11, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(985), 36f, 84f, 72f },
                    { 4, 13.5f, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(991), new DateTime(2024, 8, 4, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(991), 35.5f, 83f, 71f }
                });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "CreatedTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2321), "Strength training exercises", "Strength" },
                    { 2, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2325), "Cardio exercises", "Cardio" },
                    { 3, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2326), "Flexibility exercises", "Flexibility" },
                    { 4, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(2327), "Swimming exercises and styles", "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatedTime", "Date", "Duration", "Notes", "TotalCaloriesBurned" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 8, 4, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8361), 60, "Leg day workout", 500f },
                    { 2, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8412), new DateTime(2024, 8, 9, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8412), 45, "Upper body workout", 400f },
                    { 3, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8415), new DateTime(2024, 8, 7, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8415), 40, "Freestyle swimming session", 300f },
                    { 4, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8417), new DateTime(2024, 8, 11, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(8417), 50, "Breaststroke swimming session", 350f }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Description", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6036), "Lower body strength exercise", 0, "Squat" },
                    { 2, 1, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6042), "Upper body strength exercise", 2, "Bench Press" },
                    { 3, 2, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6044), "Cardio exercise", 2, "Running" },
                    { 4, 2, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6045), "Front crawl swimming style", 1, "Freestyle Swimming" },
                    { 5, 2, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6046), "Breaststroke swimming style", 2, "Breaststroke Swimming" },
                    { 6, 1, new DateTime(2024, 8, 14, 20, 20, 21, 578, DateTimeKind.Local).AddTicks(6048), "Lower body and back strength exercise", 3, "Deadlift" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "ExerciseId", "WorkoutId", "Distance", "Reps", "Sets", "Weight" },
                values: new object[,]
                {
                    { 1, 1, null, 10, 4, 80f },
                    { 3, 1, 5f, null, null, null },
                    { 2, 2, null, 12, 3, 60f },
                    { 4, 3, 1.5f, null, null, null },
                    { 5, 4, 2f, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Name",
                table: "Exercise",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_Date_Weight",
                table: "BodyMeasurements",
                columns: new[] { "Date", "Weight" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exercise_Name",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_BodyMeasurements_Date_Weight",
                table: "BodyMeasurements");

            migrationBuilder.DeleteData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2);

			migrationBuilder.Sql("ALTER TABLE BodyMeasurements DROP CONSTRAINT CK_BodyMeasurement_Weight");
			migrationBuilder.DeleteData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Exercise");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
