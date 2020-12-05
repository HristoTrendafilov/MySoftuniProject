﻿// <auto-generated />
using System;
using AllAboutGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllAboutGames.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201205154055_AddedCommentsAndReviewsToUser")]
    partial class AddedCommentsAndReviewsToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.CommentForGame", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentsForGames");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Developer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeveloperId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RatingsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameGenre", b =>
                {
                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("GamesGenres");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameLanguage", b =>
                {
                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("GameId", "LanguageId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("LanguageId");

                    b.ToTable("GamesLanguages");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GamePlatform", b =>
                {
                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlatformId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamesPlatforms");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Platform", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeveloperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RatingId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("RatingId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.City", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.CommentForGame", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("Comments")
                        .HasForeignKey("GameId");

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("CommentsGames")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Game", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameGenre", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Genre", "Genre")
                        .WithMany("GamesGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameLanguage", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("GameLanguages")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Language", "Language")
                        .WithMany("GamesLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GamePlatform", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Platform", "Platform")
                        .WithMany("GamesPlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Platform", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Rating", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("Ratings")
                        .HasForeignKey("GameId");

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Review", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "ReviewedBy")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
