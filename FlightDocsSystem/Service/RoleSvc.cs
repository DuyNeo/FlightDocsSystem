//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FlightDocsSystem.Models;
//using Microsoft.EntityFrameworkCore;
//namespace FlightDocsSystem.Service
//{
//    public interface IRole
//    {
//            public Task<List<Role>> GetRoleAllAsync();
//            public Task<bool> EditRoleAsync(int id, Role roles);
//            public Task<bool> AddRoleAsync(Role roles);
//            public Task<Role> GetRoleAsync(int? id);
//    }
//    public class RoleSvc : IRole
//    { 

//        protected DataContext _context;
//        public RoleSvc(DataContext context)
//        {
//            _context = context;
//        }
//        public async Task<bool> AddRoleAsync(Role roles)
//        {
//            _context.Add(roles);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> EditRoleAsync(int id, Role roles)
//        {
//            _context.roles.Update(roles);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<List<Role>> GetRoleAllAsync()
//        {
//            var dataContext = _context.roles;
//            return await dataContext.ToListAsync();
//        }

//        public async Task<Role> GetRoleAsync(int? id)
//        {
//            var roles = await _context.roles
//                .FirstOrDefaultAsync(m => m.RoleId == id);
//            if (roles == null)
//            {
//                return null;
//            }

//            return roles;
//        }
       
        
//    }
//}
