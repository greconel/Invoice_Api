using Invoice_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Api.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext _context;

        public InvoiceRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.Include(p => p.Customer).ToListAsync();
        }
        public async Task AddInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice?> GetInvoiceAsync(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice?> GetInvoiceWithCustomerAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);
        }

        public bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(i => i.InvoiceId == id);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
