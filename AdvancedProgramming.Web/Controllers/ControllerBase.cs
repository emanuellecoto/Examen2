using AdvancedProgramming.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedProgramming.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly UserBusiness UserBusiness;

        public ControllerBase()
        {
            UserBusiness = new UserBusiness();
        }

        protected void SetFilters()
        {
            ViewBag.UserId = new SelectList(UserBusiness.GetUsers(id: 0), "Id", "Id");
        }
    }
}