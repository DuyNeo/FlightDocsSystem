using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Service;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CargoManifestController : ControllerBase
    {
        private readonly ICargoManifest _cargoManifest;
        private readonly DataContext _context;
        public CargoManifestController(DataContext context, ICargoManifest cargoManifest)
        {
            _context = context;
            _cargoManifest = cargoManifest;
        }
        [HttpPost]
        [Authorize(Roles = "2")]

        public async Task<ActionResult<int>> AddCargoManifest(CargoManifest cargo)
        {
            try
            {
                await _cargoManifest.AddCargoManifestAsync(cargo);
            }
            catch (Exception ex)
            {

            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListCargoManifest")]

        public async Task<ActionResult<IEnumerable<CargoManifest>>> GetCargoManifestAllAsync()
        {
            return await _cargoManifest.GetCargoManifestAllAsync();

        }
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]

        public async Task<IActionResult> PutCargoManifest(int id, CargoManifest cargo)
        {
            if (id != cargo.FlightId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _cargoManifest.EditCargoManifestAsync(id, cargo);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoManifestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool CargoManifestExists(int id)
        {
            return _context.cargoManifests.Any(e => e.FlightId == id);

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]


        public async Task<IActionResult> DeleteCargoManifest(int id)
        {
            var CargoManifest = await _context.cargoManifests.FindAsync(id);
            if (CargoManifest == null)
            {
                return NotFound();
            }

            _context.cargoManifests.Remove(CargoManifest);
            await _context.SaveChangesAsync();

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Xóa thành công"
                 });
        }
    }
}
