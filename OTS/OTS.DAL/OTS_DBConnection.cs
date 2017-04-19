using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OTS.DAL
{
    class OTS_DBConnection:DbContext
    {
        public DbSet<Answer> answers { get; set; }
    }
}
