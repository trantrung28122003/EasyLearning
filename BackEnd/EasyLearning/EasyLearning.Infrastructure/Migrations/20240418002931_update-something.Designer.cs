﻿// <auto-generated />
using System;
using EasyLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    [DbContext(typeof(EasyLearningDbContext))]
    [Migration("20240418002931_update-something")]
    partial class updatesomething
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category_Name");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Img_link");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int")
                        .HasColumnName("Category_Sort_Order");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.CourseEvent", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2")
                        .HasColumnName("Course_Event_Date_End");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2")
                        .HasColumnName("Course_Event_Date_Start");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Course_Event_Name");

                    b.Property<int>("EventType")
                        .HasColumnType("int")
                        .HasColumnName("Course_Event_Type");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Course_Event_Location");

                    b.HasKey("Id");

                    b.ToTable("CourseEvents");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Feedback_Courese_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackContent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Feeback_Content");

                    b.Property<int>("FeedbackRating")
                        .HasColumnType("int")
                        .HasColumnName("Feeback_Rating");

                    b.Property<string>("FeedbackUserId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Feedback_User_Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OrderNotes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Order_Notes");

                    b.Property<string>("OrderPaymentMethod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Order_PaymentMethod");

                    b.Property<decimal>("OrderTotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Order_TotalPrice");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Order_User");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.OrderDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Courses_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Order_Id");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.ShoppingCart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shopping_Cart_PaymentMethod");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Shopping_Cart_TotalPrice");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Shopping_Cart_User_Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[Shopping_Cart_User_Id] IS NOT NULL");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.ShoppingCartItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CartItemName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shopping_Cart_Item_Name");

                    b.Property<decimal?>("CartItemPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Shopping_Cart_Item_Price");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Courese_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shopping_Cart_Item_ImageUrl");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Shopping_Cart_Item_Quantity");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Shopping_Cart_Id");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.TrainerDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Courses_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.HasIndex("UserId");

                    b.ToTable("trainerDetails");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.TrainingPart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Training_Part_Courese_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Training_Part_Description");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Training_Part_EndTime");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Training_Part_Event_Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Training_Part_StartTime");

                    b.Property<string>("TrainingPartName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Training_Part_Name");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.HasIndex("EventId");

                    b.ToTable("TrainingParts");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.AddOn", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddOnName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Add_On_Name");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoureseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoursesId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LinkDownload")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("link_download");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CoureseId");

                    b.ToTable("AddOns");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainnerDetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TrainnerDetailId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoureseContent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_Content");

                    b.Property<string>("CoursesDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_Description");

                    b.Property<string>("CoursesName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_Name");

                    b.Property<decimal>("CoursesPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Courses_Price");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Courses_EndDate");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_ImageUrl");

                    b.Property<string>("Instructor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_Instructor");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAttdendees")
                        .HasColumnType("int")
                        .HasColumnName("Courses_MaxAttendees");

                    b.Property<DateTime>("RegistrationDeadline")
                        .HasColumnType("datetime2")
                        .HasColumnName("Courses_RegistrationDeadline");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Courses_Requirements");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Courses_StartDate");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.CourseDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Category_Id");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Courses_Id");

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Feedback", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Courses")
                        .WithMany("FeedBacks")
                        .HasForeignKey("CoursesId");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Order", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Courses")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CoursesId");

                    b.HasOne("EasyLearing.Infrastructure.Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.Navigation("Courses");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.ShoppingCart", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("EasyLearing.Infrastructure.Data.Entities.ShoppingCart", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Courses")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("CoursesId");

                    b.HasOne("EasyLearing.Infrastructure.Data.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItem")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Courses");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.TrainerDetail", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Courses")
                        .WithMany("trainerDetails")
                        .HasForeignKey("CoursesId");

                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Courses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.TrainingPart", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Courses")
                        .WithMany("TrainingParts")
                        .HasForeignKey("CoursesId");

                    b.HasOne("EasyLearing.Infrastructure.Data.Entities.CourseEvent", "CourseEvent")
                        .WithMany("TrainingParts")
                        .HasForeignKey("EventId");

                    b.Navigation("CourseEvent");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.AddOn", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Course")
                        .WithMany("AddOns")
                        .HasForeignKey("CoureseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.HasOne("EasyLearing.Infrastructure.Data.Entities.TrainerDetail", "TrainnerDetail")
                        .WithMany()
                        .HasForeignKey("TrainnerDetailId");

                    b.Navigation("TrainnerDetail");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.CourseDetail", b =>
                {
                    b.HasOne("EasyLearing.Infrastructure.Data.Entities.Category", "Category")
                        .WithMany("CoursesDetails")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.Course", "Course")
                        .WithMany("CoursesDetails")
                        .HasForeignKey("CourseId");

                    b.Navigation("Category");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Navigation("CoursesDetails");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.CourseEvent", b =>
                {
                    b.Navigation("TrainingParts");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EasyLearing.Infrastructure.Data.Entities.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItem");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("EasyLearning.Infrastructure.Data.Entities.Course", b =>
                {
                    b.Navigation("AddOns");

                    b.Navigation("CoursesDetails");

                    b.Navigation("FeedBacks");

                    b.Navigation("OrderDetails");

                    b.Navigation("ShoppingCartItems");

                    b.Navigation("trainerDetails");

                    b.Navigation("TrainingParts");
                });
#pragma warning restore 612, 618
        }
    }
}
