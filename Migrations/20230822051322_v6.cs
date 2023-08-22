using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto_DAWA.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Productos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Categorias",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "IdCategoria");
        }
    }
}
