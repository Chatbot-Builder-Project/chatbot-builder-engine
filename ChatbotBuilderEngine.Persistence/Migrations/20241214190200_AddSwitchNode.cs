using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSwitchNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.CreateTable(
                name: "SwitchNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bindings = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwitchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwitchNode_Enum_EnumId",
                        column: x => x.EnumId,
                        principalTable: "Enum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_EnumId",
                table: "SwitchNode",
                column: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                principalTable: "SwitchNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "SwitchNode");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId");
        }
    }
}
