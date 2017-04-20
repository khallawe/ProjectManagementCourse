using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.DALFactory;
using OTS.Model;

namespace OTS.Areas.UserArea.Controllers
{
    public class UserController : Controller
    {
        
        // GET: UserArea/User
        public ActionResult Index()
        {
            List<User> users = BLL.User.Instance.selectAll();
            return View(users);
        }
        public ActionResult Index2()
        {
            List<User> users = BLL.User.Instance.selectAll();
            return View(users);
        }

    }
}