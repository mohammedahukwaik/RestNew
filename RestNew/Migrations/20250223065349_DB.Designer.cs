﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestNew.Data;

#nullable disable

namespace RestNew.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250223065349_DB")]
    partial class DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RestNew.Models.MasterCategoryMenu", b =>
                {
                    b.Property<int>("MasterCategoryMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterCategoryMenuId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterCategoryMenuName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterCategoryMenuId");

                    b.ToTable("MasterCategoryMenus");
                });

            modelBuilder.Entity("RestNew.Models.MasterContactUsInformation", b =>
                {
                    b.Property<int>("MasterContactUsInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterContactUsInformationId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterContactUsInformationIdesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterContactUsInformationImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterContactUsInformationRedirect")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterContactUsInformationId");

                    b.ToTable("MasterContactUsInformations");
                });

            modelBuilder.Entity("RestNew.Models.MasterItemMenu", b =>
                {
                    b.Property<int>("MasterItemMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterItemMenuId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MasterCategoryMenuId")
                        .HasColumnType("int");

                    b.Property<string>("MasterItemMenuBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MasterItemMenuDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MasterItemMenuDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterItemMenuImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MasterItemMenuPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MasterItemMenuTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterItemMenuId");

                    b.HasIndex("MasterCategoryMenuId");

                    b.ToTable("MasterItemMenus");
                });

            modelBuilder.Entity("RestNew.Models.MasterMenu", b =>
                {
                    b.Property<int>("MasterMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterMenuId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterMenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterMenuId");

                    b.ToTable("MasterMenus");
                });

            modelBuilder.Entity("RestNew.Models.MasterOffer", b =>
                {
                    b.Property<int>("MasterOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterOfferId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterOfferBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterOfferId");

                    b.ToTable("MasterOffers");
                });

            modelBuilder.Entity("RestNew.Models.MasterPartner", b =>
                {
                    b.Property<int>("MasterPartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterPartnerId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterPartnerLogoImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterPartnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterPartnerWebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterPartnerId");

                    b.ToTable("MasterPartners");
                });

            modelBuilder.Entity("RestNew.Models.MasterServices", b =>
                {
                    b.Property<int>("MasterServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterServicesId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterServicesDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterServicesImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterServicesTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterServicesId");

                    b.ToTable("MasterServices");
                });

            modelBuilder.Entity("RestNew.Models.MasterSlider", b =>
                {
                    b.Property<int>("MasterSliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterSliderId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterSliderBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterSliderId");

                    b.ToTable("MasterSliders");
                });

            modelBuilder.Entity("RestNew.Models.MasterSocialMedia", b =>
                {
                    b.Property<int>("MasterSocialMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterSocialMediaId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterSocialMediaClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSocialMediaImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSocialMediaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterSocialMediaId");

                    b.ToTable("MasterSocialMedia");
                });

            modelBuilder.Entity("RestNew.Models.MasterWorkingHours", b =>
                {
                    b.Property<int>("MasterWorkingHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterWorkingHoursId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterWorkingHoursIdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterWorkingHoursIdTimeFormTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterWorkingHoursId");

                    b.ToTable("MasterWorkingHours");
                });

            modelBuilder.Entity("RestNew.Models.SystemSetting", b =>
                {
                    b.Property<int>("SystemSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemSettingId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SystemSettingCopyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingLogoImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingLogoImageUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingMapLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemSettingId");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("RestNew.Models.TransactionBookTable", b =>
                {
                    b.Property<int>("TransactionBookTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionBookTableId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionBookTableDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionBookTableEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionBookTableFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionBookTableMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionBookTableId");

                    b.ToTable("TransactionBookTables");
                });

            modelBuilder.Entity("RestNew.Models.TransactionContactUs", b =>
                {
                    b.Property<int>("TransactionContactUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionContactUsId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsSubject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionContactUsId");

                    b.ToTable("TransactionContactUs");
                });

            modelBuilder.Entity("RestNew.Models.TransactionNewsletter", b =>
                {
                    b.Property<int>("TransactionNewsletterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionNewsletterId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionNewsletterEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionNewsletterId");

                    b.ToTable("TransactionNewsletters");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestNew.Models.MasterItemMenu", b =>
                {
                    b.HasOne("RestNew.Models.MasterCategoryMenu", "MasterCategoryMenu")
                        .WithMany()
                        .HasForeignKey("MasterCategoryMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterCategoryMenu");
                });
#pragma warning restore 612, 618
        }
    }
}
