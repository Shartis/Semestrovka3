using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Infrostructure
{
    public class EmailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
}
