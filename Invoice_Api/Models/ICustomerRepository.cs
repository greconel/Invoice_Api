

namespace Invoice_Api.Models
{
    //Copy paste van guitarshop
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomersAsync(int id);
        Task AddCustomerAsync (Customer customer);
        Task UpdateCustomerAsync (Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        bool CustomerExists(int id);
    }
}
