using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kaigang.Migrations
{
    public partial class CreatePollsAndPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_AuthorID",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorID",
                table: "Commentss",
                newName: "IX_Comments_AuthorID");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Content = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Options = table.Column<JsonObject<IDictionary<string, int>>>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.ID);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "PollID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PollID",
                table: "Users",
                column: "PollID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Commentss",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorID",
                table: "Commentss",
                column: "AuthorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Comments_Users_AuthorID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Polls_PollID",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorID",
                table: "Comment",
                newName: "IX_Comment_AuthorID");

            migrationBuilder.DropIndex(
                name: "IX_Users_PollID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PollID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_AuthorID",
                table: "Comment",
                column: "AuthorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
