using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Model;

namespace CTrackAPI.Repository.Interfaces
{
    public interface IPeopleRepository
    {
        People Create(People user);

        People Update(People user);

        List<PeopleDto> GetPeople(ChittiDto chittiDto);

        bool Delete(int PeopleID);

        List<PaymentPaid> GetPeoplePaidHistory(long PeoplePid);

        PaymentPaid PaymentPaidSave(PaymentPaid paymentPaid);

    }
}
