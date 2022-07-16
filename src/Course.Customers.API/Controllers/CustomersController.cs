using Course.Customers.API.InputModels.Customers;
using Course.Customers.API.Models;
using Course.Customers.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        private static readonly List<Customer> _customers;

        static CustomersController()
        {
            _customers = new List<Customer>();
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            if (_customers.Count == 0)
                return NoContent();
            
            return Ok(_customers.Select(customer => new CustomerViewModel()
            {
                CustomerId = customer.Id,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                Name = customer.Name,
                Cpf = customer.Cpf,
                Email = customer.Email,
                Cellphone = customer.Cellphone,
                Address = customer.Address,
                Status = customer.Status
            }));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            
            var responseModel = new CustomerViewModel()
            {
                CustomerId = customer.Id,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                Name = customer.Name,
                Cpf = customer.Cpf,
                Email = customer.Email,
                Cellphone = customer.Cellphone,
                Address = customer.Address,
                Status = customer.Status
            };

            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateEditCustomerInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length <3) 
            {
                return BadRequest("The length of name must be greather than or equals to 3");
            }

            if (string.IsNullOrWhiteSpace(model.Cpf) || model.Cpf.Length != 11)
            {
                return BadRequest("The length of cpf must be equals to 11.");
            }
            else if(!model.Cpf.All(digit => char.IsDigit(digit)))
            {
                return BadRequest("The cpf needs to contain only numbers");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model.Email.Contains('@') 
                || !model.Email.Contains('.'))
            {
                return BadRequest("The email is invalid!");
            }

            if (string.IsNullOrWhiteSpace(model.Cellphone) || model.Cellphone.Length != 11)   
            {
                return BadRequest("The length of cellphone must be equals to 11.");
            }
            else if (!model.Cellphone.All(digit => char.IsDigit(digit)))
            {
                return BadRequest("The cellphone needs to contain only numbers");
            }

            if (string.IsNullOrWhiteSpace(model.Address) || model.Address.Length < 10)
            {
                return BadRequest("The length of address must be greather than or equals to 11.");
            }

            var customer = new Customer(
                model.Name, 
                model.Cpf, 
                model.Email, 
                model.Cellphone, 
                model.Address);


            customer.Status = model.Status;
            _customers.Add(customer);

            return CreatedAtAction(nameof(CreateCustomer), null);
        }

        [HttpPut("{id:guid}")]
        public IActionResult EditCustomer(
            [FromRoute] Guid id,
            [FromBody] CreateEditCustomerInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3)
            {
                return BadRequest("The length of name must be greather than or equals to 3");
            }

            if (string.IsNullOrWhiteSpace(model.Cpf) || model.Cpf.Length != 11)
            {
                return BadRequest("The length of cpf must be equals to 11.");
            }
            else if (!model.Cpf.All(digit => char.IsDigit(digit)))
            {
                return BadRequest("The cpf needs to contain only numbers");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model.Email.Contains('@')
                || !model.Email.Contains('.'))
            {
                return BadRequest("The email is invalid!");
            }

            if (string.IsNullOrWhiteSpace(model.Cellphone) || model.Cellphone.Length != 11)
            {
                return BadRequest("The length of cellphone must be equals to 11.");
            }
            else if (!model.Cellphone.All(digit => char.IsDigit(digit)))
            {
                return BadRequest("The cellphone needs to contain only numbers");
            }

            if (string.IsNullOrWhiteSpace(model.Address) || model.Address.Length < 10)
            {
                return BadRequest("The length of address must be greather than or equals to 11.");
            }


            var foundIndex = _customers.FindIndex(c => c.Id == id);

            if (foundIndex == -1)
                return NotFound();

            var customer = _customers[foundIndex];

            customer.Name = model.Name;
            customer.Cpf = model.Cpf;
            customer.Email = model.Email;
            customer.Cellphone = model.Cellphone;
            customer.Address = model.Address;
            customer.Status = model.Status;

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCustomer([FromRoute] Guid id)
        {
            var found = _customers.FirstOrDefault(c => c.Id == id);

            if (found is null)
                return NotFound();

            _customers.Remove(found);

            return NoContent();
        }
    }
}
