using Core.Entities;
using Faker;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Utilities
    {
        public static void InitializeDbForTests(IdentityDbContext db)
        {
            db.Users.AddRange(GetSeedingUsers());
            db.SaveChanges();
            // db.Users.AddRange(GetSeedingUsers(db.Departments.ToList()));
            // db.SaveChanges();
        }

        public static void ReinitializeDbForTests(IdentityDbContext db)
        {
            db.Users.RemoveRange(db.Users);
            InitializeDbForTests(db);
        }

        private static List<User> GetSeedingUsers()
        {
            List<User> users = new List<User>();
            for(int i = 0; i < 50; i++)
            {
                var user = new User();
                user.Id = $"{i}";
                user.FirstName = Name.First();
                user.LastName = Name.Last();
                user.Email = Internet.Email($"{user.FirstName} {user.LastName}");
                user.UserName = Internet.UserName($"{user.FirstName} {user.LastName}");
                users.Add(user);
            }
            return users;   
        }

    }

}
