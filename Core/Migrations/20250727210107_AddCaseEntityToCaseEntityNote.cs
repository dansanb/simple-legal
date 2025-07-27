using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseEntityToCaseEntityNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNotes_Cases_CaseEntityId",
                table: "CaseNotes");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseEntityId",
                table: "CaseNotes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNotes_Cases_CaseEntityId",
                table: "CaseNotes",
                column: "CaseEntityId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseNotes_Cases_CaseEntityId",
                table: "CaseNotes");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseEntityId",
                table: "CaseNotes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNotes_Cases_CaseEntityId",
                table: "CaseNotes",
                column: "CaseEntityId",
                principalTable: "Cases",
                principalColumn: "Id");
        }
    }
}
