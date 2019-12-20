using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;

namespace CTrackAPI.Repository.Interfaces
{
    public interface IPaymentsRepository
    {
        Payments Create(Payments payment);

        Payments Update(Payments payment);

        bool Delete(int PaymentID);

        List<PaymentPaid> GetPeoplePaidHistory(long PeoplePid);

        PaymentPaid PaymentPaidSave(PaymentPaid paymentPaid);

        PaymentTaken GetPaymentTaken(long ChittiPID);

        PaymentTaken SavePaymentTaken(PaymentTaken paymentTaken);

    }
}
