using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdessoWorldLeagueAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrawnBy",
                table: "Draw",
                newName: "DrawnSurname");

            migrationBuilder.AddColumn<string>(
                name: "DrawnName",
                table: "Draw",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawnName",
                table: "Draw");

            migrationBuilder.RenameColumn(
                name: "DrawnSurname",
                table: "Draw",
                newName: "DrawnBy");
        }
    }
}
