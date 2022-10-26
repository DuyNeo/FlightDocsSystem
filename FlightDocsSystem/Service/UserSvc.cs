using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Models;
using FlightDocsSystem.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace FlightDocsSystem.Service
{
    public interface IUser
    {
        public Task<List<Users>> GetUserAllAsync();
        public Task<bool> EditUserAsync(int id, Users users);
        public Task<bool> AddUserAsync(Users users);
        public Task<Users> GetUserAsync(int? id);
        Task<bool> isEmail(string email);//kiem tra ton tai cua email

        //public Task<bool> DeleteUserAsync(int id, User User);
        //public Task<Users> Login(ViewLogin viewLogin);
        Task<Users> LoginAsync(ViewLogin login);
        Task<int> ChangePasswordCode(string email, Users user);
    }
    public class UserSvc : IUser
    {
        protected DataContext _context;
        public UserSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserAsync(Users users)
        {
            _context.Add(users);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditUserAsync(int id, Users users)
        {
            _context.users.Update(users);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Users>> GetUserAllAsync()
        {
            var dataContext = _context.users;
            return await dataContext.ToListAsync();
        }

        public async Task<Users> GetUserAsync(int? id)
        {
            var users = await _context.users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return null;
            }

            return users;
        }
        public async Task<Users> GetUserEmail(string email)
        {
            Users users = null;
            users = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            return users;
        }
        public async Task<bool> isEmail(string email)
        {
            bool ret = false;
            try
            {
                Users user = await _context.users.Where(x => x.Email == email).FirstOrDefaultAsync();
                if (user != null)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public async Task<Users> LoginAsync(ViewLogin login)
        {
            Users user = await _context.users.Where(x => x.Email == login.Email
                  && x.Password == (login.Password)).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<int> ChangePasswordCode(string email, Users user)
        {
            int ret = 0;
            try
            {

                Users _user = null;
                _user = await GetUserEmail(email);


                _user.Password = user.Password;
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
    }
}
