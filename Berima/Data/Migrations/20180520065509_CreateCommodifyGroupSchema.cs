using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Berima.Data.Migrations
{
    public partial class CreateCommodifyGroupSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommodityCommodityGroupDAO",
                columns: table => new
                {
                    CommodityDAOId = table.Column<int>(type: "int", nullable: false),
                    CommodityGroupDAOId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityCommodityGroupDAO", x => new { x.CommodityDAOId, x.CommodityGroupDAOId });
                    table.ForeignKey(
                        name: "FK_CommodityCommodityGroupDAO_Commodities_CommodityDAOId",
                        column: x => x.CommodityDAOId,
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommodityCommodityGroupDAO_Groups_CommodityGroupDAOId",
                        column: x => x.CommodityGroupDAOId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommodityCommodityGroupDAO_CommodityGroupDAOId",
                table: "CommodityCommodityGroupDAO",
                column: "CommodityGroupDAOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommodityCommodityGroupDAO");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
