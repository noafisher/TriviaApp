using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Models;

namespace TriviaApp.Services
{
    public class TriviaAppService
    {
        List<User> users;


        public TriviaAppService() 
        {
            users = new List<User>();
            users.Add(new User() {UserName="NoaF" , Password="110907n", Points=1000});
            users.Add(new User() { UserName = "Shahar", Password = "290807s", Points=500 });

        }

        public bool Login(string name, string pass)
        {
            return users.Where(u=>u.UserName == name && u.Password == pass ).FirstOrDefault() != null;
        }

        public List<User> OrderUsers() 
        {
            return this.users.OrderByDescending(u => u.Points).ToList();
        }

       

    }
}
