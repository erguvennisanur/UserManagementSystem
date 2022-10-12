using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementData.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1,1"),
                    firstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activepassive = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                }) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
