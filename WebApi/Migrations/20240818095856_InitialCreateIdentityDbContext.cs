using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateIdentityDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    BodyFatPercentage = table.Column<float>(type: "real", nullable: false),
                    MuscleMass = table.Column<float>(type: "real", nullable: false),
                    WaistCircumference = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalCaloriesBurned = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Distance = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => new { x.WorkoutId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyMeasurements",
                columns: new[] { "Id", "BodyFatPercentage", "CreatedTime", "Date", "MuscleMass", "UserId", "WaistCircumference", "Weight" },
                values: new object[,]
                {
                    { 1, 15f, new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(8989), new DateTime(2024, 7, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9000), 35f, null, 85f, 70f },
                    { 2, 16f, new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9007), new DateTime(2024, 6, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9008), 34f, null, 87f, 68f },
                    { 3, 14f, new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9010), new DateTime(2024, 8, 15, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9011), 36f, null, 84f, 72f },
                    { 4, 13.5f, new DateTime(2024, 8, 18, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9015), new DateTime(2024, 8, 8, 12, 58, 55, 961, DateTimeKind.Local).AddTicks(9015), 35.5f, null, 83f, 71f }
                });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "CreatedTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(518), "Strength training exercises", "Strength" },
                    { 2, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(523), "Cardio exercises", "Cardio" },
                    { 3, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(524), "Flexibility exercises", "Flexibility" },
                    { 4, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(525), "Swimming exercises and styles", "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatedTime", "Date", "Duration", "Notes", "TotalCaloriesBurned", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6874), new DateTime(2024, 8, 8, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6878), 60, "Leg day workout", 500f, null },
                    { 2, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6883), new DateTime(2024, 8, 13, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6884), 45, "Upper body workout", 400f, null },
                    { 3, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6885), new DateTime(2024, 8, 11, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6885), 40, "Freestyle swimming session", 300f, null },
                    { 4, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6887), new DateTime(2024, 8, 15, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(6887), 50, "Breaststroke swimming session", 350f, null }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Description", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3233), "Lower body strength exercise", 0, "Squat" },
                    { 2, 1, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3239), "Upper body strength exercise", 2, "Bench Press" },
                    { 3, 2, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3241), "Cardio exercise", 2, "Running" },
                    { 4, 2, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3242), "Front crawl swimming style", 1, "Freestyle Swimming" },
                    { 5, 2, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3243), "Breaststroke swimming style", 2, "Breaststroke Swimming" },
                    { 6, 1, new DateTime(2024, 8, 18, 12, 58, 55, 962, DateTimeKind.Local).AddTicks(3244), "Lower body and back strength exercise", 3, "Deadlift" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_Date_Weight",
                table: "BodyMeasurements",
                columns: new[] { "Date", "Weight" });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_UserId",
                table: "BodyMeasurements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Name",
                table: "Exercises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
