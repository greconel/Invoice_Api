using Microsoft.EntityFrameworkCore;
using Invoice_Api.Models;

namespace Invoice_Api.Models
{
    // copy paste van GuitarShop
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InvoiceContext _context;

        public CustomerRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.CustomerId == id);
        }

        public async Task<Customer?> GetCustomersAsync(int id)
        {
            //return await _context.Customers.FirstOrDefaultAsync(c => c.CategoryId == id);
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
