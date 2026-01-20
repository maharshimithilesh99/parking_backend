using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.Infrastructure
{
    public class DbConnectionEntities
    {
        public string? ServerName { get; set; }
        public string? DatabaseName { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
