using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public abstract class User : Base<User>
    {
        //protected string _login;
        public abstract string Login { get; set; }
        //protected string _password;
        public abstract string Password { get; set; }
    }
}
