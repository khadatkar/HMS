using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitals", x => x.HospitalId);
                });

            migrationBuilder.InsertData(
                table: "hospitals",
                columns: new[] { "HospitalId", "City", "Description", "Email", "Mobile", "Name", "Photo" },
                values: new object[] { 1, "Nagpur", "Heart Specialist", "abc@gmail.com", 9881943266L, "Spandan", "2.jpg" });

            migrationBuilder.InsertData(
                table: "hospitals",
                columns: new[] { "HospitalId", "City", "Description", "Email", "Mobile", "Name", "Photo" },
                values: new object[] { 2, "Delhi", "Brain Specialist", "Wockheart@gmail.com", 9021910763L, "Wockheart", "2.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospitals");
        }
    }
}
