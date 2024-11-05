using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Category", "Created", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), 0, new DateTime(2024, 11, 5, 18, 12, 41, 795, DateTimeKind.Local).AddTicks(1252), "", "Jan", "123 456 789", "Kowalski" },
                    { 2, new DateOnly(1995, 5, 5), 0, new DateTime(2024, 11, 5, 18, 12, 41, 795, DateTimeKind.Local).AddTicks(1305), "", "Anna", "987 654 321", "Nowak" },
                    { 3, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 5, 18, 12, 41, 795, DateTimeKind.Local).AddTicks(1310), "", "Piotr", "456 789 123", "Wiśniewski" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
