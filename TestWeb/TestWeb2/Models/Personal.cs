using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeb2.Models
{
    public class Personal
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }

    public class PersonalContext : DbContext
    {
        public DbSet<Personal> Personal { get; set; }
    }
}
