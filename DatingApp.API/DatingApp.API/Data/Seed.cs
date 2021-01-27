using DatingApp.API.Models;
using DatingApp.API.Security;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class Seed
    {

        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            // create some roles
            if (!roleManager.Roles.Any()) 
            {
                var roles = new List<Role>
                {
                    new Role{ Name = "Member" },
                    new Role{ Name = "Admin" },
                    new Role{ Name = "Moderatore" },
                    new Role{ Name = "VIP" }
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    //byte[] passwordHash, passwordSalt;
                    //CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    //user.PasswordHash = passwordHash;
                    //user.PasswordSalt = passwordSalt;
                    //user.UserName = user.UserName.ToLower();
                    //context.Users.Add(user);
                    userManager.CreateAsync(user, "password").Wait();
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
                //context.SaveChanges();
            }
        }

        public static void CreateAdminUser(UserManager<User> userManager)
        {
            //create admin user
            if (userManager.Users.FirstOrDefault(u => u.UserName == "Admin") == null) 
            {
                var adminUser = new User
                {
                    UserName = "Admin"
                };
                var result = userManager.CreateAsync(adminUser, "password").Result;
                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new string[] { "Admin", "Moderatore" }).Wait();
                }
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var strSalt = Salt.Create();
            passwordSalt = Encoding.UTF8.GetBytes(strSalt);
            passwordHash = Encoding.UTF8.GetBytes(Hash.Create(password, strSalt));
        }
    }
}
