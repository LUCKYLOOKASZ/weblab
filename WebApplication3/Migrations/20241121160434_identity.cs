using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d1e58dc-06e8-4262-9039-be4678098caa", "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d41f900f-be9b-4a47-93f0-5fc25c6926f2", "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d1e58dc-06e8-4262-9039-be4678098caa", "fb20446a-460d-4ba6-8dac-e1e71dddf6fc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1e58dc-06e8-4262-9039-be4678098caa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d41f900f-be9b-4a47-93f0-5fc25c6926f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb20446a-460d-4ba6-8dac-e1e71dddf6fc");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organiztions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "user", "user" },
                    { "ee893c90-c8fb-45ba-8a81-a03618b70121", "ee893c90-c8fb-45ba-8a81-a03618b70121", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9c5dfd77-2d37-450c-8800-0c03db4dff1d", 0, "73819cc2-93a2-4dd9-b881-d9e8dc20c251", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEJ2I0udk9p3vRQ0JeupCB+n30L5o+8bVdL2VFucg8w6hvBhinxe68/xVkQ+5Wz/jXg==", null, false, "722361ad-3f16-43cb-99c7-75c707182fec", false, "user" },
                    { "eb9f44db-0b10-41e1-b59b-6e43f5c0c101", 0, "1f0f7e5a-451c-4a3f-ac2a-1578f2fb2a79", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEPgzyuNkNUwpuRexL7i59Id8SE5+wT/n4KH3JpAv+gCwE2IqaFbATB15A6VNseDpyQ==", null, false, "616124e2-cf33-42d5-8ae8-39daa4bd2876", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 21, 17, 4, 33, 543, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 21, 17, 4, 33, 543, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 21, 17, 4, 33, 543, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "9c5dfd77-2d37-450c-8800-0c03db4dff1d" },
                    { "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "eb9f44db-0b10-41e1-b59b-6e43f5c0c101" },
                    { "ee893c90-c8fb-45ba-8a81-a03618b70121", "eb9f44db-0b10-41e1-b59b-6e43f5c0c101" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "9c5dfd77-2d37-450c-8800-0c03db4dff1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4708b8c5-c743-41c3-ab78-7eeecc3e77cd", "eb9f44db-0b10-41e1-b59b-6e43f5c0c101" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee893c90-c8fb-45ba-8a81-a03618b70121", "eb9f44db-0b10-41e1-b59b-6e43f5c0c101" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4708b8c5-c743-41c3-ab78-7eeecc3e77cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee893c90-c8fb-45ba-8a81-a03618b70121");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c5dfd77-2d37-450c-8800-0c03db4dff1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb9f44db-0b10-41e1-b59b-6e43f5c0c101");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organiztions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1e58dc-06e8-4262-9039-be4678098caa", "0d1e58dc-06e8-4262-9039-be4678098caa", "user", "user" },
                    { "d41f900f-be9b-4a47-93f0-5fc25c6926f2", "d41f900f-be9b-4a47-93f0-5fc25c6926f2", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d", 0, "09701322-5e84-4580-9bc9-c32ac2537a4a", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAENiKNSybiOlWE11+gv4CSoDjF9JM8LYHCbu3j8XpcD6mOmsKHRFgEt0Uqx3WYlXVqA==", null, false, "83ee952c-112b-421c-aceb-75b03dfbd2cc", false, "admin" },
                    { "fb20446a-460d-4ba6-8dac-e1e71dddf6fc", 0, "57c3f80a-ca62-4c4f-82a5-9e3f9fe52b3d", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEOAndX8HEKWaTmd7gPLpWv5/bbGt0hHXP2nddMbN9dTAW+XxtUT6hKjNFguZdVp1lA==", null, false, "550ae61a-5efb-4a82-8031-9664da15c550", false, "user" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 29, 45, 741, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 29, 45, 741, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 19, 17, 29, 45, 741, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0d1e58dc-06e8-4262-9039-be4678098caa", "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d" },
                    { "d41f900f-be9b-4a47-93f0-5fc25c6926f2", "57c6a83d-88a8-44cd-a3ec-5ffec1de8d0d" },
                    { "0d1e58dc-06e8-4262-9039-be4678098caa", "fb20446a-460d-4ba6-8dac-e1e71dddf6fc" }
                });
        }
    }
}
