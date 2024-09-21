using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorVista.Migrations
{
    /// <inheritdoc />
    public partial class review1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_tblDesigner_designer_Id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_tblProducts_product_id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_tblUsers_user_id",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "tblReviews");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_user_id",
                table: "tblReviews",
                newName: "IX_tblReviews_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_product_id",
                table: "tblReviews",
                newName: "IX_tblReviews_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_designer_Id",
                table: "tblReviews",
                newName: "IX_tblReviews_designer_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblReviews",
                table: "tblReviews",
                column: "Review_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReviews_tblDesigner_designer_Id",
                table: "tblReviews",
                column: "designer_Id",
                principalTable: "tblDesigner",
                principalColumn: "designer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblReviews_tblProducts_product_id",
                table: "tblReviews",
                column: "product_id",
                principalTable: "tblProducts",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblReviews_tblUsers_user_id",
                table: "tblReviews",
                column: "user_id",
                principalTable: "tblUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReviews_tblDesigner_designer_Id",
                table: "tblReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_tblReviews_tblProducts_product_id",
                table: "tblReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_tblReviews_tblUsers_user_id",
                table: "tblReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblReviews",
                table: "tblReviews");

            migrationBuilder.RenameTable(
                name: "tblReviews",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_tblReviews_user_id",
                table: "Reviews",
                newName: "IX_Reviews_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_tblReviews_product_id",
                table: "Reviews",
                newName: "IX_Reviews_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_tblReviews_designer_Id",
                table: "Reviews",
                newName: "IX_Reviews_designer_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Review_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_tblDesigner_designer_Id",
                table: "Reviews",
                column: "designer_Id",
                principalTable: "tblDesigner",
                principalColumn: "designer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_tblProducts_product_id",
                table: "Reviews",
                column: "product_id",
                principalTable: "tblProducts",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_tblUsers_user_id",
                table: "Reviews",
                column: "user_id",
                principalTable: "tblUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
