using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
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
            _context.People.Add(people);
            _context.SaveChanges();
            return people;
        }

        public People Update(People people)
        {
            _context.People.Update(people);
            _context.SaveChanges();
            return people;
        }

        public bool Delete(int PeopleID)
        {
            
            return true;
        }
    }
}
