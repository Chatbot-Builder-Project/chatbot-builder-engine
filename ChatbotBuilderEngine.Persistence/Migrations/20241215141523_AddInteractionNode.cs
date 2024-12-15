using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInteractionNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.CreateTable(
                name: "InteractionNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputEnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionNode_Enum_OutputEnumId",
                        column: x => x.OutputEnumId,
                        principalTable: "Enum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InteractionInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option_EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Option_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                        column: x => x.InteractionNodeId,
                        principalTable: "InteractionNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InteractionInput_InteractionNodeId",
                table: "InteractionInput",
                column: "InteractionNodeId",
                unique: true,
                filter: "[InteractionNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_OutputEnumId",
                table: "InteractionNode",
                column: "OutputEnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_InteractionNode_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_InteractionNode_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropTable(
                name: "InteractionInput");

            migrationBuilder.DropTable(
                name: "InteractionNode");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId");
        }
    }
}
