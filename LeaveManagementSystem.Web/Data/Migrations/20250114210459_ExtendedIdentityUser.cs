using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a111c29-4699-4119-8e65-190e5441be1d", new DateOnly(1998, 5, 4), "Nitesh", "Singh", "AQAAAAIAAYagAAAAEElwV+diYXVx/Ig25SPIhLJNcois+EgijMlRZ4075SnrNO/V0ytyKgtlghH31W+J8A==", "95079d5e-3104-46e0-92e1-faa770b9afd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5567246-4026-4ce8-bf29-a058badcdb9b", "AQAAAAIAAYagAAAAENVHielltjPGgqMsht1H5vBxVAkI/wJ9hLNd82HgQsmg7UQiH1nD7hl3XfUXNvlfvQ==", "5eba4d2a-34a7-4c89-b77c-ffd2a39cfd8d" });
        }
    }
}
