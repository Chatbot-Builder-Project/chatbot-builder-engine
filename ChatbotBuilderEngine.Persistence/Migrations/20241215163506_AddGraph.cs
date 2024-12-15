using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "StaticNode<TextData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "StaticNode<OptionData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "StaticNode<ImageData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "PromptNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "OutputPort<TextData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "OutputPort<OptionData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "OutputPort<ImageData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "InteractionNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "InputPort<TextData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "InputPort<OptionData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "InputPort<ImageData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "FlowLink",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "Enum",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "DataLink",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Graph",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graph", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_GraphId",
                table: "SwitchNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<TextData>_GraphId",
                table: "StaticNode<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<OptionData>_GraphId",
                table: "StaticNode<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<ImageData>_GraphId",
                table: "StaticNode<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptNode_GraphId",
                table: "PromptNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_GraphId",
                table: "OutputPort<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_GraphId",
                table: "OutputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_GraphId",
                table: "OutputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_GraphId",
                table: "InteractionNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_GraphId",
                table: "InputPort<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_GraphId",
                table: "InputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<ImageData>_GraphId",
                table: "InputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowLink_GraphId",
                table: "FlowLink",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Enum_GraphId",
                table: "Enum",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_DataLink_GraphId",
                table: "DataLink",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Graph_StartNodeId",
                table: "Graph",
                column: "StartNodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataLink_Graph_GraphId",
                table: "DataLink",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enum_Graph_GraphId",
                table: "Enum",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowLink_Graph_GraphId",
                table: "FlowLink",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<ImageData>_Graph_GraphId",
                table: "InputPort<ImageData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<OptionData>_Graph_GraphId",
                table: "InputPort<OptionData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_Graph_GraphId",
                table: "InputPort<TextData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionNode_Graph_GraphId",
                table: "InteractionNode",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<ImageData>_Graph_GraphId",
                table: "OutputPort<ImageData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_Graph_GraphId",
                table: "OutputPort<OptionData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_Graph_GraphId",
                table: "OutputPort<TextData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromptNode_Graph_GraphId",
                table: "PromptNode",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<ImageData>_Graph_GraphId",
                table: "StaticNode<ImageData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<OptionData>_Graph_GraphId",
                table: "StaticNode<OptionData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<TextData>_Graph_GraphId",
                table: "StaticNode<TextData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SwitchNode_Graph_GraphId",
                table: "SwitchNode",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<TextData>",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataLink_Graph_GraphId",
                table: "DataLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Enum_Graph_GraphId",
                table: "Enum");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowLink_Graph_GraphId",
                table: "FlowLink");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<ImageData>_Graph_GraphId",
                table: "InputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_Graph_GraphId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_Graph_GraphId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionNode_Graph_GraphId",
                table: "InteractionNode");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<ImageData>_Graph_GraphId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_Graph_GraphId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_Graph_GraphId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_PromptNode_Graph_GraphId",
                table: "PromptNode");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<ImageData>_Graph_GraphId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<OptionData>_Graph_GraphId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<TextData>_Graph_GraphId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_SwitchNode_Graph_GraphId",
                table: "SwitchNode");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_SwitchNode_GraphId",
                table: "SwitchNode");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<TextData>_GraphId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<OptionData>_GraphId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<ImageData>_GraphId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_PromptNode_GraphId",
                table: "PromptNode");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<TextData>_GraphId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<OptionData>_GraphId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<ImageData>_GraphId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_InteractionNode_GraphId",
                table: "InteractionNode");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_GraphId",
                table: "InputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_GraphId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<ImageData>_GraphId",
                table: "InputPort<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_FlowLink_GraphId",
                table: "FlowLink");

            migrationBuilder.DropIndex(
                name: "IX_Enum_GraphId",
                table: "Enum");

            migrationBuilder.DropIndex(
                name: "IX_DataLink_GraphId",
                table: "DataLink");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "SwitchNode");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "PromptNode");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "InteractionNode");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "InputPort<TextData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "InputPort<ImageData>");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "FlowLink");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "Enum");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "DataLink");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<ImageData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<OptionData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<TextData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
