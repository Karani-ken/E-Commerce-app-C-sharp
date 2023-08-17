using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Console_App.Helpers
{
    public class Validator
    {
        public static bool Validation(List<string> input)
        {
           var IsValid = false;
            foreach (var item in input)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    IsValid = false;break;
                }
                IsValid = true;
            }

            return IsValid;
        }
        public bool DetailsChecker(string username,string password1, string password2,string email)
        {
            var isValid = false;
            if(username == null || password1 == null || password2 == null || email == null)
            {
                Console.WriteLine("Please Enter all the fields");
                isValid = false;
            }else if(password1 != password2)
            {
                Console.WriteLine("Password do not match");
                isValid=false;
            }
            else
            {
                isValid=true;
            }
            return isValid;
        }
    }
}
