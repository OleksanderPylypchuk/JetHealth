using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class relationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId");
        }
    }
}
