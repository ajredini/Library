namespace LibraryMenagmentApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCopy> BookCopies { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Lending> Lendings { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookCopies)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.FK_Book);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Lendings)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.FK_Book);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Lendings)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.FK_Client);

            modelBuilder.Entity<Library>()
                .HasMany(e => e.BookCopies)
                .WithOptional(e => e.Library)
                .HasForeignKey(e => e.FK_Library);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Publisher)
                .HasForeignKey(e => e.FK_Publisher);
        }
    }
}
