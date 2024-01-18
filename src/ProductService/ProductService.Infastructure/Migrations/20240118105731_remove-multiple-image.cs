using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable

namespace ProductService.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class removemultipleimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePaths",
                table: "Products",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "ImagePaths");
        }
    }
}
