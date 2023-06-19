using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDeals.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Users",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "TEXT", nullable: false),
				Email = table.Column<string>(type: "TEXT", nullable: false),
				Password = table.Column<string>(type: "TEXT", nullable: false),
				Role = table.Column<string>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Users", x => x.Id);
			});

		migrationBuilder.InsertData(
			table: "Users",
			columns: new[] { "Id", "Email", "Password", "Role" },
			values: new object[] { new Guid("80ec141d-c339-4ba4-bfcb-c6c31bc501b6"), "arkadiusz.kapalka@microsoft.wsei.edu.pl", "Example)98", "Admin" });

		migrationBuilder.CreateIndex(
			name: "IX_Users_Email",
			table: "Users",
			column: "Email",
			unique: true);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Users");
	}
}
