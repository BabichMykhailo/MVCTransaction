using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransactionMVCContext : DbContext
    {
        public TransactionMVCContext() : base("name = DefaultConnection")
        {
            //Database.SetInitializer(new TransactionMVCInitializer());
            //new TransactionMVCInitializer().Initialize(this);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Transactions);
        }
    }
}
