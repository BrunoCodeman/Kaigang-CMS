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
                .HasAnnotation("ProductVersion", "1.1.1");

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

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");
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
