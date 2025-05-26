using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CW_9.Migrations
{
    /// <inheritdoc />
    public partial class Tablesfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Patient",
                newName: "Birthdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Patient",
                newName: "Birthday");
        }
    }
}
