using PizzaApp.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.SqlUserRepository
{
    public class SqlUserRepository : IUserRepository
    {
        private UserDbContext db;
        public SqlUserRepository(UserDbContext context)
        {
            db = context;
        }

        public User Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Update(User newUser)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == newUser.Id);
            if (user != null)
            {
                user.Name = newUser.Name;
                user.City = newUser.City;
                user.Address = newUser.Address;
                user.Email = newUser.Email;
                user.Phone = newUser.Phone;
            }
            db.SaveChanges();

            return user;
        }
    }
}
