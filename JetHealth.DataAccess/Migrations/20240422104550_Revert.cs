using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class Revert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDescriptions_Treatments_TreatmentId",
                table: "TDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TDescriptions_Treatments_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
