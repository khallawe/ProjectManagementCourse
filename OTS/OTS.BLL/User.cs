using OTS.DALFactory;
using OTS.IDAL;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.BLL
{
   
    public class User: IUser
    {
        private static readonly IUser dal = DataAccess.CreateInstance<IUser>("User");
        /// <summary>
        /// singleton
        /// </summary>
        public static User Instance { get { User Instance = new User(); return Instance; } }
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

                return dal.selectAll();

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
