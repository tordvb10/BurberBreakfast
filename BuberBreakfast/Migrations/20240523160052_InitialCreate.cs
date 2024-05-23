using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuberBreakfast.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Savory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sweet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Breakfasts",
                columns: new[] { "Id", "Description", "EndDateTime", "LastModifiedDateTime", "Name", "Savory", "StartDateTime", "Sweet" },
                values: new object[,]
                {
                    { new Guid("84e70a61-7e9a-4e18-8819-135734ba6a11"), "Vegan everything! Join us for a healthy breakfast.", new DateTime(2022, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 23, 12, 58, 14, 418, DateTimeKind.Utc).AddTicks(4169), "NEW Vegan Sunshine", "[\"Oatmeal\",\"Avocado Toast\",\"Omelette\",\"Salad\"]", new DateTime(2022, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "[\"Cookie\"]" },
                    { new Guid("94e70a61-7e9a-4e18-8819-135734ba6a11"), "Vegan everything! Join us for a healthy breakfast.", new DateTime(2022, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 23, 12, 58, 14, 418, DateTimeKind.Utc).AddTicks(4169), "Vegan Sunshine", "[\"Oatmeal\",\"Avocado Toast\",\"Omelette\",\"Salad\"]", new DateTime(2022, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "[\"Cookie\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfasts");
        }
    }
}
