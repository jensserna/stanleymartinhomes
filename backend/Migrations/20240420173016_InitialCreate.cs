using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetroAreas",
                columns: table => new
                {
                    MetroAreaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetroAreaTitle = table.Column<string>(type: "TEXT", nullable: true),
                    MetroAreaStateAbr = table.Column<string>(type: "TEXT", nullable: true),
                    MetroAreaStateName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetroAreas", x => x.MetroAreaId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.ProductId, x.ProjectGroupId });
                });

            migrationBuilder.CreateTable(
                name: "ProjectGroups",
                columns: table => new
                {
                    ProjectGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetroAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGroups", x => x.ProjectGroupId);
                });

            migrationBuilder.InsertData(
                table: "MetroAreas",
                columns: new[] { "MetroAreaId", "MetroAreaStateAbr", "MetroAreaStateName", "MetroAreaTitle" },
                values: new object[,]
                {
                    { 1006, "VA", "Virginia", "Richmond" },
                    { 1007, "GA", "Georgia", "Atlanta" },
                    { 1008, "SC", "South Carolina", "Charleston" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProjectGroupId", "ProductName", "ProjectName" },
                values: new object[,]
                {
                    { "1601", 41, "The Moultrie", "Estuary" },
                    { "1665", 47, "The Tidalview", "Oldfield" },
                    { "1674", 43, "The Stella", "Mixson" },
                    { "980", 23, "The Davis", "Edgewater 50" },
                    { "980", 25, "The Dupree", "Inwood SFD" },
                    { "E15", 23, "The Amelia", "Edgewater 50" },
                    { "E15", 25, "Inwood", "Inwood SFD" },
                    { "U68", 41, "The Stono", "Estuary" },
                    { "Y54", 23, "The Lockwood", "Edgewater 50" },
                    { "Y58", 23, "The Prescot", "Edgewater" }
                });

            migrationBuilder.InsertData(
                table: "ProjectGroups",
                columns: new[] { "ProjectGroupId", "FullName", "MetroAreaId", "Status" },
                values: new object[,]
                {
                    { 23, "Edgewater", 1007, "a" },
                    { 25, "Inwood", 1007, "a" },
                    { 41, "Estuary at Bowen Village", 1008, "a" },
                    { 43, "Mixson", 1008, "i" },
                    { 47, "Oldfield", 1008, "a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetroAreas");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProjectGroups");
        }
    }
}
