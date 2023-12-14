using DominioService.Order;
using EntityRequest;
using EntityResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IDOrder Order;
        public OrdersController(IDOrder order)
        {
            Order = order;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> Get()
        {
            return await Order.GetAll();
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<bool>> Create(OrderRequest order)
        {
            if (ModelState.IsValid)
            {
                var result = await Order.Create(order);
                return Ok(result);
            }
            return BadRequest(ModelState);

        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task<ActionResult<OrderResponse>> Update(OrderRequest order)
        {
            if (ModelState.IsValid)
            {
                var result = await Order.Update(order);

                return result != null ? Ok(result) : BadRequest(result);
            }
            return BadRequest(ModelState);

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await Order.Delete(id);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteByIdCustomer(int id)
        {
            var result = await Order.DeleteByIdCustomer(id);

            return Ok(result);
        }
    }
}
