using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutAndBodyMeasurementWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9711), new DateTime(2024, 7, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9721), "a3058765-ecf0-403e-9d48-08b38d4888ab" });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9729), new DateTime(2024, 6, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9730), "a3058765-ecf0-403e-9d48-08b38d4888ab" });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9732), new DateTime(2024, 8, 15, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9732), "8cee140a-65fd-495d-970b-5315a6f3e7b2" });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9737), new DateTime(2024, 8, 8, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9737), "8cee140a-65fd-495d-970b-5315a6f3e7b2" });

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7068), new DateTime(2024, 8, 8, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7072), "a3058765-ecf0-403e-9d48-08b38d4888ab" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7076), new DateTime(2024, 8, 13, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7076), "a3058765-ecf0-403e-9d48-08b38d4888ab" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7078), new DateTime(2024, 8, 11, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7079), "8cee140a-65fd-495d-970b-5315a6f3e7b2" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 8, 15, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7081), "8cee140a-65fd-495d-970b-5315a6f3e7b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(8989), new DateTime(2024, 7, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9000), null });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9007), new DateTime(2024, 6, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9008), null });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9010), new DateTime(2024, 8, 15, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9011), null });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9015), new DateTime(2024, 8, 8, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9015), null });

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6874), new DateTime(2024, 8, 8, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6878), null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6883), new DateTime(2024, 8, 13, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6884), null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6885), new DateTime(2024, 8, 11, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6885), null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date", "UserId" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6887), new DateTime(2024, 8, 15, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6887), null });
        }
    }
}
