using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;

namespace CTrackAPI.Repository.Interfaces
{
    interface IChittiRepository
    {
        Chitti Create(Chitti user);

        Chitti Update(Chitti user);

        bool Delete(int ChittiID);
    }
}
