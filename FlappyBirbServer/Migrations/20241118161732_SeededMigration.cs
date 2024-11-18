using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlappyBirbServer.Migrations
{
    /// <inheritdoc />
    public partial class SeededMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1d89785-ccad-404b-b96a-6722f3b1a4a0", "AQAAAAIAAYagAAAAEFy0O3EXFgpDVxRWicv7cBwjYDspac9mnYuL5FTH+d5GF5QJBfWc8VenwjNBACZiUg==", "1c5b8a83-b56d-411a-ae51-8749c0075657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7fd6ebd-58b2-412a-bb25-b1fdd6781056", "AQAAAAIAAYagAAAAEMbDO8Sz/g0vm0XGcL4oLc9CD683IBsGbB/EGdLu6oFwFdgsuSQ+MDvbkIANZBze0w==", "9a4a6a41-a1fd-453f-960b-5e5d0c5b4d7e" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "ScoreValue" },
                values: new object[] { "2024-11-18", 100 });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "UserId" },
                values: new object[] { "2024-11-18", "user", 200, "2" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-18", true, "player1", 150, "15" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-18", false, "player2", 250, "25", "2" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-18", true, "player3", 300, "30" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-18", false, "player4", 350, "35", "2" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-18", "player5", 400, "40" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-18", "player6", 450, "45", "2" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-18", "player7", 500, "50" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a34dfe52-6c47-4b64-be82-a5d63d7f7556", "AQAAAAIAAYagAAAAEFSkaROh/ondGfDHMxPScuUut+jgyp5/6mtzxpj/gmNutZQiVWIojAf7ULAY6y1lJA==", "91cc7343-2709-499e-8ead-cfd2546a8176" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34aa205b-aab0-4489-9f6a-472f6c6f2018", "AQAAAAIAAYagAAAAELkqEs2myuE3Ilb8E/3evRwB3wNzIRFJv7FsVgiuERQuvo8KpyxMUtRzOXzq1zO+NQ==", "20a19876-904e-47e8-9624-e701950e5655" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "ScoreValue" },
                values: new object[] { "2024-11-17", 10 });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "UserId" },
                values: new object[] { "2024-11-17", "admin", 20, "1" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-17", false, "admin", 30, "30" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-17", true, "admin", 40, "40", "1" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-17", false, "admin", 50, "50" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-17", true, "admin", 60, "60", "1" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-17", "admin", 70, "70" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[] { "2024-11-17", "admin", 80, "80", "1" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Pseudo", "ScoreValue", "TimeInSeconds" },
                values: new object[] { "2024-11-17", "admin", 90, "90" });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "Date", "IsPublic", "Pseudo", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[,]
                {
                    { 10, "2024-11-17", true, "admin", 100, "100", "1" },
                    { 11, "2024-11-17", true, "user", 10, "10", "2" },
                    { 12, "2024-11-17", false, "user", 20, "20", "2" },
                    { 13, "2024-11-17", true, "user", 30, "30", "2" }
                });
        }
    }
}
