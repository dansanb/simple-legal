using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class CreateDateUpdatedTriggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""Cases""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""CaseNotes""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""CaseRoles""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

             migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""CaseStatusRoles""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

             migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""CasePartyTags""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""CasePartyTagRoles""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

             migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""Parties""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_timestamp_trigger
                 BEFORE UPDATE ON ""PartyRoles""
                 FOR EACH ROW
                 EXECUTE FUNCTION set_updated_timestamp();");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""CaseNotes"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""Cases"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""CaseRoles"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""CaseStatusRoles"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""CasePartyTags"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""CasePartyTagRoles"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""Parties"";
                DROP TRIGGER IF EXISTS update_timestamp_trigger ON ""PartyRoles"";
            ");
        }
    }
}
