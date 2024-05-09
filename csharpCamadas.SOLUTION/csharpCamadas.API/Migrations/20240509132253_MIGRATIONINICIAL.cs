using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpCamadas.API.Migrations
{
    public partial class MIGRATIONINICIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posto",
                columns: table => new
                {
                    pos_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pos_nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pos_cidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pos_endereco = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posto__D1A4EB1218119F5C", x => x.pos_id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    vei_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vei_nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    vei_placa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Veiculo__136D0F563BBE0B6D", x => x.vei_id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeCombustivel",
                columns: table => new
                {
                    Tipo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Tipo_valor = table.Column<double>(type: "float", nullable: true),
                    pos_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposDeC__94F920011E35D731", x => x.Tipo_id);
                    table.ForeignKey(
                        name: "FK__TiposDeCo__pos_i__2B3F6F97",
                        column: x => x.pos_id,
                        principalTable: "Posto",
                        principalColumn: "pos_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    mot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mot_nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    mot_idade = table.Column<int>(type: "int", nullable: true),
                    vei_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Motorist__E0752241BCD10E26", x => x.mot_id);
                    table.ForeignKey(
                        name: "FK__Motorista__vei_i__286302EC",
                        column: x => x.vei_id,
                        principalTable: "Veiculo",
                        principalColumn: "vei_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorista_vei_id",
                table: "Motorista",
                column: "vei_id");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeCombustivel_pos_id",
                table: "TiposDeCombustivel",
                column: "pos_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "TiposDeCombustivel");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Posto");
        }
    }
}
