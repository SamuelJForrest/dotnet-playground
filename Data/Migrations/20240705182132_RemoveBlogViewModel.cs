using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPlayground.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBlogViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorModifier",
                table: "Blog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorModifier",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
