using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFromJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1a2c3d4-0000-0000-0000-000000000001", "b1a2c3d4-0000-0000-0000-000000000001", "Provider", "PROVIDER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1111111-1111-1111-1111-111111111111", 0, "a1111111-1111-1111-1111-111111111111", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "doctor@example.com", true, false, null, "Dr. John Smith", "DOCTOR@EXAMPLE.COM", "DOCTOR@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFunwxhEUCf67y45QaHmvT1evrN9sJKPzrIhN3n7ZH1QCzgKfThmmnDFzRYCxOlShw==", null, false, 0, "a1111111-1111-1111-1111-111111111111", false, "doctor@example.com" },
                    { "a2222222-2222-2222-2222-222222222222", 0, "a2222222-2222-2222-2222-222222222222", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "patient@example.com", true, false, null, "Jane Doe", "PATIENT@EXAMPLE.COM", "PATIENT@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAwZ4W7fphkqrBYznoT0oR/3K+wfmsCLjTJp9YGf04qOaMBs0eWZ8eSfM6aM9BV4oQ==", null, false, 0, "a2222222-2222-2222-2222-222222222222", false, "patient@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b1a2c3d4-0000-0000-0000-000000000001", "a1111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "a1111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApplicationUserId", "EndTime", "ProviderId", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { 2, null, new DateTime(2026, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, "a2222222-2222-2222-2222-222222222222" },
                    { 3, null, new DateTime(2026, 10, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 10, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1a2c3d4-0000-0000-0000-000000000001", "a1111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a2c3d4-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1111111-1111-1111-1111-111111111111");
        }
    }
}
