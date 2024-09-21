using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorVista.Migrations
{
    /// <inheritdoc />
    public partial class prodreviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProd_Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProd_Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_tblProd_Review_tblProducts_product_id",
                        column: x => x.product_id,
                        principalTable: "tblProducts",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProd_Review_tblUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "tblUsers",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProd_Review_product_id",
                table: "tblProd_Review",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblProd_Review_user_id",
                table: "tblProd_Review",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProd_Review");
        }
    }
}
