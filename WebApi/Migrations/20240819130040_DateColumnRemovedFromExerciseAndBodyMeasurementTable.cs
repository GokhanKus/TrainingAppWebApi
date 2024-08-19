using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DateColumnRemovedFromExerciseAndBodyMeasurementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BodyMeasurements_Date_Weight",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BodyMeasurements");

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 19, 16, 0, 40, 435, DateTimeKind.Local).AddTicks(8161));

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_Weight",
                table: "BodyMeasurements",
                column: "Weight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BodyMeasurements_Weight",
                table: "BodyMeasurements");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BodyMeasurements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9711), new DateTime(2024, 7, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9721) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9729), new DateTime(2024, 6, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9732), new DateTime(2024, 8, 15, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9737), new DateTime(2024, 8, 8, 13, 6, 29, 79, DateTimeKind.Local).AddTicks(9737) });

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
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7068), new DateTime(2024, 8, 8, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7076), new DateTime(2024, 8, 13, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7078), new DateTime(2024, 8, 11, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 8, 15, 13, 6, 29, 80, DateTimeKind.Local).AddTicks(7081) });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_Date_Weight",
                table: "BodyMeasurements",
                columns: new[] { "Date", "Weight" });
        }
    }
}
