﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaApp.Models
{
    public class User
    {
        private string userName;
        private string password;

        public string UserName { get { return userName; } set { userName = value; } }


        public string Password { get { return password; } set { password = value; } }


    }
}
