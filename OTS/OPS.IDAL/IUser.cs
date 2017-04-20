using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IUser
    {
        int create(User user);
        int update(User user);
        int delete(User user);
        User selectOne(int id);
        List<User> selectAll();
        List<User> selectByGroup(Group group);



    }
}
