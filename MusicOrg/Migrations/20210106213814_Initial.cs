using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicOrg.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Vinyls",
                columns: table => new
                {
                    VinylId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyls", x => x.VinylId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistVinyl",
                columns: table => new
                {
                    ArtistVinylId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(nullable: false),
                    VinylId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistVinyl", x => x.ArtistVinylId);
                    table.ForeignKey(
                        name: "FK_ArtistVinyl_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistVinyl_Vinyls_VinylId",
                        column: x => x.VinylId,
                        principalTable: "Vinyls",
                        principalColumn: "VinylId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistVinyl_ArtistId",
                table: "ArtistVinyl",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistVinyl_VinylId",
                table: "ArtistVinyl",
                column: "VinylId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistVinyl");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Vinyls");
        }
    }
}
