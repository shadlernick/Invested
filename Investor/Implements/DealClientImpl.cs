using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Implements
{
    class DealClientImpl : IRepository<DealClient>
    {
        private InvestorContext _context;

        public DealClientImpl(InvestorContext context)
        {
            _context = context;
        }

        public DealClient delete(DealClient entity)
        {
            _context.DealClients.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public DealClient get(int id) => _context.DealClients.Find(id);


        public ObservableCollection<DealClient> getAll()
        {
            return new ObservableCollection<DealClient>(_context.DealClients);
        }

        public DealClient save(DealClient entity)
        {
            _context.DealClients.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public DealClient update(DealClient entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
