using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext  //Veritabanını temsil ettiği için DbContext sınıfından miras aldık. 
    {
        public DbSet<Application> Applications { get; set; }  //Application alanını tabloya yansıtıp, tabloya applications ismini verme
        public DbSet<Apply> Applies { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ESignatureCertificate> ESignatureCertificates { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationPreference> NotificationPreferences { get; set; }
        public DbSet<NotificationRecord> NotificationRecords { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)  //base class dbcontext new lemek istendiğinde dbcontext options tipli bir parametre alacak.
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Eğer veritabanında veri yoksa veri oluşturur
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Notification>()
        .HasOne(n => n.Application)
        .WithMany(a => a.Notifications)
        .HasForeignKey(n => n.ApplicationID)
        .OnDelete(DeleteBehavior.Cascade);




            //modelBuilder.Entity<Application>().HasData(
            //    new Application() { ApplicationID = 1, CertificateID = 1512, EmployeeID = 1, Belgeler="html",BasvuruTarihi= new DateTime(2012, 01, 01) }, //Application modelinden newleyerek oluşturduk
            //    new Application() { ApplicationID = 2, CertificateID = 1678, EmployeeID = 1, Belgeler = "css",BasvuruTarihi = new DateTime(2012, 01, 01) },
            //    new Application() { ApplicationID = 3, CertificateID = 4531, EmployeeID = 1, Belgeler= "html", BasvuruTarihi = new DateTime(2012, 01, 01) },
            //    new Application() { ApplicationID = 4, CertificateID = 1578, EmployeeID = 1, Belgeler="c#", BasvuruTarihi = new DateTime(2012, 01, 01) },
            //    new Application() { ApplicationID = 5, CertificateID = 1284, EmployeeID = 1, Belgeler= "html", BasvuruTarihi = new DateTime(2012, 01, 01) }
            //);


        }
    }
}