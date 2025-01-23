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
using Microsoft.EntityFrameworkCore;
using AutoVertical_Data.DbInitializer.EntityInitiaizers;

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

        public async Task InitializeAsync(params IEntityInitializer[] modelList)
        {
            if(_db.Database.IsRelational())
            {
                if(_db.Database.GetPendingMigrations() != null)
                {
                    _db.Database.Migrate();
                }

                await CreateDefaultRole();
                await CreateDefaultAdminUser();


                //Set only test mode

                foreach(var model in modelList )
                {
                    await model.PushEntityAsync(_db);
                }

                
            }
        }

        private async Task CreateDefaultRole()
        {
            if(! await _roleManager.RoleExistsAsync(Roles.Role_User_Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Admin));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Employer));
                await  _roleManager.CreateAsync(new IdentityRole(Roles.Role_User_Normal));
            }
        }

        private async Task CreateDefaultAdminUser()
        {
            var existUser = _db.Users.FirstOrDefault(u => u.Email == Options.DefaultRootEmail);
            if(existUser is null)
            {
                await _userManager.CreateAsync(new ApplicationUser
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

                },Options.DefaultRootPass);

                ApplicationUser newUser = _db.ApplicationUser.FirstOrDefault(u=>u.Email == Options.DefaultRootEmail);
                await _userManager.AddToRoleAsync(newUser,Roles.Role_User_Admin);
            }
        }
    }

}
