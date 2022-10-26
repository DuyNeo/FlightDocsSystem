using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace FlightDocsSystem.Service
{
    public interface ICargoManifest
    {
        public Task<List<CargoManifest>> GetCargoManifestAllAsync();
        public Task<bool> EditCargoManifestAsync(int id, CargoManifest CargoManifests);
        public Task<bool> AddCargoManifestAsync(CargoManifest CargoManifests);
        public Task<CargoManifest> GetCargoManifestAsync(int? id);
        
    }
    public class CargoManifestSvc : ICargoManifest
    {
        protected DataContext _context;
        public CargoManifestSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCargoManifestAsync(CargoManifest CargoManifests)
        {
            _context.Add(CargoManifests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditCargoManifestAsync(int id, CargoManifest CargoManifests)
        {
            _context.cargoManifests.Update(CargoManifests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CargoManifest>> GetCargoManifestAllAsync()
        {
            var dataContext = _context.cargoManifests;
            return await dataContext.ToListAsync();
        }

        public async Task<CargoManifest> GetCargoManifestAsync(int? id)
        {
            var CargoManifests = await _context.cargoManifests
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (CargoManifests == null)
            {
                return null;
            }

            return CargoManifests;
        }
        
    }
}
