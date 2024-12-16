using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeGraphEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workflow_Graph_GraphId",
                table: "Workflow");

            migrationBuilder.DropIndex(
                name: "IX_Workflow_GraphId",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Graph");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkflowId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Graph_WorkflowId",
                table: "Graph",
                column: "WorkflowId",
                unique: true,
                filter: "[WorkflowId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Workflow_WorkflowId",
                table: "Graph",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Workflow_WorkflowId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_WorkflowId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "WorkflowId",
                table: "Graph");

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "Workflow",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Graph",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Graph",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_GraphId",
                table: "Workflow",
                column: "GraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workflow_Graph_GraphId",
                table: "Workflow",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id");
        }
    }
}
