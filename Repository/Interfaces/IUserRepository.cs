using CTrackAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);

        User Getuser(User user);
    }
}
