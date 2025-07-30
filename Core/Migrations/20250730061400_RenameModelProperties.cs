using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RenameModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseRoles_RoleId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseStatusRoles_CaseRoles_RoleId",
                table: "CaseStatusRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_PartyRoles_RoleId",
                table: "Parties");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Parties",
                newName: "PartyRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_RoleId",
                table: "Parties",
                newName: "IX_Parties_PartyRoleId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "CaseStatusRoles",
                newName: "CaseRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseStatusRoles_RoleId",
                table: "CaseStatusRoles",
                newName: "IX_CaseStatusRoles_CaseRoleId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Cases",
                newName: "CaseRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_RoleId",
                table: "Cases",
                newName: "IX_Cases_CaseRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseRoles_CaseRoleId",
                table: "Cases",
                column: "CaseRoleId",
                principalTable: "CaseRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStatusRoles_CaseRoles_CaseRoleId",
                table: "CaseStatusRoles",
                column: "CaseRoleId",
                principalTable: "CaseRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_PartyRoles_PartyRoleId",
                table: "Parties",
                column: "PartyRoleId",
                principalTable: "PartyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseRoles_CaseRoleId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseStatusRoles_CaseRoles_CaseRoleId",
                table: "CaseStatusRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_PartyRoles_PartyRoleId",
                table: "Parties");

            migrationBuilder.RenameColumn(
                name: "PartyRoleId",
                table: "Parties",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_PartyRoleId",
                table: "Parties",
                newName: "IX_Parties_RoleId");

            migrationBuilder.RenameColumn(
                name: "CaseRoleId",
                table: "CaseStatusRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseStatusRoles_CaseRoleId",
                table: "CaseStatusRoles",
                newName: "IX_CaseStatusRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "CaseRoleId",
                table: "Cases",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_CaseRoleId",
                table: "Cases",
                newName: "IX_Cases_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseRoles_RoleId",
                table: "Cases",
                column: "RoleId",
                principalTable: "CaseRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStatusRoles_CaseRoles_RoleId",
                table: "CaseStatusRoles",
                column: "RoleId",
                principalTable: "CaseRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_PartyRoles_RoleId",
                table: "Parties",
                column: "RoleId",
                principalTable: "PartyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
