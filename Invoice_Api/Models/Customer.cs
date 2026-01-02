using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Invoice_Api.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Invoice>? Invoices { get; set; }

        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
