using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.Migrations
{
    public partial class classescrearedds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_UserDetails_UserDetailId",
                table: "Review");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Review_MovieId_UserDetailId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserDetailId",
                table: "Reviews",
                newName: "IX_Reviews_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_MovieId",
                table: "Reviews",
                newName: "IX_Reviews_MovieId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Reviews_MovieId_UserDetailId",
                table: "Reviews",
                columns: new[] { "MovieId", "UserDetailId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "UserDetailId", "MovieId" });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pay = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UserDetails_UserDetailId",
                table: "Reviews",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "UserDetailID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UserDetails_UserDetailId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Reviews_MovieId_UserDetailId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserDetailId",
                table: "Review",
                newName: "IX_Review_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MovieId",
                table: "Review",
                newName: "IX_Review_MovieId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Review_MovieId_UserDetailId",
                table: "Review",
                columns: new[] { "MovieId", "UserDetailId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "UserDetailId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_UserDetails_UserDetailId",
                table: "Review",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "UserDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
