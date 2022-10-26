using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace FlightDocsSystem.Service
{
    public interface IGroupPermission
    {
        public Task<List<GroupPermission>> GetGroupPermissionAllAsync();
        public Task<bool> EditGroupPermissionAsync(int id, GroupPermission GroupPermissions);
        public Task<bool> AddGroupPermissionAsync(GroupPermission GroupPermissions);
        public Task<GroupPermission> GetGroupPermissionAsync(int? id);
        
    }
    public class GroupPermissionSvc : IGroupPermission
    {
        protected DataContext _context;
        public GroupPermissionSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddGroupPermissionAsync(GroupPermission GroupPermissions)
        {
            _context.Add(GroupPermissions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditGroupPermissionAsync(int id, GroupPermission GroupPermissions)
        {
            _context.groupPermissions.Update(GroupPermissions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GroupPermission>> GetGroupPermissionAllAsync()
        {
            var dataContext = _context.groupPermissions;
            return await dataContext.ToListAsync();
        }

        public async Task<GroupPermission> GetGroupPermissionAsync(int? id)
        {
            var GroupPermissions = await _context.groupPermissions
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (GroupPermissions == null)
            {
                return null;
            }

            return GroupPermissions;
        }
        
    }
}
