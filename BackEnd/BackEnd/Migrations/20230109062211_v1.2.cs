using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuestionario_Usuarios_UsuarioId",
                table: "Cuestionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Cuestionario_CuestionarioId",
                table: "Pregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Pregunta_PreguntaId",
                table: "Pregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Pregunta_PreguntaId",
                table: "Pregunta");

            migrationBuilder.DropColumn(
                name: "PreguntaId",
                table: "Pregunta");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntaId",
                table: "Respuesta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "Pregunta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Cuestionario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Cuestionario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Cuestionario",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "RespuestaCuestionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreParticipante = table.Column<string>(type: "varchar(100)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<int>(type: "int", nullable: false),
                    CuestionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaCuestionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaCuestionarios_Cuestionario_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaCuestionarioDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespuestaCuestionarioId = table.Column<int>(type: "int", nullable: false),
                    RespuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaCuestionarioDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                        column: x => x.RespuestaId,
                        principalTable: "Respuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaCuestionarioDetalles_RespuestaCuestionarios_RespuestaCuestionarioId",
                        column: x => x.RespuestaCuestionarioId,
                        principalTable: "RespuestaCuestionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaCuestionarioDetalles_RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaCuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaCuestionarioDetalles_RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaCuestionarios_CuestionarioId",
                table: "RespuestaCuestionarios",
                column: "CuestionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuestionario_Usuarios_UsuarioId",
                table: "Cuestionario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregunta_Cuestionario_CuestionarioId",
                table: "Pregunta",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuestionario_Usuarios_UsuarioId",
                table: "Cuestionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregunta_Cuestionario_CuestionarioId",
                table: "Pregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta");

            migrationBuilder.DropTable(
                name: "RespuestaCuestionarioDetalles");

            migrationBuilder.DropTable(
                name: "RespuestaCuestionarios");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntaId",
                table: "Respuesta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "Pregunta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreguntaId",
                table: "Pregunta",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Cuestionario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Cuestionario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Cuestionario",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_PreguntaId",
                table: "Pregunta",
                column: "PreguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuestionario_Usuarios_UsuarioId",
                table: "Cuestionario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregunta_Cuestionario_CuestionarioId",
                table: "Pregunta",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregunta_Pregunta_PreguntaId",
                table: "Pregunta",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
