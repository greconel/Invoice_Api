namespace Invoice_Api.Models
{
    //copy paste van GuitarShop
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice?> GetInvoiceAsync(int id);
        Task<Invoice?> GetInvoiceWithCustomerAsync(int id);
        Task AddInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task DeleteInvoiceAsync(Invoice invoice);
        bool InvoiceExists(int id);
    }
}
