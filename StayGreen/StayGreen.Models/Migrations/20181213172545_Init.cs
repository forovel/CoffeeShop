using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StayGreen.Models.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Prise = table.Column<double>(nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    Sour = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Saturation = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Bitterness = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Fortress = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CoffeeCategory = table.Column<int>(type: "int", nullable: false),
                    CoffeeRegion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float(53)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    PostCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Path = table.Column<string>(type: "varchar(4000)", nullable: false),
                    AttachmentGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentGroups_AttachmentGroupId",
                        column: x => x.AttachmentGroupId,
                        principalTable: "AttachmentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeePrises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: false),
                    CoffeeWeight = table.Column<int>(type: "int", nullable: false),
                    Prise = table.Column<double>(type: "float(53)", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeePrises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeePrises_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true),
                    RoleId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsCoffee",
                columns: table => new
                {
                    CoffeeId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsCoffee", x => new { x.AttachmentId, x.CoffeeId });
                    table.ForeignKey(
                        name: "FK_AttachmentsCoffee_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentsCoffee_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeePreparations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeePreparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeePreparations_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderedCoffee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedById = table.Column<string>(type: "varchar(512)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CoffeePrise = table.Column<double>(type: "float(53)", nullable: false),
                    CoffeeWeight = table.Column<int>(type: "int", nullable: false),
                    CoffeeRoasting = table.Column<int>(type: "int", nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedCoffee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedCoffee_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderedCoffee_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderedCoffee_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeePreparationsCoffee",
                columns: table => new
                {
                    CoffeePreparationId = table.Column<Guid>(nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: false),
                    CoffeeRoasting = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeePreparationsCoffee", x => new { x.CoffeeId, x.CoffeePreparationId });
                    table.ForeignKey(
                        name: "FK_CoffeePreparationsCoffee_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeePreparationsCoffee_CoffeePreparations_CoffeePreparationId",
                        column: x => x.CoffeePreparationId,
                        principalTable: "CoffeePreparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentGroupId",
                table: "Attachments",
                column: "AttachmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsCoffee_CoffeeId",
                table: "AttachmentsCoffee",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeePreparations_AttachmentId",
                table: "CoffeePreparations",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeePreparationsCoffee_CoffeePreparationId",
                table: "CoffeePreparationsCoffee",
                column: "CoffeePreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeePrises_CoffeeId",
                table: "CoffeePrises",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedCoffee_AttachmentId",
                table: "OrderedCoffee",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedCoffee_CoffeeId",
                table: "OrderedCoffee",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedCoffee_OrderId",
                table: "OrderedCoffee",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "Index_RoleName",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Index_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AttachmentsCoffee");

            migrationBuilder.DropTable(
                name: "CoffeePreparationsCoffee");

            migrationBuilder.DropTable(
                name: "CoffeePrises");

            migrationBuilder.DropTable(
                name: "OrderedCoffee");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "CoffeePreparations");

            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "AttachmentGroups");
        }
    }
}
