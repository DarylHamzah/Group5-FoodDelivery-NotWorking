using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Server.Data;
using WebApplication3.Server.IRepository;
using WebApplication3.Shared.Domain;

namespace WebApplication3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            //return await _context.Makes.ToListAsync();
            var Orders = await _unitOfWork.Orders.GetAll();
            return Ok(Orders);
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            // var make = await _context.Makes.FindAsync(id);
            var Order = await _unitOfWork.Orders.Get(q => q.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(Order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order Order)
        {
            if (id != Order.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Orders.Update(Order);



            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order Order)
        {
            await _unitOfWork.Orders.Insert(Order);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrder", new { id = Order.Id }, Order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {

            var Order = await _unitOfWork.Orders.Get(q => q.Id == id);
            if (Order == null)
            {
                return NotFound();
            }

            await _unitOfWork.Orders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OrderExists(int id)
        {
            var Order = await _unitOfWork.Orders.Get(q => q.Id == id);
            return Order != null;
        }
    }
}
