using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Manifest_Venue_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manifest_VenueId",
                table: "Manifest");

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_VenueId",
                table: "Manifest",
                column: "VenueId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manifest_VenueId",
                table: "Manifest");

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_VenueId",
                table: "Manifest",
                column: "VenueId");
        }
    }
}
