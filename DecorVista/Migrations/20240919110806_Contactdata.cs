using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorVista.Migrations
{
    /// <inheritdoc />
    public partial class Contactdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblContect_tblUsers_user_id",
                table: "tblContect");

            migrationBuilder.DropIndex(
                name: "IX_tblContect_user_id",
                table: "tblContect");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tblContect");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "tblContect",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblContect_user_id",
                table: "tblContect",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblContect_tblUsers_user_id",
                table: "tblContect",
                column: "user_id",
                principalTable: "tblUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
