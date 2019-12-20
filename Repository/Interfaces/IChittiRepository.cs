using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Model;

namespace CTrackAPI.Repository.Interfaces
{
    public interface IChittiRepository
    {
        Chitti Create(Chitti user);

        Chitti Update(Chitti user);

        bool Delete(int ChittiID);

        List<ChittiDto> GetChittiByUserId(long userid);

        Chitti Get(long ChittiPID);

        List<Chitti> GetAdminChitti(long userid);

    }
}
