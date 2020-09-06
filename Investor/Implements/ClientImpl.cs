using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Implements
{
    class ClientImpl : IRepository<Client>
    {
        private InvestorContext _context;

        public ClientImpl(InvestorContext context)
        {
            _context = context;
        }

        public Client delete(Client entity)
        {
            _context.Clients.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public Client get(int id) => _context.Clients.Find(id);


        public ObservableCollection<Client> getAll()
        {
            return new ObservableCollection<Client>(_context.Clients);
        }

        public Client save(Client entity)
        {
            _context.Clients.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Client update(Client entity)
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
