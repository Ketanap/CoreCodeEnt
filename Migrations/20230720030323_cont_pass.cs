using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreEnt.Migrations
{
    /// <inheritdoc />
    public partial class cont_pass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tblContact",
                newName: "Contact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "tblContact",
                newName: "Password");
        }
    }
}
