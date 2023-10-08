using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyanNarrSinApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
