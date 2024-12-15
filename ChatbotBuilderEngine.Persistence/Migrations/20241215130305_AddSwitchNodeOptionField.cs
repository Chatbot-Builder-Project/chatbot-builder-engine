using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSwitchNodeOptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SelectedOption_EnumId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedOption_Value",
                table: "SwitchNode",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedOption_EnumId",
                table: "SwitchNode");

            migrationBuilder.DropColumn(
                name: "SelectedOption_Value",
                table: "SwitchNode");
        }
    }
}
