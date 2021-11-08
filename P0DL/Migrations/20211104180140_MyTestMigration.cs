using Microsoft.EntityFrameworkCore.Migrations;

namespace P0DL.Migrations
{
    public partial class MyTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    cust_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cust_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cust_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cust_phonenumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A1B71F90DDEFF9CE", x => x.cust_id);
                });

            migrationBuilder.CreateTable(
                name: "StoreFront",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    store_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StoreFro__A2F2A30CFE7A5882", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    inv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inv_product = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    inv_quantity = table.Column<int>(type: "int", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__A8749C29C4B81E06", x => x.inv_id);
                    table.ForeignKey(
                        name: "FK__Inventory__store__3F115E1A",
                        column: x => x.store_id,
                        principalTable: "StoreFront",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyOrder",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    order_price = table.Column<int>(type: "int", nullable: false),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MyOrder__46596229FA8A6998", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__MyOrder__cust_id__151B244E",
                        column: x => x.cust_id,
                        principalTable: "Customer",
                        principalColumn: "cust_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__MyOrder__store_i__160F4887",
                        column: x => x.store_id,
                        principalTable: "StoreFront",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    li_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    li_product = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    li_quantity = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LineItem__1A6BDF65975CEFB2", x => x.li_id);
                    table.ForeignKey(
                        name: "FK__LineItem__order___41EDCAC5",
                        column: x => x.order_id,
                        principalTable: "MyOrder",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    prod_price = table.Column<int>(type: "int", nullable: false),
                    inv_id = table.Column<int>(type: "int", nullable: false),
                    li_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__56958AB2AC479E44", x => x.prod_id);
                    table.ForeignKey(
                        name: "FK__Product__inv_id__503BEA1C",
                        column: x => x.inv_id,
                        principalTable: "Inventory",
                        principalColumn: "inv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Product__li_id__51300E55",
                        column: x => x.li_id,
                        principalTable: "LineItem",
                        principalColumn: "li_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_store_id",
                table: "Inventory",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_order_id",
                table: "LineItem",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_MyOrder_cust_id",
                table: "MyOrder",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_MyOrder_store_id",
                table: "MyOrder",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_inv_id",
                table: "Product",
                column: "inv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_li_id",
                table: "Product",
                column: "li_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "MyOrder");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "StoreFront");
        }
    }
}
