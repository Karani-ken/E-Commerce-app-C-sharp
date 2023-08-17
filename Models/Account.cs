using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Console_App.Models
{
    public class Account
    {
        public string Id { get; set; }
        public int Balance { get; set; } = 0;
        public Users user { get; set; }

    }
}
