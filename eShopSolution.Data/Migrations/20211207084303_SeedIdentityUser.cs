using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("20efd516-f16c-41b3-b11d-bc908cd20565"), "23de39b0-d6f4-42f8-bf3a-03984f3ecc11", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("20efd516-f16c-41b3-b11d-bc908cd20565"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae26cf") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae26cf"), 0, "a44eda75-483c-4315-bd50-b59e5573b5ea", new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "doanvuhoainam15@gmail.com", true, "Toan", "Bach", false, null, "doanvuhoainam15@gmail.com", "admin", "AQAAAAEAACcQAAAAEIltM1RKSP24y+ChBtKCUNZrp7bAyMLop5lBUIxAL5oqFu4pp5GORHiWdhU8R51Q3g==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 12, 7, 15, 43, 2, 615, DateTimeKind.Local).AddTicks(4987));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("20efd516-f16c-41b3-b11d-bc908cd20565"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("20efd516-f16c-41b3-b11d-bc908cd20565"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae26cf") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae26cf"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 12, 7, 15, 21, 34, 683, DateTimeKind.Local).AddTicks(2731));
        }
    }
}
