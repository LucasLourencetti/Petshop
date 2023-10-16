using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petshop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    idAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tipoAnimal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.idAnimal);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicos",
                columns: table => new
                {
                    idTipoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicos", x => x.idTipoServico);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    animalId = table.Column<int>(type: "int", nullable: false),
                    idAnimal = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    TipoServicoId = table.Column<int>(type: "int", nullable: false),
                    idTipoServico = table.Column<int>(type: "int", nullable: true),
                    valorTotal = table.Column<float>(type: "real", nullable: false),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Servicos_Animais_idAnimal",
                        column: x => x.idAnimal,
                        principalTable: "Animais",
                        principalColumn: "idAnimal");
                    table.ForeignKey(
                        name: "FK_Servicos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Servicos_TipoServicos_idTipoServico",
                        column: x => x.idTipoServico,
                        principalTable: "TipoServicos",
                        principalColumn: "idTipoServico");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_idAnimal",
                table: "Servicos",
                column: "idAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_idCliente",
                table: "Servicos",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_idTipoServico",
                table: "Servicos",
                column: "idTipoServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoServicos");
        }
    }
}
