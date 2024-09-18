using PRS_With_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_With_Entity_Framework.Db
{
    internal class UserDb
    {
        private PrsdbContext dbContext = new();

        public List<User> GetUsers() { 
        return dbContext.Users.ToList();
        }
        public User FindUser(int id)
        {
            return dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        public void AddUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
        public void RemoveUser(User user)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

    }
}
