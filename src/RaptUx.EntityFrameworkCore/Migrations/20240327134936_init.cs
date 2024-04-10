using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaptUx.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChallengeEntityId",
                table: "AppProjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppProjects_ChallengeEntityId",
                table: "AppProjects",
                column: "ChallengeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppProjects_AppChallenges_ChallengeEntityId",
                table: "AppProjects",
                column: "ChallengeEntityId",
                principalTable: "AppChallenges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProjects_AppChallenges_ChallengeEntityId",
                table: "AppProjects");

            migrationBuilder.DropIndex(
                name: "IX_AppProjects_ChallengeEntityId",
                table: "AppProjects");

            migrationBuilder.DropColumn(
                name: "ChallengeEntityId",
                table: "AppProjects");
        }
    }
}
