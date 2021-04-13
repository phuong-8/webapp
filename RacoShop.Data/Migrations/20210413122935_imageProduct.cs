using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RacoShop.Data.Migrations
{
    public partial class imageProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("425ac812-3905-4dc3-8958-edc00b8c4bf7"),
                column: "ConcurrencyStamp",
                value: "8691bc43-676e-4437-8ca8-0d6a4dd2b0f7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5c37570-fcdc-4993-8496-e2c50fbc2923"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79da7d58-c789-472a-ad0e-472e51127c14", "AQAAAAEAACcQAAAAEMJvg8kNxq/luwNMWjC098D0e578BCnXe3IEcDlHA+/avW9ZlhXWX2b8uBuqkcbOlg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 13, 19, 29, 34, 44, DateTimeKind.Local).AddTicks(5524));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("425ac812-3905-4dc3-8958-edc00b8c4bf7"),
                column: "ConcurrencyStamp",
                value: "65d83842-0d8e-49c4-a83b-20f6a9c48474");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5c37570-fcdc-4993-8496-e2c50fbc2923"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f7dd419-be74-423f-94a3-303b1e1f9536", "AQAAAAEAACcQAAAAEO5BJtoscDqnuhGTgjkf6WEUN9ObWl8ugkROX0pw/Ye1Ns3zZVsJ9OU+HsfIeG25CA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 12, 22, 36, 35, 937, DateTimeKind.Local).AddTicks(6016));
        }
    }
}
