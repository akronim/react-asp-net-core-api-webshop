﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopApiCore.Models;

namespace WebShopApiCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebShopApiCore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreditCard")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebShopApiCore.Models.FinalCostPromotion", b =>
                {
                    b.Property<int>("FinalCostPromotionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AbsoluteValue")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("Cumulative");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<decimal>("PercentageValue")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("FinalCostPromotionID");

                    b.ToTable("FinalCostPromotion");

                    b.HasData(
                        new
                        {
                            FinalCostPromotionID = 1,
                            AbsoluteValue = 0m,
                            Cumulative = false,
                            Description = "20% OFF",
                            PercentageValue = 20m
                        },
                        new
                        {
                            FinalCostPromotionID = 2,
                            AbsoluteValue = 0m,
                            Cumulative = true,
                            Description = "5% OFF",
                            PercentageValue = 5m
                        },
                        new
                        {
                            FinalCostPromotionID = 3,
                            AbsoluteValue = 20m,
                            Cumulative = true,
                            Description = "20 EURO FF",
                            PercentageValue = 0m
                        });
                });

            modelBuilder.Entity("WebShopApiCore.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ItemID");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemID = 1,
                            Name = "Smart Hub",
                            Price = 49.99m
                        },
                        new
                        {
                            ItemID = 2,
                            Name = "Motion Sensor",
                            Price = 24.99m
                        },
                        new
                        {
                            ItemID = 3,
                            Name = "Wireless Camera",
                            Price = 99.99m
                        },
                        new
                        {
                            ItemID = 4,
                            Name = "Smoke Sensor",
                            Price = 19.99m
                        },
                        new
                        {
                            ItemID = 5,
                            Name = "Water Leak Sensor",
                            Price = 14.99m
                        });
                });

            modelBuilder.Entity("WebShopApiCore.Models.ItemQuantityPromotion", b =>
                {
                    b.Property<int>("ItemQuantityPromotionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemID");

                    b.Property<int>("QuantityPromotionID");

                    b.HasKey("ItemQuantityPromotionID");

                    b.HasIndex("ItemID");

                    b.HasIndex("QuantityPromotionID");

                    b.ToTable("ItemQuantityPromotion");

                    b.HasData(
                        new
                        {
                            ItemQuantityPromotionID = 1,
                            ItemID = 2,
                            QuantityPromotionID = 1
                        },
                        new
                        {
                            ItemQuantityPromotionID = 2,
                            ItemID = 4,
                            QuantityPromotionID = 2
                        });
                });

            modelBuilder.Entity("WebShopApiCore.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebShopApiCore.Models.OrderFinalCostPromotion", b =>
                {
                    b.Property<int>("OrderFinalCostPromotionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FinalCostPromotionID");

                    b.Property<int>("OrderID");

                    b.HasKey("OrderFinalCostPromotionID");

                    b.HasIndex("FinalCostPromotionID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderFinalCostPromotion");
                });

            modelBuilder.Entity("WebShopApiCore.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemID");

                    b.Property<int>("OrderID");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("WebShopApiCore.Models.QuantityPromotion", b =>
                {
                    b.Property<int>("QuantityPromotionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<decimal>("PromoPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("PromoQuantity");

                    b.HasKey("QuantityPromotionID");

                    b.ToTable("QuantityPromotion");

                    b.HasData(
                        new
                        {
                            QuantityPromotionID = 1,
                            PromoPrice = 65m,
                            PromoQuantity = 3
                        },
                        new
                        {
                            QuantityPromotionID = 2,
                            PromoPrice = 35m,
                            PromoQuantity = 2
                        });
                });

            modelBuilder.Entity("WebShopApiCore.Models.ItemQuantityPromotion", b =>
                {
                    b.HasOne("WebShopApiCore.Models.Item", "Item")
                        .WithMany("ItemQuantityPromotions")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebShopApiCore.Models.QuantityPromotion", "QuantityPromotion")
                        .WithMany("ItemQuantityPromotions")
                        .HasForeignKey("QuantityPromotionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebShopApiCore.Models.Order", b =>
                {
                    b.HasOne("WebShopApiCore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebShopApiCore.Models.OrderFinalCostPromotion", b =>
                {
                    b.HasOne("WebShopApiCore.Models.FinalCostPromotion", "FinalCostPromotion")
                        .WithMany("OrderFinalCostPromotions")
                        .HasForeignKey("FinalCostPromotionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebShopApiCore.Models.Order", "Order")
                        .WithMany("OrderFinalCostPromotions")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebShopApiCore.Models.OrderItem", b =>
                {
                    b.HasOne("WebShopApiCore.Models.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebShopApiCore.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
