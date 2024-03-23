using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentGaleria.Migrations
{
    /// <inheritdoc />
    public partial class RecreatedWithImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Fabricantes_FabricanteId",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Fabricantes_FabricanteId",
                table: "Carros",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Fabricantes_FabricanteId",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Fabricantes_FabricanteId",
                table: "Carros",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id");
        }
    }
}
