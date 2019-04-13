using baykuslar_api.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace baykuslar_api.Data
{
    public class BaykuslarDbContext : IdentityDbContext<UserEntity>
    {
        public BaykuslarDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public virtual DbSet<FundraisingPostEntity> FundraisingPosts { get; set; }
        public virtual DbSet<EquityFundingPostEntity> EquityFundingPosts { get; set; }
        public virtual DbSet<FundraisingDonationEntity> FundraisingDonations { get; set; }
        public virtual DbSet<EquityFundingInvestmentEntity> EquityFundingInvestments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // FundraisingDonation -> User-FundraisingPost many to many
            builder.Entity<FundraisingDonationEntity>()
                .HasKey(fd => new {fd.UserId, fd.FundraisingPostId});
            builder.Entity<FundraisingDonationEntity>()
                .HasOne(fd => fd.User)
                .WithMany(u => u.FundraisingDonations)
                .HasForeignKey(fd => fd.UserId);
            builder.Entity<FundraisingDonationEntity>()
                .HasOne(fd => fd.FundraisingPost)
                .WithMany(fp=> fp.FundraisingDonations)
                .HasForeignKey(fp => fp.FundraisingPostId);
            
            // EquityFundingInvestment -> User-EquityFundingPost many to many
            builder.Entity<EquityFundingInvestmentEntity>()
                .HasKey(efi => new {efi.UserId, efi.EquityFundingPostId});
            builder.Entity<EquityFundingInvestmentEntity>()
                .HasOne(efi => efi.User)
                .WithMany(u => u.EquityFundingInvestments)
                .HasForeignKey(efi => efi.UserId);
            builder.Entity<EquityFundingInvestmentEntity>()
                .HasOne(efi => efi.EquityFundingPost)
                .WithMany(efp => efp.EquityFundingInvestments)
                .HasForeignKey(efi => efi.EquityFundingPostId);
            
            base.OnModelCreating(builder);
        }
    }
}