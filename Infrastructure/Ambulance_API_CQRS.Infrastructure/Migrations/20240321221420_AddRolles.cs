using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambulance_API_CQRS.Infrastructure.Migrations
{
    public partial class AddRolles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8956552d-a26b-45ee-b261-db3fa3bbb57e", "de3b2535-35f4-4e58-a07f-6e43635ac703", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddcff849-bb96-4c51-9431-fcc660c6813f", "208b0274-eb07-4b56-8940-668fb627d663", "Dispatcher", "DISPATCHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8956552d-a26b-45ee-b261-db3fa3bbb57e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddcff849-bb96-4c51-9431-fcc660c6813f");
        }
    }
}
