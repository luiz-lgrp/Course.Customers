using Course.Customers.API.SeedWork;

namespace Course.Customers.API.ViewModels
{
    public class CustomerViewModel
    {
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EntityStatus Status { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
    }
}
