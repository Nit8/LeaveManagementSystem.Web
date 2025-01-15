using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0BE0F80A-1740-4581-BAF0-AE46552A4356", null, "Administrator", "ADMIN" },
                    { "94F84E62-BAF7-4104-9E9F-72BC5C2FEC74", null, "Supervisor", "SUPERVISOR" },
                    { "AB3BE125-8C2F-4CC3-8FA7-AD89444881F1", null, " Employee", "EMPLOYEE" },
                    { "E3B865DF-FA5C-4FE7-92AA-F6E6BB54C79C", null, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3", 0, "e5567246-4026-4ce8-bf29-a058badcdb9b", "nitesh.singh1423.nl@gmail.com", true, false, null, "NITESH.SINGH1423.NL@GMAIL.COM", "NITESH.SINGH1423.NL@GMAIL.COM", "AQAAAAIAAYagAAAAENVHielltjPGgqMsht1H5vBxVAkI/wJ9hLNd82HgQsmg7UQiH1nD7hl3XfUXNvlfvQ==", null, false, "5eba4d2a-34a7-4c89-b77c-ffd2a39cfd8d", false, "nitesh.singh1423.nl@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0BE0F80A-1740-4581-BAF0-AE46552A4356", "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94F84E62-BAF7-4104-9E9F-72BC5C2FEC74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AB3BE125-8C2F-4CC3-8FA7-AD89444881F1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "E3B865DF-FA5C-4FE7-92AA-F6E6BB54C79C");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0BE0F80A-1740-4581-BAF0-AE46552A4356", "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0BE0F80A-1740-4581-BAF0-AE46552A4356");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3");
        }
    }
}
