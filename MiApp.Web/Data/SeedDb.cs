using MiApp.Common.Enums;
using MiApp.Web.Data.Entities;
using MiApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiApp.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckItemsAsync();

            var manager = await CheckUserAsync("17157729", "Luis", "Núñez", "luisalbertonu@gmail.com", "156 814 963", "Espora 2052 - Rosedal", UserType.Admin);
            var appUser1 = await CheckUserAsync("11111111", "Luis", "Núñez", "lucho@yopmail.com", "156 101 010", "Espora 2052 - Rosedal", UserType.User);
            var appUser2 = await CheckUserAsync("22222222", "Pablo", "Lacuadri", "lacuadri@yopmail.com", "156 202 020", "Villa Santa Ana", UserType.User);
            var appUser3 = await CheckUserAsync("33333333", "Diego", "Maradona", "maradona@yopmail.com", "156 303 030", "Villa Fiorito", UserType.User);
            var appUser4 = await CheckUserAsync("44444444", "Lionel", "Messi", "messi@yopmail.com", "156 404 040", "Barcelona", UserType.User);

            await CheckManagerAsync(manager);

            if (!_context.AppUsers.Any())
            { 
                await CheckAppUserAsync(appUser1);
                await CheckAppUserAsync(appUser2);
                await CheckAppUserAsync(appUser3);
                await CheckAppUserAsync(appUser4);
            }
        }

        private async Task CheckManagerAsync(UserEntity user)
        {
            if (!_context.Managers.Any())
            { 
                _context.Managers.Add(new ManagerEntity { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAppUserAsync(UserEntity user)
        {
                _context.AppUsers.Add(new AppUserEntity { User = user });
                await _context.SaveChangesAsync();
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }



        private async Task CheckItemsAsync()
        {
            if (!_context.Items.Any())
            {
                AddItem("Item01", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 1.50);
                AddItem("Item02", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 2.50);
                AddItem("Item03", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 3.50);
                //AddItem("Item04", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 4.50);
                //AddItem("Item05", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 5.50);
                //AddItem("Item06", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 6.50);
                //AddItem("Item07", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 7.50);
                //AddItem("Item08", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 8.50);
                //AddItem("Item09", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 9.50);
                //AddItem("Item10", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 10.50);
                await _context.SaveChangesAsync();
            }
        }

        private void AddItem(string name, string logoPath,bool active, DateTime date,int quantity,double price)
        {
            _context.Items.Add(new ItemEntity { Name = name, LogoPath = logoPath, Active=active,Date=date,Quantity=quantity,Price=price});
        }

        private async Task<UserEntity> CheckUserAsync(
                string document,
                string firstName,
                string lastName,
                string email,
                string phone,
                string address,
                UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

    }
}