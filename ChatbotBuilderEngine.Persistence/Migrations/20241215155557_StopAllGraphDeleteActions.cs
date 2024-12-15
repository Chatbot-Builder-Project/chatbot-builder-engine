using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StopAllGraphDeleteActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_SwitchNode_Enum_EnumId",
                table: "SwitchNode");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                principalTable: "SwitchNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                principalTable: "StaticNode<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "StaticNode<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "StaticNode<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SwitchNode_Enum_EnumId",
                table: "SwitchNode",
                column: "EnumId",
                principalTable: "Enum",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_SwitchNode_Enum_EnumId",
                table: "SwitchNode");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                principalTable: "SwitchNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                principalTable: "StaticNode<ImageData>",
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
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "StaticNode<OptionData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "StaticNode<TextData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SwitchNode_Enum_EnumId",
                table: "SwitchNode",
                column: "EnumId",
                principalTable: "Enum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
