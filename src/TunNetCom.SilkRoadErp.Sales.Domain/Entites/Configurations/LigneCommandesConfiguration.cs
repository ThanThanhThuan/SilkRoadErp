﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TunNetCom.SilkRoadErp.Sales.Domain.Entites;

#nullable disable

namespace TunNetCom.SilkRoadErp.Sales.Domain.Entites.Configurations
{
    public partial class LigneCommandesConfiguration : IEntityTypeConfiguration<LigneCommandes>
    {
        public void Configure(EntityTypeBuilder<LigneCommandes> entity)
        {
            entity.HasKey(e => e.IdLi).HasName("PK_dbo.LigneCommandes");

            entity.Property(e => e.IdLi).HasColumnName("Id_li");
            entity.Property(e => e.DesignationLi).HasColumnName("designation_li");
            entity.Property(e => e.NumCommande).HasColumnName("Num_commande");
            entity.Property(e => e.PrixHt)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("prix_HT");
            entity.Property(e => e.QteLi).HasColumnName("qte_li");
            entity.Property(e => e.RefProduit)
            .HasMaxLength(50)
            .HasColumnName("Ref_Produit");
            entity.Property(e => e.Remise).HasColumnName("remise");
            entity.Property(e => e.TotHt)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("tot_HT");
            entity.Property(e => e.TotTtc)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("tot_TTC");
            entity.Property(e => e.Tva).HasColumnName("tva");

            entity.HasOne(d => d.NumCommandeNavigation).WithMany(p => p.LigneCommandes)
            .HasForeignKey(d => d.NumCommande)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_dbo.LigneCommandes_dbo.Commandes_Num_commande");

            entity.HasOne(d => d.RefProduitNavigation).WithMany(p => p.LigneCommandes)
            .HasForeignKey(d => d.RefProduit)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_dbo.LigneCommandes_dbo.Produit_Ref_Produit");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<LigneCommandes> entity);
    }
}
