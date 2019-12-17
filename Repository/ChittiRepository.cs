using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Model;
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
        public Chitti Get(long ChittiPID)
        {
             return _context.Chitti.FirstOrDefault(x => x.ChittiPID == ChittiPID); ;
        }

        public List<ChittiDto> GetChittiByUserId(int userid)
        {
            List<ChittiDto> obj = new List<ChittiDto>();

            var Permissions =  _context.Permission.Where(x => x.UserPID == userid).ToList();
            foreach (var item in Permissions)
            {
                ChittiDto chittidto = new ChittiDto();
                chittidto.ChittiPID = item.ChittiPID;
                chittidto.RolePid = item.RolePID;

                var chitti = _context.Chitti.FirstOrDefault(x => x.ChittiPID == item.ChittiPID);

                chittidto.Amount = chitti.Amount;
                chittidto.Name = chitti.Name;
                chittidto.NoOfMonths = chitti.NoOfMonths;

                var completedMonths =  _context.PaymentTaken.Where(x => x.ChittiPID == chitti.ChittiPID).Count();

                chittidto.PendingMonths = chitti.NoOfMonths - completedMonths;
                chittidto.PendingAmount = 0;//Need to do 

                obj.Add(chittidto);
            }
            return obj;
        }

        public bool Delete(int chittiID)
        {
            return false;
        }
    }
}
