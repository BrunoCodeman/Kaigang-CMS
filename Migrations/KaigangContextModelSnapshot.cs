using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kaigang.Models.Entities;

namespace kaigang.Migrations
{
    [DbContext(typeof(KaigangContext))]
    partial class KaigangContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
<<<<<<< HEAD
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("kaigang.Models.Entities.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorID");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("kaigang.Models.Entities.Page", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("kaigang.Models.Entities.Poll", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<JsonObject<IDictionary<string, int>>>("Options");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Polls");
                });
=======
                .HasAnnotation("ProductVersion", "1.1.1");
>>>>>>> 6f95a84deafe7d06a3321b118e8898536ea9454c

            modelBuilder.Entity("kaigang.Models.Entities.Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorID");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<bool>("IsDraft");

                    b.Property<DateTime>("PublishDate");

                    b.Property<JsonObject<List<string>>>("Tags")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("kaigang.Models.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name");

<<<<<<< HEAD
                    b.Property<Guid?>("PollID");

                    b.HasKey("ID");

                    b.HasAlternateKey("Email");

                    b.HasIndex("PollID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("kaigang.Models.Entities.Comment", b =>
                {
                    b.HasOne("kaigang.Models.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

=======
                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

>>>>>>> 6f95a84deafe7d06a3321b118e8898536ea9454c
            modelBuilder.Entity("kaigang.Models.Entities.Post", b =>
                {
                    b.HasOne("kaigang.Models.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
<<<<<<< HEAD

            modelBuilder.Entity("kaigang.Models.Entities.User", b =>
                {
                    b.HasOne("kaigang.Models.Entities.Poll")
                        .WithMany("Voters")
                        .HasForeignKey("PollID");
                });
=======
>>>>>>> 6f95a84deafe7d06a3321b118e8898536ea9454c
        }
    }
}
