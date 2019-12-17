using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;

namespace CTrackAPI.Repository.Interfaces
{
    interface IPaymentsRepository
    {
        Payments Create(Payments payment);

        Payments Update(Payments payment);

        bool Delete(int PaymentID);

    }
}
