using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kaigang.Migrations.KaigangDb
{
    public partial class CreateBasicEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PollID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.UniqueConstraint("AK_Users_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AuthorID = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnedByID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Options = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polls_Users_OwnedByID",
                        column: x => x.OwnedByID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    AuthorID = table.Column<Guid>(nullable: false),
                    Tags = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorID",
                table: "Comments",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_OwnedByID",
                table: "Polls",
                column: "OwnedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PollID",
                table: "Users",
                column: "PollID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Polls_PollID",
                table: "Users",
                column: "PollID",
                principalTable: "Polls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_Users_OwnedByID",
                table: "Polls");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Polls");
        }
    }
}
