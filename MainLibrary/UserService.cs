using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class UserService
    {
        public static User Login(string username, string password)
        {
            
            if (username == "admin" && password == "admin123")
            {
                return new User
                {
                    Username = "admin",
                    Role = "Admin"
                };
            }

            return null;
        }
    }
    }
