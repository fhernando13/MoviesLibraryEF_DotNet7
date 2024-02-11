﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movieLibrary;

#nullable disable

namespace movieLibrary.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231009005811_nickname")]
    partial class nickname
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenderMovie", b =>
                {
                    b.Property<int>("GendersIdgender")
                        .HasColumnType("int");

                    b.Property<int>("MoviesIdmovie")
                        .HasColumnType("int");

                    b.HasKey("GendersIdgender", "MoviesIdmovie");

                    b.HasIndex("MoviesIdmovie");

                    b.ToTable("GenderMovie");
                });

            modelBuilder.Entity("movieLibrary.Entities.Actor", b =>
                {
                    b.Property<int>("Idactor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idactor"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<decimal>("Fortune")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idactor");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("movieLibrary.Entities.Comment", b =>
                {
                    b.Property<int>("Idcomment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcomment"));

                    b.Property<string>("Comments")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Movieid")
                        .HasColumnType("int");

                    b.Property<bool>("Recommend")
                        .HasColumnType("bit");

                    b.HasKey("Idcomment");

                    b.HasIndex("Movieid");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("movieLibrary.Entities.Gender", b =>
                {
                    b.Property<int>("Idgender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idgender"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idgender");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("movieLibrary.Entities.Movie", b =>
                {
                    b.Property<int>("Idmovie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idmovie"));

                    b.Property<DateTime>("Daterelease")
                        .HasColumnType("date");

                    b.Property<bool>("Oncinema")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idmovie");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("movieLibrary.Entities.MovieActor", b =>
                {
                    b.Property<int>("Actorid")
                        .HasColumnType("int");

                    b.Property<int>("Movieid")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Actorid", "Movieid");

                    b.HasIndex("Movieid");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("movieLibrary.Entities.User", b =>
                {
                    b.Property<int>("Iduser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Iduser"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Token")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Iduser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenderMovie", b =>
                {
                    b.HasOne("movieLibrary.Entities.Gender", null)
                        .WithMany()
                        .HasForeignKey("GendersIdgender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieLibrary.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesIdmovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("movieLibrary.Entities.Comment", b =>
                {
                    b.HasOne("movieLibrary.Entities.Movie", "Movie")
                        .WithMany("Commentss")
                        .HasForeignKey("Movieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("movieLibrary.Entities.MovieActor", b =>
                {
                    b.HasOne("movieLibrary.Entities.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("Actorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieLibrary.Entities.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("Movieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("movieLibrary.Entities.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("movieLibrary.Entities.Movie", b =>
                {
                    b.Navigation("Commentss");

                    b.Navigation("MovieActors");
                });
#pragma warning restore 612, 618
        }
    }
}