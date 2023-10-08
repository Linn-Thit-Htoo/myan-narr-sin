using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyanNarrSinApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
