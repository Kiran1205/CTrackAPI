using CTrackAPI.Entities;
using CTrackAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private APIDataContext _context;

        public UserRepository(APIDataContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            var chittisPID = _context.People.Where(x => x.PhoneNumber == user.PhoneNumber).ToList();

            foreach (var item in chittisPID)
            {
                Permission objPermiss = new Permission();
                objPermiss.ChittiPID = item.ChittiPID;
                objPermiss.RolePID = 2;
                objPermiss.UserPID = user.UserPID;
                objPermiss.PeoplePID = item.PeoplePID;
                objPermiss.CreatedOn = DateTime.Now;
                objPermiss.UpdatedOn = DateTime.Now;
                objPermiss.CreatedBy = user.UserPID;
                _context.Permission.Add(objPermiss);
                _context.SaveChanges();
            }         
            
            return user;
        }

        public User Getuser(User user)
        {
           return _context.User.First(x => x.PhoneNumber == user.PhoneNumber && x.Password == user.Password);
        }
    }
}
