using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHang.Data.Migrations
{
    public partial class addedRecordIntoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "PlayerName", "PlayerPassword" },
                values: new object[] { 1, "Min4o-Izparitelq", "newto-newto-kodirana-parola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);
        }
    }
}
