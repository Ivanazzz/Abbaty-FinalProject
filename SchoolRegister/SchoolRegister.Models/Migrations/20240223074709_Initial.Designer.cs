﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolRegister.Models;

#nullable disable

namespace SchoolRegister.Models.Migrations
{
    [DbContext(typeof(SchoolRegisterDbContext))]
    [Migration("20240223074709_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SchoolRegister.Models.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<int>("BirthPlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("birthplaceid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text")
                        .HasColumnName("middlename");

                    b.Property<string>("Uic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uic");

                    b.HasKey("Id");

                    b.HasIndex("BirthPlaceId");

                    b.HasIndex("Uic")
                        .IsUnique();

                    b.ToTable("person");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.PersonHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("actiondate");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<int>("DataModified")
                        .HasColumnType("integer")
                        .HasColumnName("datamodified");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("personid");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserId");

                    b.ToTable("personhistory");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.PersonSchool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("enddate");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("personid");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasColumnName("position");

                    b.Property<int>("SchoolId")
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("startdate");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SchoolId");

                    b.ToTable("personschool");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isactive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NameAlt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("namealt");

                    b.Property<int>("SettlementId")
                        .HasColumnType("integer")
                        .HasColumnName("settlementid");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("SettlementId");

                    b.ToTable("school");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.Settlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<string>("Ekatte")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ekatte");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isactive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NameAlt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("namealt");

                    b.HasKey("Id");

                    b.HasIndex("Ekatte")
                        .IsUnique();

                    b.ToTable("settlement");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer")
                        .HasColumnName("creatoruserid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isactive");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("passwordhash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("passwordsalt");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("SchoolId")
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.Person", b =>
                {
                    b.HasOne("SchoolRegister.Models.Entities.Settlement", "BirthPlace")
                        .WithMany()
                        .HasForeignKey("BirthPlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BirthPlace");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.PersonHistory", b =>
                {
                    b.HasOne("SchoolRegister.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolRegister.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.PersonSchool", b =>
                {
                    b.HasOne("SchoolRegister.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolRegister.Models.Entities.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.School", b =>
                {
                    b.HasOne("SchoolRegister.Models.Entities.Settlement", "Settlement")
                        .WithMany()
                        .HasForeignKey("SettlementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Settlement");
                });

            modelBuilder.Entity("SchoolRegister.Models.Entities.User", b =>
                {
                    b.HasOne("SchoolRegister.Models.Entities.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");
                });
#pragma warning restore 612, 618
        }
    }
}
