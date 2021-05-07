using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;


namespace customerapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public static CustomerCollection customerdb = new CustomerCollection();

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        // curl -X GET http://localhost:5000/customer/
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(customerdb.CustomerList.ToArray());
        }

        // curl -X GET http://localhost:5000/customer/5
        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetCustomerByID(ulong id)
        {
            return Ok(customerdb.CustomerList.FirstOrDefault<Customer>(cust => cust.Id == id));
        }

        // curl -X GET http://localhost:5000/customer/dan
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<Customer>> SearchCustomersByName(string name)
        {
            return Ok(customerdb.CustomerList.Where<Customer>(cust => cust.Name.ToLower().IndexOf(name.ToLower()) != -1));
        }

        //  curl -X POST http://localhost:5000/customer -H "Content-Type: application/json" -d "{\"name\":\"gregory\"}"
        [HttpPost]
        public ActionResult CreateCustomer([FromBody] CustomerName name)
        {
            if(name != null){
                customerdb.CustomerList.Add(new Customer(name.Name));
                return Ok();
            } 
            return BadRequest();

            // or a custom status+data object
        }

        // curl -X DELETE http://localhost:5000/customer/5
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCustomerByID(ulong id)
        {
            if(customerdb.CustomerList.Exists(cust => cust.Id == id))
            {
                customerdb.CustomerList.RemoveAll(cust => cust.Id == id);
                return Ok();
            }
            return NotFound();
            
        }

        [HttpPost]
        public ActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if(customerdb.CustomerList.Exists(cust => cust.Id == customer.Id))
            {
                var customer_ref = customerdb.CustomerList.FirstOrDefault(cust => cust.Id == customer.Id);
                customer_ref.Name = customer.Name;
                return Ok();
            }
            return NotFound();

        }

    

    }
}
