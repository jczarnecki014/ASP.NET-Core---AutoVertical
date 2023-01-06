using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoVertical_Utility.Roles;
using AutoVertical_Utility;
using AutoVertical_Model.Models;

namespace AutoVertical_Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DbAccess _db;
        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, DbAccess db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            //Create roles if are not created
            if(!_roleManager.RoleExistsAsync(Roles.Role_User_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Employer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Normal)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = Options.DefaultRootEmail,
                    PhoneNumber = "700-200-300",
                    Email = Options.DefaultRootEmail,
                    Name = "Jakub",
                    Surname = "Czarnecki",
                    City = "Jelenia Góra",
                    Country = "Polska",
                    Description = "Default admin user",
                    PostCode = "58-560",
                    RegistrationDate= DateTime.Now,
                    Street = "Goździkowa",
                    StreetNumber = "5",
                    Verificated = true,

                },Options.DefaultRootPass).GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u=>u.Email == Options.DefaultRootEmail);
                _userManager.AddToRoleAsync(user,Roles.Role_User_Admin).GetAwaiter().GetResult();
            }
        }
    }
}
