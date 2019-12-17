using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;

namespace CTrackAPI.Repository.Interfaces
{
    interface IPeopleRepository
    {
        People Create(People user);

        People Update(People user);

        bool Delete(int PeopleID);
    }
}
