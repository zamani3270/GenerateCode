using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenerateCode.Repository.Migrations
{
    /// <inheritdoc />
    public partial class GenerateCodePrj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RequestLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsURLRequested = table.Column<bool>(type: "bit", nullable: false),
                    RequestContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URLInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "URLInfo",
                schema: "dbo");
        }
    }
}
