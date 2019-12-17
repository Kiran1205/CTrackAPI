using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Repository.Interfaces;

namespace CTrackAPI.Repository
{
    public class ChittiRepository : IChittiRepository
    {
        private APIDataContext _context;

        public ChittiRepository(APIDataContext context)
        {
            _context = context;
        }

        public Chitti Create(Chitti chitti)
        {
            _context.Chitti.Add(chitti);
            _context.SaveChanges();
            return chitti;
        }

        public Chitti Update(Chitti chitti)
        {
            _context.Chitti.Update(chitti);
            _context.SaveChanges();
            return chitti;
        }

        public bool Delete(int chittiID)
        {
            return false;
        }
    }
}
