using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentsRepository _paymentsRepository;

        public PaymentController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;

        }

        [HttpPost("paymentpaid")]
        public IActionResult PaymentPaid([FromBody]PaymentPaid paymentpaid)
        {
            if (paymentpaid == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                paymentpaid.CreatedOn = DateTime.Now;
                paymentpaid.UpdatedOn = DateTime.Now;
                _paymentsRepository.PaymentPaidSave(paymentpaid);
                return Ok(paymentpaid);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("savepaymenttaken")]
        public IActionResult SavePaymentTaken([FromBody]PaymentTaken paymenttaken)
        {
            if (paymenttaken == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                paymenttaken.CreatedOn = DateTime.Now;
                paymenttaken.UpdatedOn = DateTime.Now;
                _paymentsRepository.SavePaymentTaken(paymenttaken);
                return Ok(paymenttaken);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/values/5
        [HttpGet("getpaidhistory")]
        public IActionResult GetPaidHistory(long peoplepid)
        {
            try
            {

                var list = _paymentsRepository.GetPeoplePaidHistory(peoplepid);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/values/5
        [HttpGet("getpaymenttaken")]
        public IActionResult GetPaymentTaken(long ChittiPID)
        {
            try
            {

                var payment = _paymentsRepository.GetPaymentTaken(ChittiPID);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}