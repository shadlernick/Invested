using Investor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor
{
    public class InvestorContext : DbContext
    {
        public InvestorContext()
               : base("Investition")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealClient> DealClients { get; set; }
    }
}
