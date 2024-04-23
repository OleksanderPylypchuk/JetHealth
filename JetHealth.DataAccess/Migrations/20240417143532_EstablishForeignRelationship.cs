using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class EstablishForeignRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Treatments_TreatmentDescriptionId",
                table: "Treatments");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TreatmentDescriptionId",
                table: "Treatments",
                column: "TreatmentDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TDescriptions_Treatments_TreatmentId",
                table: "TDescriptions",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDescriptions_Treatments_TreatmentId",
                table: "TDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_TreatmentDescriptionId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_TDescriptions_TreatmentId",
                table: "TDescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TreatmentDescriptionId",
                table: "Treatments",
                column: "TreatmentDescriptionId",
                unique: true,
                filter: "[TreatmentDescriptionId] IS NOT NULL");
        }
    }
}
