using PRS_With_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_With_Entity_Framework.Db
{
    internal class VendorDb
    {
        private PrsdbContext dbContext = new();

        public List<Vendor> GetVendors() { 
        return dbContext.Vendors.ToList();
        }
        public Vendor FindVendor(int id)
        {
            return dbContext.Vendors.Where(v => v.Id == id).FirstOrDefault();
        }
        public void AddVendor(Vendor vendor)
        {
            dbContext.Vendors.Add(vendor);
            dbContext.SaveChanges();
        }
        public void RemoveVendor(Vendor vendor)
        {
            dbContext.Vendors.Remove(vendor);
            dbContext.SaveChanges();
        }

    }
}
