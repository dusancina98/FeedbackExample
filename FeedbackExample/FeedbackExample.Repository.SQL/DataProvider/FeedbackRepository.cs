using FeedbackExample.Entities;
using FeedbackExample.Repository.Contracts;
using FeedbackExample.Repository.SQL.DataAccess;
using FeedbackExample.Repository.SQL.DataProvider.Util;
using FeedbackExample.Repository.SQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedbackExample.Repository.SQL.DataProvider
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public void Create(Feedback entity)
        {
            using (FeedbackDbContext _context = new FeedbackDbContext())
            {
                _context.Feedbacks.Add(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity));
                _context.SaveChanges(); //ako ne sacuvamo nece se update-ovati baza
            }
        }

        public bool Delete(Guid id)
        {
            using (FeedbackDbContext _context = new FeedbackDbContext())
            {
                FeedbackPersistence feedback = _context.Feedbacks.Find(id);
                if (feedback == null) return false; //u principu vracamo true ili false, kao indikator uspesnosti operacije, ako ne pronadjemo id, operacija nije uspesna

                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges(); // cuvamo promene
                return true;
            }
        }

        public IEnumerable<Feedback> GetAll()
        {
            using (FeedbackDbContext _context = new FeedbackDbContext())
            {
                return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(_context.Feedbacks.ToList());
            }
        }

        public Feedback GetById(Guid id)
        {
            using (FeedbackDbContext _context = new FeedbackDbContext())
            {
                //pomocu lambda izraza se izvuce korisnik sa Id-jem koji je isti kao prosledjeni
                //isti rezultat ima i foreach gde se unutar nekog if-a porede id-jevi
                return FeedbackMapper.MapFeedbackPersistenceToFeedbackEntity(_context.Feedbacks.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Update(Feedback entity)
        {
            using (FeedbackDbContext _context = new FeedbackDbContext())
            {
                //Entity Framework ce po id-ju naci feedback i azurirati ga
                _context.Update(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity));
                _context.SaveChanges(); //moramo sacuvati promene
            }
        }
    }
}
