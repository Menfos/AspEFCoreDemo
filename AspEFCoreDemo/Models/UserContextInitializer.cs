using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEFCoreDemo.Models
{
    public class UserContextInitializer : IUserSeed
    {
        public void Seed(UserContext context)
        {

            var users = new User[]
            {
                new User { Name = "Maksym", LastName = "Labish", Age = 21}
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
