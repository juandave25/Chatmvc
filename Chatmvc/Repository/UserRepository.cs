using Chatmvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chatmvc.Repository
{
    public class UserRepository : IUserRepository
    {
        public void add(User user)
        {
            using (var context = new Context())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public List<User> get()
        {
            List<User> users = new List<User>();
            using (var context = new Context())
            {
                users = context.User.Where(c=>c.enabled == true).ToList();
            }
            return users;
        }

        public List<User> getById(string nickName)
        {
            List<User> users = new List<User>();
            using (var context = new Context())
            {
                users = context.User.Where(c=>c.nickname == nickName && c.enabled==true).ToList();
            }
            return users;
        }
    }
}