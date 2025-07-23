using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedForProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Biography", "FirstName", "LastName", "Moto", "ProfilePicureUrl", "UserId" },
                values: new object[,]
                {
                    { 1L, "Experienced tour guide with over 10 years of guiding tours in Europe.", "John", "Doe", "Discover the world with passion.", "https://example.com/profiles/johndoe.jpg", 12345L },
                    { 2L, "Tourist looking for the best culinary experiences across the globe.", "Jane", "Smith", "Eat, Travel, Enjoy.", "https://example.com/profiles/janesmith.jpg", 12346L },
                    { 3L, "A passionate history buff who loves to show people hidden gems in ancient cities.", "Alice", "Johnson", "History lives through the stories we tell.", "https://example.com/profiles/alicejohnson.jpg", 12347L },
                    { 4L, "Tourist looking to explore unique and off-the-beaten-path destinations.", "Bob", "Williams", "Explore the unexplored.", "https://example.com/profiles/bobwilliams.jpg", 12348L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
