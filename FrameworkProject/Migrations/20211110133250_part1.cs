using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FrameworkProject.Migrations
{
    public partial class part1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banners",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false),
                    condition = table.Column<string>(type: "enum('banner','promo')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    type = table.Column<string>(type: "enum('fixed','percent')", nullable: false),
                    value = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false),
                    is_voucher = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    started_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    ended_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    phone = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    message = table.Column<string>(type: "longtext", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(36)", fixedLength: true, maxLength: 36, nullable: false),
                    type = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    notifiable_type = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    notifiable_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "postcategories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postcategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posttags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posttags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    short_des = table.Column<string>(type: "text", nullable: false),
                    logo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    address = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    phone = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shippings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    user_name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    password = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    phone = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    address = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    role = table.Column<string>(type: "enum('employee','customer')", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "text", nullable: true),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    is_parent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    parent_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    added_by = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "Categories_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Categories_parent_id_foreign",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    quote = table.Column<string>(type: "text", nullable: true),
                    photo = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: true),
                    post_cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    added_by = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "Posts_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Posts_post_cat_id_foreign",
                        column: x => x.post_cat_id,
                        principalTable: "postcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    photo1 = table.Column<string>(type: "text", nullable: false),
                    photo2 = table.Column<string>(type: "text", nullable: false),
                    photo3 = table.Column<string>(type: "text", nullable: false),
                    photo4 = table.Column<string>(type: "text", nullable: false),
                    stock = table.Column<int>(type: "int(11)", nullable: false),
                    condition = table.Column<string>(type: "enum('default','new','hot')", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    coupon_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    child_cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    brand_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "Products_brand_id_foreign",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Products_cat_id_foreign",
                        column: x => x.cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Products_child_cat_id_foreign",
                        column: x => x.child_cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Products_coupon_id_foreign",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "postcomments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    post_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    comments = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false),
                    parent_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postcomments", x => x.id);
                    table.ForeignKey(
                        name: "PostComments_post_id_foreign",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "PostComments_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "postsandtags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    post_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    tag_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postsandtags", x => x.id);
                    table.ForeignKey(
                        name: "PostsAndTags_post_id_foreign",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "PostsAndTags_post_tag_id_foreign",
                        column: x => x.tag_id,
                        principalTable: "posttags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_number = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    sub_total = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    shipping_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    coupon_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    total_amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    payment_method = table.Column<string>(type: "enum('cod','paypal')", nullable: false),
                    payment_status = table.Column<string>(type: "enum('paid','unpaid')", nullable: false),
                    status = table.Column<string>(type: "enum('new','process','delivered','cancel')", nullable: false),
                    first_name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    last_name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    phone = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "Orders_coupon_id_foreign",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Orders_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Orders_shipping_id_foreign",
                        column: x => x.shipping_id,
                        principalTable: "shippings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Orders_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "productattributes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    color = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    stock = table.Column<int>(type: "int(11)", nullable: false),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productattributes", x => x.id);
                    table.ForeignKey(
                        name: "ProductAttributes_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "productreviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    rating = table.Column<byte>(type: "tinyint(4)", nullable: false),
                    review = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productreviews", x => x.id);
                    table.ForeignKey(
                        name: "ProductReviews_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "ProductReviews_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    order_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    status = table.Column<string>(type: "enum('new','progress','delivered','cancel')", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "Carts_order_id_foreign",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Carts_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Carts_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wishlists",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    cart_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true),
                    color = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlists", x => x.id);
                    table.ForeignKey(
                        name: "Wishlists_cart_id_foreign",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Wishlists_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Wishlists_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "Banners_slug_unique",
                table: "banners",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Brands_slug_unique",
                table: "brands",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Carts_order_id_foreign",
                table: "carts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "Carts_product_id_foreign",
                table: "carts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "Carts_user_id_foreign",
                table: "carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "Categories_added_by_foreign",
                table: "categories",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "Categories_parent_id_foreign",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "Categories_slug_unique",
                table: "categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Coupons_code_unique",
                table: "coupons",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Notifications_notifiable_type_notifiable_id_index",
                table: "notifications",
                columns: new[] { "notifiable_type", "notifiable_id" });

            migrationBuilder.CreateIndex(
                name: "Orders_coupon_id_foreign",
                table: "orders",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "Orders_order_number_unique",
                table: "orders",
                column: "order_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Orders_product_id_foreign",
                table: "orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "Orders_shipping_id_foreign",
                table: "orders",
                column: "shipping_id");

            migrationBuilder.CreateIndex(
                name: "Orders_user_id_foreign",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "PostCategories_slug_unique",
                table: "postcategories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PostComments_post_id_foreign",
                table: "postcomments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "PostComments_user_id_foreign",
                table: "postcomments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "Posts_added_by_foreign",
                table: "posts",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "Posts_post_cat_id_foreign",
                table: "posts",
                column: "post_cat_id");

            migrationBuilder.CreateIndex(
                name: "Posts_slug_unique",
                table: "posts",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PostsAndTags_post_id_foreign",
                table: "postsandtags",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "PostsAndTags_post_tag_id_foreign",
                table: "postsandtags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "PostTags_slug_unique",
                table: "posttags",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ProductAttributes_product_id_foreign",
                table: "productattributes",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ProductReviews_product_id_foreign",
                table: "productreviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ProductReviews_user_id_foreign",
                table: "productreviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "Products_brand_id_foreign",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "Products_cat_id_foreign",
                table: "products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "Products_child_cat_id_foreign",
                table: "products",
                column: "child_cat_id");

            migrationBuilder.CreateIndex(
                name: "Products_coupon_id_foreign",
                table: "products",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "Products_slug_unique",
                table: "products",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users_email_unique",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users_phone_unique",
                table: "users",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Wishlists_cart_id_foreign",
                table: "wishlists",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "Wishlists_product_id_foreign",
                table: "wishlists",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "Wishlists_user_id_foreign",
                table: "wishlists",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "postcomments");

            migrationBuilder.DropTable(
                name: "postsandtags");

            migrationBuilder.DropTable(
                name: "productattributes");

            migrationBuilder.DropTable(
                name: "productreviews");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "wishlists");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "posttags");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "postcategories");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shippings");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
