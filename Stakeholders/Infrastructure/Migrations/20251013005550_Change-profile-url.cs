using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changeprofileurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicureUrl",
                schema: "stakeholders",
                table: "UserProfiles",
                newName: "ProfilePictureUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                schema: "stakeholders",
                table: "UserProfiles",
                newName: "ProfilePicureUrl");
        }
    }
}
