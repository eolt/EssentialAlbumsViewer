using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtistsEssentialsApi.Migrations
{
    public partial class EssentialsAPIMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EssentialArtists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssentialArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EssentialAlbums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EssentialArtistId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillboardPeakUS = table.Column<int>(type: "int", nullable: true),
                    WeeksOnChartUS = table.Column<int>(type: "int", nullable: true),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PitchforkRating = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    MetacriticRating = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RollingStoneRating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    RateYourMusicRating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    GrammyNominations = table.Column<int>(type: "int", nullable: true),
                    GrammyWins = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssentialAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssentialAlbums_EssentialArtists_EssentialArtistId",
                        column: x => x.EssentialArtistId,
                        principalTable: "EssentialArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EssentialAlbums_EssentialArtistId",
                table: "EssentialAlbums",
                column: "EssentialArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EssentialAlbums");

            migrationBuilder.DropTable(
                name: "EssentialArtists");
        }
    }
}
