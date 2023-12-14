using DominioService.Customer;
using EntityRequest;
using EntityResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly IDCustomer Customer;
        public CustomersController(IDCustomer customer)
        {
            Customer = customer;    
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerResponse>>> Get()
        {
            return await Customer.GetAll(); 
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<bool>> Create(CustomerRequest customer)
        {
            if(ModelState.IsValid)
            {
                var result = await Customer.Create(customer);
                return Ok(  result );
            }
            return BadRequest(ModelState);
           
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task<ActionResult<CustomerResponse>> Update(CustomerRequest customer)
        {
            if(ModelState.IsValid) {
                var result = await Customer.Update(customer);

                return result != null ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);
           
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await Customer.Delete(id);

            return Ok(result);
        }
    }
}
