using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class FixSetUpdatedTimestampFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION set_updated_timestamp()
                RETURNS TRIGGER AS $$
                BEGIN
                    NEW.DateUpdated = NOW();
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
