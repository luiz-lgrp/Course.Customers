using Course.Customers.API.SeedWork;

namespace Course.Customers.API.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Adress { get; set; }

        public Customer(
            string name, 
            string cpf, 
            string email, 
            string cellphone, 
            string adress)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Cellphone = cellphone;
            Adress = adress;
        }
    }
}
