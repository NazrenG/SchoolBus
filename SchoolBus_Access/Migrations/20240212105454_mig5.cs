using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBus_Access.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Fullname", "BusNumber", "SeatCount" },
                values: new object[] { 1, "Bus1", "90-BS-234", 25 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName" },
                values: new object[] { 1, "681.21" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "LastName", "FirstName", "Password", "Phone", "Username" },
                values: new object[] { 1, "Quliyev", "Faiq", "1111", "050-456-55-56", "quliyev" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BusId", "LastName", "Licence", "FirstName", "Password", "Phone", "Username" },
                values: new object[] { 1, 1, "Aliyev", true, "Elmar", "1111", "050-456-65-64", "aliyev" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "BusId", "FullName" },
                values: new object[] { 1, 1, "28May" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BusId", "ClassId", "HomeAddress", "LastName", "FirstName", "ParentId" },
                values: new object[] { 1, 1, 1, "28May", "Quliyeva", "Nezrin", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
