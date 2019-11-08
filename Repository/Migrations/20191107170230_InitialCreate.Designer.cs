﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using alex_krubicki_3Nov19.Repositories.Entities;

namespace Repositories.Migrations
{
    [DbContext(typeof(TakeAway2Context))]
    [Migration("20191107170230_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("alex_krubicki_3Nov19.Repositories.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CardId")
                        .HasColumnName("card_id");

                    b.Property<float>("Payment")
                        .HasColumnName("payment");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnName("payment_date");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("alex_krubicki_3Nov19.Repositories.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("company_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnName("company_name");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("alex_krubicki_3Nov19.Repositories.Entities.EmployeesCards", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("card_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BanksId");

                    b.Property<int>("CompanyId")
                        .HasColumnName("company_id");

                    b.Property<int>("LastDigit")
                        .HasColumnName("last_digit");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("CardId");

                    b.HasIndex("BanksId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("EmployeesCards");
                });

            modelBuilder.Entity("alex_krubicki_3Nov19.Repositories.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("alex_krubicki_3Nov19.Repositories.Entities.EmployeesCards", b =>
                {
                    b.HasOne("alex_krubicki_3Nov19.Repositories.Entities.Bank", "Banks")
                        .WithMany()
                        .HasForeignKey("BanksId");

                    b.HasOne("alex_krubicki_3Nov19.Repositories.Entities.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("alex_krubicki_3Nov19.Repositories.Entities.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
