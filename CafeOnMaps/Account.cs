using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafes
{
    class Account
    {

        //  Fields  //

        private string login = "";
        private string password = "";

        //  End Fields  //

        // Proparties   //

        public string Login
        {
            get { return login; }
            set
            {
                if (value.Length < 6)
                    throw new Exception("Login must be at least 6 characters!");
                else
                    login = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 6)
                    throw new Exception("Password must be at least 6 characters!");
                else
                    password = value;
            }
        }

        //  End Proparties  //

        //  Constructors    //

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }

        //  End Constructors    //
    }
}
