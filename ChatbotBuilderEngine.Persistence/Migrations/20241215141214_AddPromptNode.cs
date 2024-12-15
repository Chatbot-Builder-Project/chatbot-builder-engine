using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPromptNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromptNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Template_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjectedTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptNode", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_PromptNode_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_PromptNode_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropTable(
                name: "PromptNode");
        }
    }
}
