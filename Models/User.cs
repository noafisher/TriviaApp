using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaApp.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get;  set ;  }
        public string Email { get;  set ;  }
        public int Points { get ;  set ;  }
        public Rank Rank{ get; set; }
        public User() 
        {
            
        }
       



    }
}
