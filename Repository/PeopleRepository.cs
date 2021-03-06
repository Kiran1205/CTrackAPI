﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Model;
using CTrackAPI.Repository.Interfaces;

namespace CTrackAPI.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private APIDataContext _context;

        public PeopleRepository(APIDataContext context)
        {
            _context = context;
        }

        public People Create(People people)
        {
            var peopleCount =  _context.People.Where(x => x.ChittiPID == people.ChittiPID).Count();
            var NoOfMonths = _context.Chitti.First(x => x.ChittiPID == people.ChittiPID).NoOfMonths;

            if (peopleCount > NoOfMonths)
                throw new Exception("House Full");

            _context.People.Add(people);
            _context.SaveChanges();

            var userinfo = _context.User.Where(x => x.PhoneNumber == people.PhoneNumber).ToList();

            if (userinfo.Any())
            {
                Permission obj = new Permission();
                obj.ChittiPID = people.ChittiPID;
                obj.CreatedBy = people.CreatedBy;
                obj.CreatedOn = DateTime.Now;
                obj.PeoplePID = people.PeoplePID;
                obj.RolePID = 2;
                obj.UpdatedOn = DateTime.Now;
                obj.UserPID = userinfo.First().UserPID;

                _context.Permission.Add(obj);
                _context.SaveChanges();
            }
           
           
            return people;
        }

        public People Update(People people)
        {
            _context.People.Update(people);
            _context.SaveChanges();
            return people;
        }
       
        public List<PeopleDto> GetPeople(ChittiDto chittiDto)
        {
            var peoplelist = new List<PeopleDto>();
            var AmountNeedToPay = _context.PaymentTaken.Where(x => x.ChittiPID == chittiDto.ChittiPID)
                     .GroupBy(o => new { o.ChittiPID })
                     .Select(g => new
                     {
                         ActualAmount = g.Sum(o => o.AmountByPeople)
                     });

            if (chittiDto.RolePid == 1)
            {
                //admin
                var peoples = _context.People.Where(x => x.ChittiPID == chittiDto.ChittiPID).ToList();
                foreach (var item in peoples)
                {
                    PeopleDto people = new PeopleDto();
                    people.Name = item.Name;
                    people.ChittiPID = item.ChittiPID;
                    people.PhoneNumber = item.PhoneNumber;
                    people.PeoplePID = item.PeoplePID;
                    var objpaidAmount = _context.PaymentPaid.Where(x => x.PeoplePID == item.PeoplePID)
                       .GroupBy(o => new { o.PeoplePID, o.ChittiPID })
                       .Select(g => new
                       {
                           TotalPaid = g.Sum(o => o.PaidAmount)
                       });

                    if(AmountNeedToPay.Any())
                    people.PendingAmount = AmountNeedToPay.FirstOrDefault().ActualAmount - (objpaidAmount.FirstOrDefault() == null ?  0: objpaidAmount.FirstOrDefault().TotalPaid );

                    peoplelist.Add(people);
                }               
            }
            else if(chittiDto.RolePid == 2)
            {
                var permissions = _context.Permission.Where(x => x.ChittiPID == chittiDto.ChittiPID && x.UserPID == chittiDto.CalledUserPID).Select(x => x.PeoplePID).ToList();               

                foreach (var item in permissions)
                {
                    var peopledata  = _context.People.Where(x => x.PeoplePID == item).FirstOrDefault();

                    PeopleDto people = new PeopleDto();
                    people.Name = peopledata.Name;
                    people.ChittiPID = peopledata.ChittiPID;
                    people.PhoneNumber = peopledata.PhoneNumber;
                    people.PeoplePID = peopledata.PeoplePID;

                    var objpaidAmount = _context.PaymentPaid.Where(x => x.PeoplePID == peopledata.PeoplePID)
                        .GroupBy(o => new { o.PeoplePID, o.ChittiPID })
                        .Select(g => new
                        {
                            TotalPaid = g.Sum(o => o.PaidAmount)
                        });

                    if (AmountNeedToPay.Any())
                        people.PendingAmount = AmountNeedToPay.FirstOrDefault().ActualAmount - (objpaidAmount.FirstOrDefault() == null ? 0 : objpaidAmount.FirstOrDefault().TotalPaid);

                    peoplelist.Add(people);
                }
            }
            return peoplelist;
        }
        public bool Delete(int PeopleID)
        {
            var permission = _context.Permission.Where(x => x.PeoplePID == PeopleID).ToList();
            _context.Permission.RemoveRange(permission);
            _context.SaveChanges();

            var people = _context.People.Where(x => x.PeoplePID == PeopleID).ToList();
            _context.People.RemoveRange(people);
            _context.SaveChanges();

            var payments = _context.PaymentTaken.Where(x => x.PeoplePID == PeopleID).ToList();
            _context.PaymentTaken.RemoveRange(payments);
            _context.SaveChanges();

            var paymentPaid = _context.PaymentPaid.Where(x => x.PeoplePID == PeopleID).ToList();
            _context.PaymentPaid.RemoveRange(paymentPaid);
            _context.SaveChanges();

            return true;
        }

        public List<People> GetPeopleList(long chittiPid)
        {
            var paymenttakenlist = _context.PaymentTaken.Where(x => x.ChittiPID == chittiPid).Select(y => y.PeoplePID).ToList();
            var peoples = _context.People.Where(x => x.ChittiPID == chittiPid && !paymenttakenlist.Contains(x.PeoplePID)).ToList();
            peoples.Add(new People()
            {
                Name = "Admin",
                PeoplePID = -1
            });
            return peoples;

        }
    }
}
