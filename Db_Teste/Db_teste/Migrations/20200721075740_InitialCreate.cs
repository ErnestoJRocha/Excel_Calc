using Microsoft.EntityFrameworkCore.Migrations;

namespace Db_teste.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    area_name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CAR_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    car_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    dependents_num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IRS_Calculator",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    pick_area = table.Column<int>(nullable: true),
                    pick_level = table.Column<int>(nullable: false),
                    car_type = table.Column<int>(nullable: true),
                    car_total_value = table.Column<decimal>(type: "money", nullable: true),
                    tta_id = table.Column<int>(nullable: true),
                    marital_status_id = table.Column<int>(nullable: false),
                    dependents_id = table.Column<int>(nullable: false),
                    num_months = table.Column<int>(nullable: true),
                    num_days_month = table.Column<int>(nullable: true),
                    target_margin = table.Column<int>(nullable: true),
                    justified_expenses = table.Column<decimal>(type: "money", nullable: true),
                    car_expenses = table.Column<decimal>(type: "money", nullable: true),
                    car_fuel = table.Column<decimal>(type: "money", nullable: true),
                    variable_value = table.Column<decimal>(type: "money", nullable: true),
                    bonus = table.Column<decimal>(type: "money", nullable: true),
                    proposed_daily_rate = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRS_Calculator", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IRS_Table",
                columns: table => new
                {
                    id_row = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_irs_table = table.Column<int>(nullable: false),
                    irs_table_name = table.Column<string>(maxLength: 50, nullable: true),
                    salary = table.Column<decimal>(type: "money", nullable: true),
                    num_dep = table.Column<int>(nullable: true),
                    married_status = table.Column<string>(maxLength: 50, nullable: true),
                    fiscal_year = table.Column<string>(maxLength: 4, nullable: true),
                    irs_tax = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IRS_Tabl__6ABCB5F5DF79B984", x => x.id_row);
                });

            migrationBuilder.CreateTable(
                name: "Leaving_Syone",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    designation = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaving_Syone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marital_status = table.Column<string>(maxLength: 40, nullable: false),
                    irs_table = table.Column<int>(nullable: false),
                    extra = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Taxable_Person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    gross_wage = table.Column<decimal>(type: "money", nullable: false),
                    tax = table.Column<int>(nullable: false),
                    person_type_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxable_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Taxable_Person_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    person_type_description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxable_Person_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    tax_name = table.Column<string>(maxLength: 30, nullable: false),
                    tax_value = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "CAR_Type");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "IRS_Calculator");

            migrationBuilder.DropTable(
                name: "IRS_Table");

            migrationBuilder.DropTable(
                name: "Leaving_Syone");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Taxable_Person");

            migrationBuilder.DropTable(
                name: "Taxable_Person_Type");

            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
