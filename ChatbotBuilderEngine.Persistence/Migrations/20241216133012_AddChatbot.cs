using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddChatbot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChatbotId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chatbot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version_Major = table.Column<int>(type: "int", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatbot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chatbot_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Graph_ChatbotId",
                table: "Graph",
                column: "ChatbotId",
                unique: true,
                filter: "[ChatbotId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_Version_Major",
                table: "Chatbot",
                column: "Version_Major",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_WorkflowId",
                table: "Chatbot",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Chatbot_ChatbotId",
                table: "Graph",
                column: "ChatbotId",
                principalTable: "Chatbot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Chatbot_ChatbotId",
                table: "Graph");

            migrationBuilder.DropTable(
                name: "Chatbot");

            migrationBuilder.DropIndex(
                name: "IX_Graph_ChatbotId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "ChatbotId",
                table: "Graph");
        }
    }
}
