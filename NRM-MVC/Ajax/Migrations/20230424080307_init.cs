using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ajax.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Arda", "Şen" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Jane", "Doe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
