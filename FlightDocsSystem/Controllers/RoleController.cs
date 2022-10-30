//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FlightDocsSystem.Service;
//using FlightDocsSystem.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;

//namespace FlightDocsSystem.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class RoleController : ControllerBase
//    {
//        private readonly IRole _Role;
//        private readonly DataContext _context;
//        public RoleController(DataContext context, IRole Role)
//        {
//            _context = context;
//            _Role = Role;
//        }
//        [HttpPost, ActionName("Role")]
//        [Authorize(Roles = "2")]

//        public async Task<IActionResult> PostAsync(Role Roles)
//        {
//            if (ModelState.IsValid)
//            {
//                   if (await _Role.AddRoleAsync(Roles))
//                    {
//                        return Ok(new
//                        {
//                            retCode = 1,
//                            retText = "Thành công",
//                            data = await _Role.GetRoleAsync(Roles.RoleId)
//                        });
//                    }
//            }
//            return Ok(new
//            {
//                retCode = 0,
//                retText = "Thất bại"
//            });
//        }
//        [HttpGet]
//        [Route("ListRole")]
//        [Authorize(Roles = "2")]

//        public async Task<ActionResult<IEnumerable<Role>>> GetRoleAllAsync()
//        {

//            return await _Role.GetRoleAllAsync(); ;
//        }

//        [HttpPut("{id}")]
//        [Authorize(Roles = "2")]

//        public async Task<IActionResult> PutRole(int id, Role Role)
//        {
//            if (id != Role.RoleId)
//            {
//                return BadRequest();
//            }


//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            try
//            {
//                await _Role.EditRoleAsync(id, Role);

//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!RoleExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Ok(new
//            {
                
//                retCode = 0,
//                retText = "Update thành công"
//            });

//        }
//        private bool RoleExists(int id)
//        {
//            return _context.roles.Any(e => e.RoleId == id);

//        }
//        [HttpDelete("{id}")]
//        [Authorize(Roles ="2")]

//        public async Task<IActionResult> DeleteRole(int id)
//        {
//            var Role = await _context.roles.FindAsync(id);
//            if (Role == null)
//            {
//                return NotFound();

//            }

//            _context.roles.Remove(Role);
//            await _context.SaveChangesAsync();

//            return Ok();
//        }
//    }
//}
