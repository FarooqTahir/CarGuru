using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PushNotificationJob.model
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<APILogs> APILogs { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<ChatSession> ChatSession { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<CustomerCardDetail> CustomerCardDetail { get; set; }
        public virtual DbSet<CustomerInvoices> CustomerInvoices { get; set; }
        public virtual DbSet<CustomerPaymentDetail> CustomerPaymentDetail { get; set; }
        public virtual DbSet<CustomerTypes> CustomerTypes { get; set; }
        public virtual DbSet<CustomerVehicles> CustomerVehicles { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Fleets> Fleets { get; set; }
        public virtual DbSet<HelpRequests> HelpRequests { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<NotificationQueue> NotificationQueue { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsInQoutations> ProductsInQoutations { get; set; }
        public virtual DbSet<ProductsInServiceOrders> ProductsInServiceOrders { get; set; }
        public virtual DbSet<Qoutations> Qoutations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ServiceOrders> ServiceOrders { get; set; }
        public virtual DbSet<ServicesInOrder> ServicesInOrder { get; set; }
        public virtual DbSet<TechnicianDetails> TechnicianDetails { get; set; }
        public virtual DbSet<UserDevices> UserDevices { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=162.220.51.67;Database=CarGuru;User Id=carguruadmin; Password=admin@123;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APILogs>(entity =>
            {
                entity.Property(e => e.ActionName).HasMaxLength(250);

                entity.Property(e => e.ControllerName).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IPAddress).HasMaxLength(250);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.CheckIn).HasColumnType("smalldatetime");

                entity.Property(e => e.CheckOut).HasColumnType("smalldatetime");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ChatSession>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.SessionId).HasMaxLength(500);
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Message).IsRequired();
            });

            modelBuilder.Entity<CustomerCardDetail>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerInvoices>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CustomerInvoices)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerInvoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustomerPaymentDetail>(entity =>
            {
                entity.Property(e => e.ChargeId).HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<CustomerTypes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerVehicles>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LicensePlateNumber).HasMaxLength(55);

                entity.Property(e => e.Make).HasMaxLength(100);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Mulkia).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VIN).HasMaxLength(30);

                entity.Property(e => e.Year).HasMaxLength(20);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CustomerVehicles)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerVehicles)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.BillingAddress).HasMaxLength(255);

                entity.Property(e => e.MulkiaNumber).HasMaxLength(50);

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTypeId);

                entity.HasOne(d => d.CustomerTypeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTypeId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(150);
            });

            modelBuilder.Entity<Fleets>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PlateNo).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Vin).HasMaxLength(100);
            });

            modelBuilder.Entity<HelpRequests>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HelpRequest)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Lookups>(entity =>
            {
                entity.Property(e => e.LookupTitle).HasMaxLength(30);

                entity.Property(e => e.LookupType).HasMaxLength(30);

                entity.Property(e => e.LookupValue).HasMaxLength(30);
            });

            modelBuilder.Entity<NotificationQueue>(entity =>
            {
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NotificationType).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LeastPrice).HasColumnType("money");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductDiscount).HasMaxLength(50);

                entity.Property(e => e.QrCode)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.RegularPrice).HasColumnType("money");

                entity.Property(e => e.SalePrice).HasColumnType("money");

                entity.Property(e => e.SkuNo).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductsInQoutations>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsInQoutations)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Qoutation)
                    .WithMany(p => p.ProductsInQoutations)
                    .HasForeignKey(d => d.QoutationId);
            });

            modelBuilder.Entity<ProductsInServiceOrders>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ServiceOrderId });

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductMargin).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsInServiceOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInServiceOrderes_Products_ProductId");
            });

            modelBuilder.Entity<Qoutations>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.Latitude).HasMaxLength(100);

                entity.Property(e => e.Longitude).HasMaxLength(100);

                entity.Property(e => e.QutationType).HasMaxLength(255);

                entity.Property(e => e.ShippingAdress).HasMaxLength(500);

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Qoutations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(55);
            });

            modelBuilder.Entity<ServiceOrders>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.ReceivedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ScheduleDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ServiceOrderNo).HasMaxLength(20);

                entity.Property(e => e.ShippingAddress).HasMaxLength(255);

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ServicesInOrder>(entity =>
            {
                entity.HasKey(e => new { e.ServiceTypeId, e.ServiceOrderId });

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<TechnicianDetails>(entity =>
            {
                entity.Property(e => e.Fees).HasColumnType("money");

                entity.Property(e => e.Latitude).HasMaxLength(100);

                entity.Property(e => e.Longitude).HasMaxLength(100);
            });

            modelBuilder.Entity<UserDevices>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DeviceTypeId, e.DeviceToken })
                    .HasName("PK_AuthUser");

                entity.Property(e => e.DeviceToken).HasMaxLength(400);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.Password).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SessionId).HasMaxLength(500);

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.Property(e => e.BusinessAddress).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreditCardLimit).HasColumnType("money");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
