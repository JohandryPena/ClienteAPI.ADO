using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.API.Migrations
{
    public partial class ClienteMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Persona_Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Persona_Edad = table.Column<int>(type: "int", nullable: true),
                    Persona_TipoIdentificacion = table.Column<int>(type: "int", nullable: true),
                    Persona_Identificacion = table.Column<int>(type: "int", nullable: true),
                    Persona_Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Persona_Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenBase64 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
