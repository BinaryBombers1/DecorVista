using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorVista.Migrations
{
    /// <inheritdoc />
    public partial class review2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReviews_tblProducts_product_id",
                table: "tblReviews");

            migrationBuilder.DropIndex(
                name: "IX_tblReviews_product_id",
                table: "tblReviews");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "tblReviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "tblReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_product_id",
                table: "tblReviews",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReviews_tblProducts_product_id",
                table: "tblReviews",
                column: "product_id",
                principalTable: "tblProducts",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
