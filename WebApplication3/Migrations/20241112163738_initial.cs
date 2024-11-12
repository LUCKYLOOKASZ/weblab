using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organiztions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organiztions", x => x.Id);
                });

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
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organiztions_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organiztions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organiztions",
                columns: new[] { "Id", "Address_City", "Address_Street", "Name", "Nip", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "Św. Filipa17", "wsei", "123123123", "1234123412341234" },
                    { 102, "Warszawa", "Złota 66", "pkp", "12389123", "123987612341234" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Category", "Created", "Email", "Name", "OrganizationId", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), 0, new DateTime(2024, 11, 12, 17, 37, 35, 483, DateTimeKind.Local).AddTicks(3724), "", "Jan", 101, "123 456 789", "Kowalski" },
                    { 2, new DateOnly(1995, 5, 5), 0, new DateTime(2024, 11, 12, 17, 37, 35, 483, DateTimeKind.Local).AddTicks(3767), "", "Anna", 101, "987 654 321", "Nowak" },
                    { 3, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 12, 17, 37, 35, 483, DateTimeKind.Local).AddTicks(3770), "", "Piotr", 102, "456 789 123", "Wiśniewski" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "organiztions");
        }
    }
}
