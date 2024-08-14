using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class fourtCreateion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8951), new DateTime(2024, 7, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8970), new DateTime(2024, 6, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",      
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8973), new DateTime(2024, 8, 11, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8978), new DateTime(2024, 8, 4, 21, 6, 36, 500, DateTimeKind.Local).AddTicks(8979) });

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6817), new DateTime(2024, 8, 4, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6826), new DateTime(2024, 8, 9, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6829), new DateTime(2024, 8, 7, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Date" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6831), new DateTime(2024, 8, 11, 21, 6, 36, 501, DateTimeKind.Local).AddTicks(6831) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
