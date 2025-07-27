using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCasePartyTagRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePartyTags_CasePartyTagRoles_TagRoleId",
                table: "CasePartyTags");

            migrationBuilder.DropTable(
                name: "CasePartyTagRoles");

            migrationBuilder.RenameColumn(
                name: "TagRoleId",
                table: "CasePartyTags",
                newName: "PartyRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CasePartyTags_TagRoleId",
                table: "CasePartyTags",
                newName: "IX_CasePartyTags_PartyRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePartyTags_PartyRoles_PartyRoleId",
                table: "CasePartyTags",
                column: "PartyRoleId",
                principalTable: "PartyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePartyTags_PartyRoles_PartyRoleId",
                table: "CasePartyTags");

            migrationBuilder.RenameColumn(
                name: "PartyRoleId",
                table: "CasePartyTags",
                newName: "TagRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CasePartyTags_PartyRoleId",
                table: "CasePartyTags",
                newName: "IX_CasePartyTags_TagRoleId");

            migrationBuilder.CreateTable(
                name: "CasePartyTagRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePartyTagRoles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CasePartyTags_CasePartyTagRoles_TagRoleId",
                table: "CasePartyTags",
                column: "TagRoleId",
                principalTable: "CasePartyTagRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
