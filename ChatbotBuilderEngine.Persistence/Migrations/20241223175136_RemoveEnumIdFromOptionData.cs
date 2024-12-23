using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEnumIdFromOptionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedOption_EnumId",
                table: "SwitchNode");

            migrationBuilder.DropColumn(
                name: "Data_EnumId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropColumn(
                name: "Option_EnumId",
                table: "InteractionInput");

            migrationBuilder.DropColumn(
                name: "Data_EnumId",
                table: "InputPort<OptionData>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SelectedOption_EnumId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Data_EnumId",
                table: "StaticNode<OptionData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Option_EnumId",
                table: "InteractionInput",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Data_EnumId",
                table: "InputPort<OptionData>",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
