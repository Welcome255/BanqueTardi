﻿// <auto-generated />
using System;
using BanqueTardi.ContexteDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BanqueTardi.Migrations
{
    [DbContext(typeof(BanqueTardiContexte))]
    partial class BanqueTardiContexteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Assurance.ApplicationCore.Entites.AssuranceTardi", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CodePartenaire")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CodeRabais")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EstDiabetique")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstFumeur")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstHypertendu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PratiqueActivitePhysique")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrenomClient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Sexe")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Solde")
                        .HasColumnType("REAL");

                    b.Property<bool>("Statut")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("AssuranceClient");
                });

            modelBuilder.Entity("BanqueTardi.Models.Client", b =>
                {
                    b.Property<string>("ClientID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<int>("NbDecouverts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomParent")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrenomClient")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelephoneParent")
                        .HasColumnType("TEXT");

                    b.HasKey("ClientID");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("BanqueTardi.Models.Compte", b =>
                {
                    b.Property<string>("CompteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Identifiant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCompte")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Solde")
                        .HasColumnType("REAL");

                    b.Property<int>("TauxInteret")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TauxInteretDecouvert")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeCompte")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompteID");

                    b.HasIndex("ClientID");

                    b.ToTable("Compte", (string)null);
                });

            modelBuilder.Entity("BanqueTardi.Models.Operation", b =>
                {
                    b.Property<int>("OperationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompteID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Montant")
                        .HasColumnType("REAL");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("INTEGER");

                    b.HasKey("OperationID");

                    b.HasIndex("CompteID");

                    b.ToTable("Operation", (string)null);
                });

            modelBuilder.Entity("BanqueTardi.Models.Compte", b =>
                {
                    b.HasOne("BanqueTardi.Models.Client", "Client")
                        .WithMany("Comptes")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BanqueTardi.Models.Operation", b =>
                {
                    b.HasOne("BanqueTardi.Models.Compte", "Compte")
                        .WithMany("Operations")
                        .HasForeignKey("CompteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");
                });

            modelBuilder.Entity("BanqueTardi.Models.Client", b =>
                {
                    b.Navigation("Comptes");
                });

            modelBuilder.Entity("BanqueTardi.Models.Compte", b =>
                {
                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
