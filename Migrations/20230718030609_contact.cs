using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreEnt.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblContact",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblUserUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContact", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblContact_tblUser_tblUserUserId",
                        column: x => x.tblUserUserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblContact_tblUserUserId",
                table: "tblContact",
                column: "tblUserUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblContact");
        }
    }
}
