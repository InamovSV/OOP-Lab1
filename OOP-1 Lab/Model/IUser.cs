using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public interface IUser
    {
        //protected string _login;
        string Login { get; set; }
        //protected string _password;
        string Password { get; set; }
    }
}
