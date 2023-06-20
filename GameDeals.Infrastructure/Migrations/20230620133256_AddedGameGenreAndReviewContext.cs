using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDeals.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddedGameGenreAndReviewContext : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DeleteData(
			table: "Users",
			keyColumn: "Id",
			keyValue: new Guid("80ec141d-c339-4ba4-bfcb-c6c31bc501b6"));

		migrationBuilder.CreateTable(
			name: "Games",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "TEXT", nullable: false),
				Name = table.Column<string>(type: "TEXT", nullable: false),
				Genre = table.Column<string>(type: "TEXT", nullable: false),
				Description = table.Column<string>(type: "TEXT", nullable: false),
				ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
				Price = table.Column<decimal>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Games", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Genres",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "TEXT", nullable: false),
				Name = table.Column<string>(type: "TEXT", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Genres", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Reviews",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "TEXT", nullable: false),
				GameId = table.Column<Guid>(type: "TEXT", nullable: false),
				Title = table.Column<string>(type: "TEXT", nullable: false),
				Description = table.Column<string>(type: "TEXT", nullable: true),
				Rating = table.Column<int>(type: "INTEGER", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Reviews", x => x.Id);
				table.ForeignKey(
					name: "FK_Reviews_Games_GameId",
					column: x => x.GameId,
					principalTable: "Games",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.InsertData(
			table: "Users",
			columns: new[] { "Id", "Email", "Password", "Role" },
			values: new object[] { new Guid("9da8659d-56a5-47dc-ae86-25d249aeb738"), "arkadiusz.kapalka@microsoft.wsei.edu.pl", "Example)98", "Admin" });

		migrationBuilder.CreateIndex(
			name: "IX_Reviews_GameId",
			table: "Reviews",
			column: "GameId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Genres");

		migrationBuilder.DropTable(
			name: "Reviews");

		migrationBuilder.DropTable(
			name: "Games");

		migrationBuilder.DeleteData(
			table: "Users",
			keyColumn: "Id",
			keyValue: new Guid("9da8659d-56a5-47dc-ae86-25d249aeb738"));

		migrationBuilder.InsertData(
			table: "Users",
			columns: new[] { "Id", "Email", "Password", "Role" },
			values: new object[] { new Guid("80ec141d-c339-4ba4-bfcb-c6c31bc501b6"), "arkadiusz.kapalka@microsoft.wsei.edu.pl", "Example)98", "Admin" });
	}
}
