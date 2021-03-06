﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieGram.Data;

namespace MovieGram.Data.Migrations
{
    [DbContext(typeof(MovieGramContext))]
    partial class MovieGramContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieGram.Data.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cinema");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cinema1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cinema2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cinema3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cinema4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cinema5"
                        });
                });

            modelBuilder.Entity("MovieGram.Data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Plot");

                    b.Property<int>("Rating");

                    b.Property<string>("ThumbnailUrl");

                    b.HasKey("Id");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullImageUrl = "http://test.com/content/images/Movie1.png",
                            Name = "Movie1",
                            Plot = "Plot1",
                            Rating = 4,
                            ThumbnailUrl = "http://test.com/content/thumbs/Movie1.png"
                        },
                        new
                        {
                            Id = 2,
                            FullImageUrl = "http://test.com/content/images/Movie2.png",
                            Name = "Movie2",
                            Plot = "Plot2",
                            Rating = 3,
                            ThumbnailUrl = "http://test.com/content/thumbs/Movie2.png"
                        },
                        new
                        {
                            Id = 3,
                            FullImageUrl = "http://test.com/content/images/Movie3.png",
                            Name = "Movie3",
                            Plot = "Plot3",
                            Rating = 2,
                            ThumbnailUrl = "http://test.com/content/thumbs/Movie3.png"
                        },
                        new
                        {
                            Id = 4,
                            FullImageUrl = "http://test.com/content/images/Movie4.png",
                            Name = "Movie4",
                            Plot = "Plot4",
                            Rating = 1,
                            ThumbnailUrl = "http://test.com/content/thumbs/Movie4.png"
                        },
                        new
                        {
                            Id = 5,
                            FullImageUrl = "http://test.com/content/images/Movie5.png",
                            Name = "Movie5",
                            Plot = "Plot5",
                            Rating = 5,
                            ThumbnailUrl = "http://test.com/content/thumbs/Movie5.png"
                        });
                });

            modelBuilder.Entity("MovieGram.Data.Movie", b =>
                {
                    b.OwnsMany("MovieGram.Data.ShowTime", "ShowTimes", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("CinemaId");

                            b1.Property<int>("MovieId");

                            b1.Property<DateTime>("Time");

                            b1.HasKey("Id");

                            b1.HasIndex("CinemaId");

                            b1.HasIndex("MovieId");

                            b1.ToTable("ShowTime");

                            b1.HasOne("MovieGram.Data.Cinema", "Cinema")
                                .WithMany()
                                .HasForeignKey("CinemaId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasOne("MovieGram.Data.Movie", "Movie")
                                .WithMany("ShowTimes")
                                .HasForeignKey("MovieId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    Id = 1,
                                    CinemaId = 1,
                                    MovieId = 1,
                                    Time = new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 2,
                                    CinemaId = 1,
                                    MovieId = 1,
                                    Time = new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 3,
                                    CinemaId = 1,
                                    MovieId = 1,
                                    Time = new DateTime(2019, 7, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 4,
                                    CinemaId = 5,
                                    MovieId = 2,
                                    Time = new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 5,
                                    CinemaId = 4,
                                    MovieId = 3,
                                    Time = new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 6,
                                    CinemaId = 3,
                                    MovieId = 3,
                                    Time = new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 7,
                                    CinemaId = 4,
                                    MovieId = 4,
                                    Time = new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 8,
                                    CinemaId = 3,
                                    MovieId = 4,
                                    Time = new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 9,
                                    CinemaId = 2,
                                    MovieId = 4,
                                    Time = new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                },
                                new
                                {
                                    Id = 10,
                                    CinemaId = 2,
                                    MovieId = 5,
                                    Time = new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified)
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
