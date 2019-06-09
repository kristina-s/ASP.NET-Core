using PizzaApp.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.MockRepositories
{
    public class MockUserRepository : IUserRepository
    {
        List<User> users;
        public MockUserRepository()
        {
            users = new List<User>()
            {
                new User{Id=1, Name="Peki", City="Skopje", Address="23 Oktomvri", Email="peki@hotmail.com", Phone="1234567"},
                new User{Id=2, Name="Angela", City="Bitola", Address="Partizanska", Email="ang@hotmail.com", Phone="34534567"},
                new User{Id=3, Name="Jovan", City="Ohrid", Address="11 Oktomvri", Email="joko@hotmail.com", Phone="1231234"},
                new User{Id=4, Name="Kalina", City="Gevgelija", Address="Ilindenska", Email="kali@hotmail.com", Phone="1238765"},
            };
        }
        public User Add(User user)
        {
            int nextId = users.Max(p => p.Id) + 1;
            user.Id = nextId;
            users.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            User user = users.FirstOrDefault(x => x.Id == id);
            users.Remove(user);
            return user;
        }

        public User Get(int id)
        {
            User user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Update(User userChanges)
        {
            User user = users.FirstOrDefault(x => x.Id == userChanges.Id);
            if (user != null)
            {
                user.Name = userChanges.Name;
                user.City = userChanges.City;
                user.Address = userChanges.Address;
                user.Email = userChanges.Email;
                user.Phone = userChanges.Phone;
            }
            return user;
        }
    }
}
