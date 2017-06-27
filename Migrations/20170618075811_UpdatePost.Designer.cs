using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kaigang.Models.Entities;

namespace kaigang.Migrations
{
    [DbContext(typeof(KaigangContext))]
    [Migration("20170618075811_UpdatePost")]
    partial class UpdatePost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("kaigang.Models.Entities.Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<bool>("IsDraft");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Posts");
                });
        }
    }
}
