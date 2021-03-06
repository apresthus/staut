﻿using System.Data.Entity;
using Teller.Core.Entities;

namespace Teller.Persistance
{
    public class TellerContext : DbContext
    {
        /// <summary>
        /// Kampene vi teller
        /// </summary>
        public DbSet<BillettServiceEvent> Events { get; set; }

        /// <summary>
        /// Målinger gjort på kamper
        /// </summary>
        public DbSet<Measurement> Measurements { get; set; }

        /// <summary>
        /// Chat-meldinger
        /// </summary>
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public TellerContext()
            : base("STAut")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TellerContext>(new NullDatabaseInitializer<TellerContext>());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BillettServiceEvent>()
                        .ToTable("events");
            modelBuilder.Entity<Measurement>()
                        .ToTable("measurements");
            modelBuilder.Entity<ChatMessage>()
                        .ToTable("chatmessages");
        }
    }
}
