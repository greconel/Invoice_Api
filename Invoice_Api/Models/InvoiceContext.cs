using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Invoice_Api.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Molunguri, A" },
                new Customer { CustomerId = 2, Name = "Muhinyi, Mauda" },
                new Customer { CustomerId = 3, Name = "Antony, Abdul" },
                new Customer { CustomerId = 4, Name = "Smith, Ahmad" }
            );


            // Seed Invoices
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2010, 1, 13),
                    ProductTotal = 160.00m,
                    SalesTax = 12.00m,
                    Shipping = 6.25m,
                    InvoiceTotal = 178.25m
                },
                new Invoice
                {
                    InvoiceId = 2,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2010, 1, 13),
                    ProductTotal = 62.50m,
                    SalesTax = 4.69m,
                    Shipping = 3.75m,
                    InvoiceTotal = 70.94m
                },
                new Invoice
                {
                    InvoiceId = 3,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2010, 1, 13),
                    ProductTotal = 45.00m,
                    SalesTax = 3.38m,
                    Shipping = 3.75m,
                    InvoiceTotal = 52.13m
                },
                new Invoice
                {
                    InvoiceId = 4,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2010, 1, 13),
                    ProductTotal = 62.50m,
                    SalesTax = 4.69m,
                    Shipping = 3.75m,
                    InvoiceTotal = 70.94m
                },
                new Invoice
                {
                    InvoiceId = 5,
                    CustomerId = 4,
                    InvoiceDate = new DateTime(2010, 1, 13),
                    ProductTotal = 62.50m,
                    SalesTax = 4.69m,
                    Shipping = 3.75m,
                    InvoiceTotal = 70.94m
                }
            );
        }

    }
}
