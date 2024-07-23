using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Contact_Management_Web_Application.Migrations
{
    /// <inheritdoc />
    public partial class fristdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "ContactId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "SampleContact1@gmail.com", "Sample Contact 1", "074 324 4354" },
                    { 2, "SampleContact2@gmail.com", "Sample Contact 2", "075 675 2345" },
                    { 3, "SampleContact3@gmail.com", "Sample Contact 3", "084 323 6756" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
