﻿// <auto-generated />
using System;
using JMR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JMR.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20220507184028_fixedValidationIg")]
    partial class fixedValidationIg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("JMR.Models.Credentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hashedpassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("credentials");
                });

            modelBuilder.Entity("JMR.Models.IUser", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JMR.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("maxPay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("minPay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timeFrame")
                        .HasColumnType("INTEGER");

                    b.Property<string>("timeUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("JMR.Models.PostIdSkillId", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("postId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("skillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PostSkillIds");
                });

            modelBuilder.Entity("JMR.Models.RequiredSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("skillName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequiredSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
