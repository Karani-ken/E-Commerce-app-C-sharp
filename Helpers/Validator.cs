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
    }
}
