using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPortBasesConfigurationWithTpcStrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<ImageData>_NodeId",
                table: "InputPort<ImageData>");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<ImageData>_NodeId",
                table: "InputPort<ImageData>",
                column: "NodeId");
        }
    }
}
