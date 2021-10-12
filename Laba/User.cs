using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba
{
    class User
    {

       public int id { get; set; }

       public string login, password;

        public User() { }
        public User(string login, string  password) {
            this.login = login;
            this.password = password;
        }

    }
}
