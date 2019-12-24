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

            Permission obj = new Permission();
            obj.ChittiPID = chitti.ChittiPID;
            obj.CreatedBy = chitti.CreatedBy;
            obj.CreatedOn = DateTime.Now;
            obj.UpdatedOn = DateTime.Now;
            obj.RolePID = 1/*Admin*/;
            obj.UserPID = chitti.CreatedBy;

            _context.Permission.Add(obj);

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
            return _context.Chitti.FirstOrDefault(x => x.ChittiPID == ChittiPID) ?? new Chitti();
        }

        public List<ChittiDto> GetChittiByUserId(long userid)
        {
            List<ChittiDto> obj = new List<ChittiDto>();

            var Permissions =  _context.Permission.Where(x => x.UserPID == userid).ToList();
            foreach (var item in Permissions)
            {
                ChittiDto chittidto = new ChittiDto();
                chittidto.ChittiPID = item.ChittiPID;
                chittidto.RolePid = item.RolePID;
                chittidto.CalledUserPID = userid;
               
                var chitti = _context.Chitti.FirstOrDefault(x => x.ChittiPID == item.ChittiPID);

                chittidto.Amount = chitti.Amount;
                chittidto.Name = chitti.Name;
                chittidto.NoOfMonths = chitti.NoOfMonths;
                chittidto.EndDate = chitti.EndDate;

               var completedMonths =  _context.PaymentTaken.Where(x => x.ChittiPID == chitti.ChittiPID).Count();

              var SumAmountbyPeople =   _context.PaymentTaken.Where(x => x.ChittiPID == chitti.ChittiPID).
                            GroupBy(o => new {o.ChittiPID })
                            .Select(g => new {
                                AmountByPeople = g.Sum(o => o.AmountByPeople)
                            });

                var PaidAmount = _context.PaymentPaid.Where(x => x.ChittiPID == chitti.ChittiPID).
                           GroupBy(o => new { o.ChittiPID })
                           .Select(g => new {
                               PaidAmount = g.Sum(o => o.PaidAmount)
                           });


                chittidto.PendingMonths = chitti.NoOfMonths - completedMonths;
                chittidto.PendingAmount = 0;
                if (SumAmountbyPeople.FirstOrDefault() != null)
                {
                    chittidto.PendingAmount = (SumAmountbyPeople.FirstOrDefault().AmountByPeople * chitti.NoOfMonths) - (PaidAmount.FirstOrDefault() == null ? 0 : PaidAmount.FirstOrDefault().PaidAmount);
                }
               

                obj.Add(chittidto);
            }
            return obj;
        }

        public List<Chitti> GetAdminChitti(long userid)
        {
            var chittilist = new List<Chitti>();
            var Permissions = _context.Permission.Where(x => x.UserPID == userid && x.RolePID == 1).ToList();
            foreach (var item in Permissions)
            {
                chittilist.Add( _context.Chitti.First(x => x.ChittiPID == item.ChittiPID));
            }
            return chittilist;
        }

        public bool Delete(int chittiID)
        {
            var chittitodelete = _context.Chitti.FirstOrDefault(x => x.ChittiPID == chittiID);           
            _context.Chitti.Remove(chittitodelete);
            _context.SaveChanges();

            var permission = _context.Permission.Where(x => x.ChittiPID == chittiID).ToList();
            _context.Permission.RemoveRange(permission);
            _context.SaveChanges();

            var people = _context.People.Where(x => x.ChittiPID == chittiID).ToList();
            _context.People.RemoveRange(people);
            _context.SaveChanges();

            var payments = _context.PaymentTaken.Where(x => x.ChittiPID == chittiID).ToList();
            _context.PaymentTaken.RemoveRange(payments);
            _context.SaveChanges();

            var paymentPaid = _context.PaymentPaid.Where(x => x.ChittiPID == chittiID).ToList();
            _context.PaymentPaid.RemoveRange(paymentPaid);
            _context.SaveChanges();

            return true;
        }
    }
}
