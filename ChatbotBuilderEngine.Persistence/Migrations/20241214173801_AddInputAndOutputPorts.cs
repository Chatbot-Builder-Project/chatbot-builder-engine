using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderEngine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInputAndOutputPorts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputPort<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<ImageData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputPort<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<OptionData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputPort<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<TextData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<ImageData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<OptionData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<TextData>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutputPort<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPort<ImageData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                        column: x => x.NodeId,
                        principalTable: "StaticNode<ImageData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputPort<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPort<OptionData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                        column: x => x.NodeId,
                        principalTable: "StaticNode<OptionData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputPort<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPort<TextData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                        column: x => x.NodeId,
                        principalTable: "StaticNode<TextData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<ImageData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageOutputPortInputPort_OutputPort<ImageData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<ImageData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<OptionData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionOutputPortInputPort_OutputPort<OptionData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<TextData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextOutputPortInputPort_OutputPort<TextData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageOutputPortInputPort_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<ImageData>_NodeId",
                table: "InputPort<ImageData>",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionOutputPortInputPort_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextOutputPortInputPort_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "OptionOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "TextOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "InputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "OutputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "InputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "OutputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "InputPort<TextData>");

            migrationBuilder.DropTable(
                name: "OutputPort<TextData>");

            migrationBuilder.DropTable(
                name: "StaticNode<ImageData>");

            migrationBuilder.DropTable(
                name: "StaticNode<OptionData>");

            migrationBuilder.DropTable(
                name: "StaticNode<TextData>");
        }
    }
}
