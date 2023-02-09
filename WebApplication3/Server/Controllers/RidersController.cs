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
    public class RidersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RidersController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Riders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rider>>> GetRiders()
        {
            var riders = await _unitOfWork.Riders.GetAll();
            return Ok(riders);
        }

        // GET: api/Riders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRider(int id)
        {
            var rider = await _unitOfWork.Riders.Get(q => q.Id == id);

            if (rider == null)
            {
                return NotFound();
            }

            return Ok(rider);
        }

        // PUT: api/Riders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRider(int id, Rider rider)
        {
            if (id != rider.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Riders.Update(rider);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RiderExists(id))
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

        // POST: api/Riders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rider>> PostRider(Rider rider)
        {
            await _unitOfWork.Riders.Insert(rider);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetRider", new { id = rider.Id }, rider);
        }

        // DELETE: api/Riders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRider(int id)
        {
            var rider = await _unitOfWork.Riders.Get(q => q.Id == id);
            if (rider == null)
            {
                return NotFound();
            }

            await _unitOfWork.Riders.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        private async Task<bool> RiderExists(int id)
        {
            var rider = await _unitOfWork.Riders.Get(q => q.Id == id);
            return rider != null;
        }
    }
}
