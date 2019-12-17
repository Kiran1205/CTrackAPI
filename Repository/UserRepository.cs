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

            
            return user;
        }

        public User Getuser(User user)
        {
           return _context.User.FirstOrDefault(x => x.PhoneNumber == user.PhoneNumber && x.Password == user.Password);
        }
    }
}
