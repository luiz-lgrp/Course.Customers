using Course.Customers.API.SeedWork;

namespace Course.Customers.API.InputModels.Customers
{
    public class CreateEditCustomerInputModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public EntityStatus Status { get; set; }
    }
}
