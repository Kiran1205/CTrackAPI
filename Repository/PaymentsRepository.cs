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
        public bool Delete(int PaymentsID)
        {
            return false;
        }
    }
}
