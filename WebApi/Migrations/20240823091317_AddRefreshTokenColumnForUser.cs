using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenColumnForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 204, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 205, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 205, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 205, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 23, 12, 13, 16, 205, DateTimeKind.Local).AddTicks(1160));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
        }
    }
}
