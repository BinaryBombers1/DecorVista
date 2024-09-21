using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorVista.Migrations
{
    /// <inheritdoc />
    public partial class Consultations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblConsultations",
                columns: table => new
                {
                    consultations_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    designer_Id = table.Column<int>(type: "int", nullable: false),
                    Scheduled_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblConsultations", x => x.consultations_id);
                    table.ForeignKey(
                        name: "FK_tblConsultations_tblDesigner_designer_Id",
                        column: x => x.designer_Id,
                        principalTable: "tblDesigner",
                        principalColumn: "designer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblConsultations_tblUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "tblUsers",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultations_designer_Id",
                table: "tblConsultations",
                column: "designer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultations_user_id",
                table: "tblConsultations",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblConsultations");
        }
    }
}
