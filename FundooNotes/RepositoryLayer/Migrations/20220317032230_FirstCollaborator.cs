namespace RepositoryLayer.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// first controller class
    /// </summary>
    public partial class FirstCollaborator : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder">migration builder</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collab",
                columns: table => new
                {
                    CollaboratId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratEmail = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false),
                    NotesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collab", x => x.CollaboratId);
                    table.ForeignKey(
                        name: "FK_Collab_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Collab_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collab_Id",
                table: "Collab",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Collab_NotesId",
                table: "Collab",
                column: "NotesId");
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder">migration builder</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collab");
        }
    }
}
