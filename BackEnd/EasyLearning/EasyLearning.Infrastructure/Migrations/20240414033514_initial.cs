using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category_Sort_Order = table.Column<int>(type: "int", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Course_Event_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Event_Type = table.Column<int>(type: "int", nullable: false),
                    Course_Event_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Event_Date_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Course_Event_Date_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Courses_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courses_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courses_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Courses_Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courses_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courese_ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courses_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Courses_StartEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Courese_RegistrationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Courses_MaxAttendees = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddOns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Add_On_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_download = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoureseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddOns_Courses_CoureseId",
                        column: x => x.CoureseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Courses_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Category_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseDetails_Courses_Courses_Id",
                        column: x => x.Courses_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Feedback_User_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feeback_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feeback_Rating = table.Column<int>(type: "int", nullable: false),
                    Feedback_Courese_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Courses_Feedback_Courese_Id",
                        column: x => x.Feedback_Courese_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingParts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Training_Part_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Training_Part_StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Training_Part_EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Training_Part_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Training_Part_Event_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Training_Part_Courese_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingParts_CourseEvents_Training_Part_Event_Id",
                        column: x => x.Training_Part_Event_Id,
                        principalTable: "CourseEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingParts_Courses_Training_Part_Courese_Id",
                        column: x => x.Training_Part_Courese_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_User = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_Order_User",
                        column: x => x.Order_User,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Shopping_Cart_TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Shopping_Cart_PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shopping_Cart_User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_Shopping_Cart_User_Id",
                        column: x => x.Shopping_Cart_User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "trainerDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Courses_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainerDetails_Courses_Courses_Id",
                        column: x => x.Courses_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trainerDetails_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Courses_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Courses_Courses_Id",
                        column: x => x.Courses_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Shopping_Cart_Item_Quantity = table.Column<int>(type: "int", nullable: false),
                    Shopping_Cart_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Courese_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Courses_Courese_Id",
                        column: x => x.Courese_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_Shopping_Cart_Id",
                        column: x => x.Shopping_Cart_Id,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddOns_CoureseId",
                table: "AddOns",
                column: "CoureseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_Category_Id",
                table: "CourseDetails",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_Courses_Id",
                table: "CourseDetails",
                column: "Courses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Feedback_Courese_Id",
                table: "Feedbacks",
                column: "Feedback_Courese_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Courses_Id",
                table: "OrderDetails",
                column: "Courses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_User",
                table: "Orders",
                column: "Order_User");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Courese_Id",
                table: "ShoppingCartItems",
                column: "Courese_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Shopping_Cart_Id",
                table: "ShoppingCartItems",
                column: "Shopping_Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts",
                column: "Shopping_Cart_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_trainerDetails_Courses_Id",
                table: "trainerDetails",
                column: "Courses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_trainerDetails_User_Id",
                table: "trainerDetails",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParts_Training_Part_Courese_Id",
                table: "TrainingParts",
                column: "Training_Part_Courese_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParts_Training_Part_Event_Id",
                table: "TrainingParts",
                column: "Training_Part_Event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

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
                name: "AddOns");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "trainerDetails");

            migrationBuilder.DropTable(
                name: "TrainingParts");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "CourseEvents");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
