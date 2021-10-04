using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDALEF
{
    public class AutoLotEntities : DbContext
    {
        public AutoLotEntities() : base("name=AutoLotConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        //public virtual DbSet<Customer> Customer { get; set; }
        //public virtual DbSet<Inventory> Inventory { get; set; }
        //public virtual DbSet<Order> Order { get; set; }
    }
}
