using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    class User : IUser
    {
        private OTSContext Db = new OTSContext();
        public int create(Model.User user)
        {
            throw new NotImplementedException();
        }

        public int delete(Model.User user)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> selectAll()
        {
            try
            {
                
                return Db.UserSet.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Model.User> selectByGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public Model.User selectOne(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Model.User user)
        {
            throw new NotImplementedException();
        }
    }
}
