using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace baykuslar_api.Migrations
{
    public partial class FundEquityInitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquityFundingPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SharePrice = table.Column<double>(nullable: false),
                    TargetShare = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityFundingPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquityFundingPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundraisingPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TargetAmount = table.Column<double>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TargetIban = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraisingPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundraisingPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquityFundingInvestments",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EquityFundingPostId = table.Column<int>(nullable: false),
                    ShareCount = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityFundingInvestments", x => new { x.UserId, x.EquityFundingPostId });
                    table.ForeignKey(
                        name: "FK_EquityFundingInvestments_EquityFundingPosts_EquityFundingPo~",
                        column: x => x.EquityFundingPostId,
                        principalTable: "EquityFundingPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquityFundingInvestments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundraisingDonations",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FundraisingPostId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraisingDonations", x => new { x.UserId, x.FundraisingPostId });
                    table.ForeignKey(
                        name: "FK_FundraisingDonations_FundraisingPosts_FundraisingPostId",
                        column: x => x.FundraisingPostId,
                        principalTable: "FundraisingPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundraisingDonations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquityFundingInvestments_EquityFundingPostId",
                table: "EquityFundingInvestments",
                column: "EquityFundingPostId");

            migrationBuilder.CreateIndex(
                name: "IX_EquityFundingPosts_UserId",
                table: "EquityFundingPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingDonations_FundraisingPostId",
                table: "FundraisingDonations",
                column: "FundraisingPostId");

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingPosts_UserId",
                table: "FundraisingPosts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquityFundingInvestments");

            migrationBuilder.DropTable(
                name: "FundraisingDonations");

            migrationBuilder.DropTable(
                name: "EquityFundingPosts");

            migrationBuilder.DropTable(
                name: "FundraisingPosts");
        }
    }
}
