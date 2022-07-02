using Course.Customers.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // ctor estático e readonly para manter a mesma lista armazenando na memória
        // se não for estátic sempre gerará uma nova lista
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

            return Ok(_customers);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            _customers.Add(customer);

            return CreatedAtAction(nameof(CreateCustomer), customer);
        }

        [HttpPut("{id:guid}")]
        public  IActionResult EditCustomer(
            [FromRoute] Guid id, 
            [FromBody] Customer customer)
        {
            var found = _customers.FirstOrDefault(c => c.Id == id);

            if (found == null)
                return NotFound();

            found = customer;

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCustomer([FromRoute] Guid id)
        {
            var found = _customers.FirstOrDefault(c => c.Id == id);

            if (found == null)
                return NotFound();

            _customers.Remove(found);

            return NoContent();
        }
    }
}
