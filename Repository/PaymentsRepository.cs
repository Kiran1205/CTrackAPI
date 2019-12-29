using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Repository.Interfaces;

namespace CTrackAPI.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private APIDataContext _context;

        public PaymentsRepository(APIDataContext context)
        {
            _context = context;
        }

        public Payments Create(Payments payments)
        {
            _context.Payments.Add(payments);
            _context.SaveChanges();
            return payments;
        }

        public Payments Update(Payments payments)
        {
            _context.Payments.Update(payments);
            _context.SaveChanges();
            return payments;
        }

        public PaymentPaid PaymentPaidSave(PaymentPaid paymentPaid)
        {
            _context.PaymentPaid.Add(paymentPaid);
            _context.SaveChanges();
            return paymentPaid;
        }

        public List<PaymentPaid> GetPeoplePaidHistory(long PeoplePid)
        {
            var list = new List<PaymentPaid>();
            var chittipid =  _context.People.First(x => x.PeoplePID == PeoplePid).ChittiPID;
            var listofpayments = _context.PaymentTaken.Where(x => x.ChittiPID == chittipid).ToList();
            list = _context.PaymentPaid.Where(x => x.PeoplePID == PeoplePid).ToList();
            foreach (var item in listofpayments)
            {
                list.Add(new PaymentPaid()
                {
                    PaidAmount = -item.AmountByPeople,
                    PaidDate = item.MonthDate,
                    Comments = "Month :"+item.MonthNumber.ToString()
                });
            }
            return list;
            
        }

        public PaymentTaken GetPaymentTaken(long ChittiPID)
        {
            var chitti = _context.Chitti.First(x => x.ChittiPID == ChittiPID);
            int months = chitti.NoOfMonths;

            int completed = _context.PaymentTaken.Where(x => x.ChittiPID == ChittiPID).Count();
            decimal commissionAmount = chitti.Amount * (chitti.Commission / 100);

            decimal baseAmount = ((chitti.Amount / 100000) * 1200 * (months - (completed +1)) + commissionAmount);
            PaymentTaken obj = new PaymentTaken();
            obj.Amount = chitti.Amount - baseAmount;
            obj.BasicAmount = baseAmount;
            obj.AmountByPeople = (obj.Amount + commissionAmount) / months;
            obj.CommissionAmount = commissionAmount;
            obj.AuctionAmount = 0;
            obj.MonthNumber = completed +1;
            obj.ChittiPID = ChittiPID;
            obj.CreatedOn = DateTime.Now;
            obj.MonthDate = chitti.StartDate.AddMonths(completed);
            
            return obj;

        }
        public PaymentTaken SavePaymentTaken(PaymentTaken paymentTaken)
        {
            _context.PaymentTaken.Add(paymentTaken);
            _context.SaveChanges();           
            return paymentTaken;

        }
        public bool Delete(int PaymentsID)
        {
            return false;
        }
    }
}
