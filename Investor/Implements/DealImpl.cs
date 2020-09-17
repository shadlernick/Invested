using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Implements
{
    class DealImpl : IRepository<Deal>
    {
        private InvestorContext _context;

        public DealImpl(InvestorContext context)
        {
            _context = context;
        }

        public Deal delete(Deal entity)
        {
            _context.Deals.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public Deal get(int id) => _context.Deals.Find(id);


        public ObservableCollection<Deal> getAll() => new ObservableCollection<Deal>(_context.Deals);

        public Deal save(Deal entity)
        {
            _context.Deals.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Deal update(Deal entity)
        {
            try
            {
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return entity;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
