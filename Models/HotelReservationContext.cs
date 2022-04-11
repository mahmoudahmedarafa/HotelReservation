using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelReservation.Models
{
    public partial class HotelReservationContext : DbContext
    {
        public HotelReservationContext(DbContextOptions<HotelReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MealRates> MealRates { get; set; }
        public virtual DbSet<RoomRates> RoomRates { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.RoomRatesRooms'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelReservation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            //for (int i = 1; i <= 15; i++)
            //{
            //    modelBuilder.Entity<Rooms>().HasData(
            //            new Rooms
            //            {
            //                Id = i,
            //                RoomType = "Standard",
            //                CheckInDate = null,
            //                CheckOutDate = null,
            //                IsReserved = false
            //            }
            //        );
            //}

            //for (int i = 16; i <= 30; i++)
            //{
            //    modelBuilder.Entity<Rooms>().HasData(
            //            new Rooms
            //            {
            //                Id = i,
            //                RoomType = "SeaView",
            //                CheckInDate = null,
            //                CheckOutDate = null,
            //                IsReserved = false
            //            }
            //        );
            //}

            //for (int i = 31; i <= 45; i++)
            //{
            //    modelBuilder.Entity<Rooms>().HasData(
            //            new Rooms
            //            {
            //                Id = i,
            //                RoomType = "PoolView",
            //                CheckInDate = null,
            //                CheckOutDate = null,
            //                IsReserved = false
            //            }
            //        );
            //}


            modelBuilder.Entity<RoomRates>().HasData(
                        new RoomRates
                        {
                            Id = 1,
                            RoomType = "Standard",
                            DateFrom = new DateTime(2022, 1, 1),
                            DateTo = new DateTime(2022, 1, 15),
                            RatePerRoom = 80
                        },
                        new RoomRates
                        {
                            Id = 2,
                            RoomType = "Standard",
                            DateFrom = new DateTime(2022, 1, 16),
                            DateTo = new DateTime(2022, 4, 30),
                            RatePerRoom = 50
                        },
                        new RoomRates
                        {
                            Id = 3,
                            RoomType = "SeaView",
                            DateFrom = new DateTime(2022, 1, 1),
                            DateTo = new DateTime(2022, 1, 15),
                            RatePerRoom = 120
                        },
                        new RoomRates
                        {
                            Id = 4,
                            RoomType = "SeaView",
                            DateFrom = new DateTime(2022, 1, 16),
                            DateTo = new DateTime(2022, 3, 31),
                            RatePerRoom = 90
                        },
                        new RoomRates
                        {
                            Id = 5,
                            RoomType = "SeaView",
                            DateFrom = new DateTime(2022, 4, 1),
                            DateTo = new DateTime(2022, 4, 30),
                            RatePerRoom = 100
                        }
                );

            modelBuilder.Entity<MealRates>().HasData(
                    new MealRates
                    {
                        Id = 1,
                        MealPlan = "HalfBoard",
                        LowSeasonRate = 5,
                        HighSeasonRate = 10
                    },
                    new MealRates
                    {
                        Id = 2,
                        MealPlan = "FullBoard",
                        LowSeasonRate = 20,
                        HighSeasonRate = 25
                    },
                    new MealRates
                    {
                        Id = 3,
                        MealPlan = "AllInclusive",
                        LowSeasonRate = 25,
                        HighSeasonRate = 30
                    }
            );

            modelBuilder.Entity<MealRates>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MealPlan)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomRates>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Users_Rooms");
            });
        }
    }
}
