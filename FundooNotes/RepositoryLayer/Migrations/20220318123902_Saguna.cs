namespace RepositoryLayer.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// saguna
    /// </summary>
    public partial class Saguna : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder">migration builder</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    NoteId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Label_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Label_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_Id",
                table: "Label",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Label_NoteId",
                table: "Label",
                column: "NoteId");
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder">migration builder</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");
        }
    }
}
