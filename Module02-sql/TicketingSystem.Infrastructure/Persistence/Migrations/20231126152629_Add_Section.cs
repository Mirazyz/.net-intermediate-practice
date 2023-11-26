using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Section : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Manifest_ManifestId",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "ManifestId",
                table: "Seat",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ManifestId",
                table: "Seat",
                newName: "IX_Seat_SectionId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManifestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Manifest_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_ManifestId",
                table: "Section",
                column: "ManifestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Section_SectionId",
                table: "Seat",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Section_SectionId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Seat",
                newName: "ManifestId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SectionId",
                table: "Seat",
                newName: "IX_Seat_ManifestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Manifest_ManifestId",
                table: "Seat",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
