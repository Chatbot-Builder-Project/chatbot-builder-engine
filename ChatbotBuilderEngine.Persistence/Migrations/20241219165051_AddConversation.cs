using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddConversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                table: "InteractionInput");

            migrationBuilder.AddColumn<Guid>(
                name: "InputMessageId",
                table: "InteractionInput",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatbotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversation_Chatbot_ChatbotId",
                        column: x => x.ChatbotId,
                        principalTable: "Chatbot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputMessage_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputMessage_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionOutput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextOutput_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextExpected = table.Column<bool>(type: "bit", nullable: false),
                    OptionExpected = table.Column<bool>(type: "bit", nullable: false),
                    ExpectedOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    OutputMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionOutput_OutputMessage_OutputMessageId",
                        column: x => x.OutputMessageId,
                        principalTable: "OutputMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InteractionInput_InputMessageId",
                table: "InteractionInput",
                column: "InputMessageId",
                unique: true,
                filter: "[InputMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Graph_ConversationId",
                table: "Graph",
                column: "ConversationId",
                unique: true,
                filter: "[ConversationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_ChatbotId",
                table: "Conversation",
                column: "ChatbotId");

            migrationBuilder.CreateIndex(
                name: "IX_InputMessage_ConversationId",
                table: "InputMessage",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionOutput_OutputMessageId",
                table: "InteractionOutput",
                column: "OutputMessageId",
                unique: true,
                filter: "[OutputMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutputMessage_ConversationId",
                table: "OutputMessage",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Conversation_ConversationId",
                table: "Graph",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionInput_InputMessage_InputMessageId",
                table: "InteractionInput",
                column: "InputMessageId",
                principalTable: "InputMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                table: "InteractionInput",
                column: "InteractionNodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Conversation_ConversationId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionInput_InputMessage_InputMessageId",
                table: "InteractionInput");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                table: "InteractionInput");

            migrationBuilder.DropTable(
                name: "InputMessage");

            migrationBuilder.DropTable(
                name: "InteractionOutput");

            migrationBuilder.DropTable(
                name: "OutputMessage");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_InteractionInput_InputMessageId",
                table: "InteractionInput");

            migrationBuilder.DropIndex(
                name: "IX_Graph_ConversationId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "InputMessageId",
                table: "InteractionInput");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Graph");

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                table: "InteractionInput",
                column: "InteractionNodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
