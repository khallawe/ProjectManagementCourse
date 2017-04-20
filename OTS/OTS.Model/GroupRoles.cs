using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class GroupRoles: Base
    {
        public Group group { get; set; }
        public Role role { get; set; }
    }
}
