﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.DB;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231212064823_AddNewsPhotosUrl")]
    partial class AddNewsPhotosUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CouncilCouncilMember", b =>
                {
                    b.Property<int>("CouncilMembersId")
                        .HasColumnType("integer");

                    b.Property<int>("CouncilsId")
                        .HasColumnType("integer");

                    b.HasKey("CouncilMembersId", "CouncilsId");

                    b.HasIndex("CouncilsId");

                    b.ToTable("CouncilCouncilMember");
                });

            modelBuilder.Entity("CouncilMemberWorkPlan", b =>
                {
                    b.Property<int>("ResponsibleMembersId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkPlansId")
                        .HasColumnType("integer");

                    b.HasKey("ResponsibleMembersId", "WorkPlansId");

                    b.HasIndex("WorkPlansId");

                    b.ToTable("CouncilMemberWorkPlan");
                });

            modelBuilder.Entity("Domain.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Domain.Entities.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdvertisementId")
                        .HasColumnType("integer");

                    b.Property<string>("CoSpeakers")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("NewsId")
                        .HasColumnType("integer");

                    b.Property<string>("Speakers")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("NewsId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("Domain.Entities.ConstituentDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocumentUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("ConstituentDocuments");
                });

            modelBuilder.Entity("Domain.Entities.Council", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("Councils");
                });

            modelBuilder.Entity("Domain.Entities.CouncilMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CouncilMemberUniversityPositionId")
                        .HasColumnType("integer");

                    b.Property<int>("CouncilPositionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScienceDegree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UniversityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("CouncilMemberUniversityPositionId");

                    b.HasIndex("CouncilPositionId");

                    b.HasIndex("UniversityId");

                    b.ToTable("CouncilMembers");
                });

            modelBuilder.Entity("Domain.Entities.CouncilMemberUniversityPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CouncilMemberUniversityPositions");
                });

            modelBuilder.Entity("Domain.Entities.CouncilPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CouncilPositions");
                });

            modelBuilder.Entity("Domain.Entities.InformationDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CouncilId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string[]>("DocumentUrl")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("InformationDocumentTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("CouncilId");

                    b.HasIndex("InformationDocumentTypeId");

                    b.ToTable("InformationDocuments");
                });

            modelBuilder.Entity("Domain.Entities.InformationDocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InformationDocumentTypes");
                });

            modelBuilder.Entity("Domain.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("PhotosUrl")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CouncilMemberId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFax")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTelegram")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWhatsApp")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CouncilMemberId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Domain.Entities.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Domain.Entities.WorkPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CouncilId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("CouncilId");

                    b.ToTable("WorkPlans");
                });

            modelBuilder.Entity("CouncilCouncilMember", b =>
                {
                    b.HasOne("Domain.Entities.CouncilMember", null)
                        .WithMany()
                        .HasForeignKey("CouncilMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Council", null)
                        .WithMany()
                        .HasForeignKey("CouncilsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CouncilMemberWorkPlan", b =>
                {
                    b.HasOne("Domain.Entities.CouncilMember", null)
                        .WithMany()
                        .HasForeignKey("ResponsibleMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WorkPlan", null)
                        .WithMany()
                        .HasForeignKey("WorkPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Agenda", b =>
                {
                    b.HasOne("Domain.Entities.Advertisement", null)
                        .WithMany("Agendas")
                        .HasForeignKey("AdvertisementId");

                    b.HasOne("Domain.Entities.News", null)
                        .WithMany("Agendas")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("Domain.Entities.CouncilMember", b =>
                {
                    b.HasOne("Domain.Entities.CouncilMemberUniversityPosition", "CouncilMemberUniversityPosition")
                        .WithMany()
                        .HasForeignKey("CouncilMemberUniversityPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CouncilPosition", "CouncilPosition")
                        .WithMany()
                        .HasForeignKey("CouncilPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CouncilMemberUniversityPosition");

                    b.Navigation("CouncilPosition");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.Entities.InformationDocument", b =>
                {
                    b.HasOne("Domain.Entities.Council", "Council")
                        .WithMany()
                        .HasForeignKey("CouncilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.InformationDocumentType", "InformationDocumentType")
                        .WithMany()
                        .HasForeignKey("InformationDocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Council");

                    b.Navigation("InformationDocumentType");
                });

            modelBuilder.Entity("Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("Domain.Entities.CouncilMember", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("CouncilMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.WorkPlan", b =>
                {
                    b.HasOne("Domain.Entities.Council", "Council")
                        .WithMany()
                        .HasForeignKey("CouncilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Council");
                });

            modelBuilder.Entity("Domain.Entities.Advertisement", b =>
                {
                    b.Navigation("Agendas");
                });

            modelBuilder.Entity("Domain.Entities.CouncilMember", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("Domain.Entities.News", b =>
                {
                    b.Navigation("Agendas");
                });
#pragma warning restore 612, 618
        }
    }
}
