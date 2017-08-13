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
    [Migration("20170813080101_CreatePollsAndPagesAndComments")]
    partial class CreatePollsAndPagesAndComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
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

                    b.ToTable("Comment");
                });

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

                    b.HasKey("ID");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("kaigang.Models.Entities.Comment", b =>
                {
                    b.HasOne("kaigang.Models.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kaigang.Models.Entities.Post", b =>
                {
                    b.HasOne("kaigang.Models.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
