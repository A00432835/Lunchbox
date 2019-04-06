namespace LunchBox
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=lunchbox_model")
        {
        }

        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<orderDetail> orderDetails { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<profile> profiles { get; set; }
        public virtual DbSet<scheduleType> scheduleTypes { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<discount>()
                .Property(e => e.couponCode)
                .IsUnicode(false);

            modelBuilder.Entity<discount>()
                .HasMany(e => e.payments)
                .WithOptional(e => e.discount)
                .HasForeignKey(e => e.discountID);

            modelBuilder.Entity<item>()
                .Property(e => e.snackType)
                .IsFixedLength();

            modelBuilder.Entity<item>()
                .Property(e => e.snackState)
                .IsFixedLength();

            modelBuilder.Entity<order>()
                .Property(e => e.orderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.orderDate)
                .IsFixedLength();

            modelBuilder.Entity<payment>()
                .Property(e => e.nameOnCard)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.cardType)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.expiryDate)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.city)
                .IsFixedLength();

            modelBuilder.Entity<profile>()
                .Property(e => e.province)
                .IsFixedLength();

            modelBuilder.Entity<profile>()
                .Property(e => e.country)
                .IsFixedLength();

            modelBuilder.Entity<profile>()
                .Property(e => e.pic_url)
                .IsUnicode(false);

            modelBuilder.Entity<scheduleType>()
                .Property(e => e.scheduleType1)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.f_name)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.l_name)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.profiles)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
