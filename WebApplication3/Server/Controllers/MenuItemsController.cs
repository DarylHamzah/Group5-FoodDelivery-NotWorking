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
    public class MenuItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            var menuitems = await _unitOfWork.MenuItems.GetAll();
            return Ok(menuitems);
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            var menuitem = await _unitOfWork.MenuItems.Get(q => q.Id == id);

            if (menuitem == null)
            {
                return NotFound();
            }

            return Ok(menuitem);
        }

        // PUT: api/MenuItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuitem)
        {
            if (id != menuitem.Id)
            {
                return BadRequest();
            }

            _unitOfWork.MenuItems.Update(menuitem);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MenuItemExists(id))
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

        // POST: api/MenuItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuitem)
        {
            await _unitOfWork.MenuItems.Insert(menuitem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMenuItem", new { id = menuitem.Id }, menuitem);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuitem = await _unitOfWork.MenuItems.Get(q => q.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            await _unitOfWork.MenuItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();

           
        }

        private async Task<bool> MenuItemExists(int id)
        {
            var menuitem = await _unitOfWork.MenuItems.Get(q => q.Id == id);
            return menuitem != null;
        }
    }
}
