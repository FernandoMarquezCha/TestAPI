using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    PKBuilding = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building = table.Column<string>(type: "varchar(50)", nullable: false),
                    Avaliable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.PKBuilding);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PKCustomers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "varchar(50)", nullable: false),
                    Prefix = table.Column<string>(type: "varchar(5)", nullable: false),
                    FKBuildingsPKBuilding = table.Column<int>(type: "int", nullable: true),
                    Avaliable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PKCustomers);
                    table.ForeignKey(
                        name: "FK_Customers_Buildings_FKBuildingsPKBuilding",
                        column: x => x.FKBuildingsPKBuilding,
                        principalTable: "Buildings",
                        principalColumn: "PKBuilding",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartNumbers",
                columns: table => new
                {
                    PKPartNumbers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    FKCustomersPKCustomers = table.Column<int>(type: "int", nullable: true),
                    Avaliable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNumbers", x => x.PKPartNumbers);
                    table.ForeignKey(
                        name: "FK_PartNumbers_Customers_FKCustomersPKCustomers",
                        column: x => x.FKCustomersPKCustomers,
                        principalTable: "Customers",
                        principalColumn: "PKCustomers",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FKBuildingsPKBuilding",
                table: "Customers",
                column: "FKBuildingsPKBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_FKCustomersPKCustomers",
                table: "PartNumbers",
                column: "FKCustomersPKCustomers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartNumbers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
