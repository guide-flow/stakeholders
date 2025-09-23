using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stakeholders");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProfilePicureUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Biography = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Moto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "stakeholders",
                table: "UserProfiles",
                columns: new[] { "Id", "Biography", "FirstName", "LastName", "Moto", "ProfilePicureUrl", "UserId", "Username" },
                values: new object[,]
                {
                    { 1L, "Experienced tour guide with over 10 years of guiding tours in Europe.", "John", "Doe", "Discover the world with passion.", "https://example.com/profiles/johndoe.jpg", 12345L, "JohnDoe" },
                    { 2L, "Tourist looking for the best culinary experiences across the globe.", "Jane", "Smith", "Eat, Travel, Enjoy.", "https://example.com/profiles/janesmith.jpg", 12346L, "JaneSmith" },
                    { 3L, "A passionate history buff who loves to show people hidden gems in ancient cities.", "Alice", "Johnson", "History lives through the stories we tell.", "https://example.com/profiles/alicejohnson.jpg", 12347L, "AliceJohnson" },
                    { 4L, "Tourist looking to explore unique and off-the-beaten-path destinations.", "Bob", "Williams", "Explore the unexplored.", "https://example.com/profiles/bobwilliams.jpg", 12348L, "BobWilli" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                schema: "stakeholders",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "stakeholders");
        }
    }
}
