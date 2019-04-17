using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.Migrations
{
    public partial class updatesthingss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Auditoriums_AuditoriumId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "AuditoriumId",
                table: "Movies",
                newName: "MultiplexId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_AuditoriumId",
                table: "Movies",
                newName: "IX_Movies_MultiplexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Multiplexes_MultiplexId",
                table: "Movies",
                column: "MultiplexId",
                principalTable: "Multiplexes",
                principalColumn: "MultiplexId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Multiplexes_MultiplexId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MultiplexId",
                table: "Movies",
                newName: "AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MultiplexId",
                table: "Movies",
                newName: "IX_Movies_AuditoriumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Auditoriums_AuditoriumId",
                table: "Movies",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "AuditoriumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
