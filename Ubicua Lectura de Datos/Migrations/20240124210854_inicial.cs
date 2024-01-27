using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ubicua_Lectura_de_Datos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gx = table.Column<float>(type: "real", nullable: false),
                    gy = table.Column<float>(type: "real", nullable: false),
                    gz = table.Column<float>(type: "real", nullable: false),
                    temp = table.Column<float>(type: "real", nullable: false),
                    hum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos");
        }
    }
}
