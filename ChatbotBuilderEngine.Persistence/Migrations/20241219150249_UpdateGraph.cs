using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentNodeId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Graph_CurrentNodeId",
                table: "Graph",
                column: "CurrentNodeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Graph_CurrentNodeId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "CurrentNodeId",
                table: "Graph");
        }
    }
}
