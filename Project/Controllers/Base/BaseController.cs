using System;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.Base
{
    using Domain.Base;
    using Domain.Model;
    public class BaseController : Controller
    {
        protected UnitOfWork _uow = new UnitOfWork();

        public User CurrentUser
        {
            get { return Session["CurrentUser"] as User; }
            set { Session["CurrentUser"] = value; }
        }
        public HttpApplicationStateBase Application
        {
            get { return ControllerContext.RequestContext.HttpContext.Application; }
        }

        protected JsonResult AJAXResult(bool isSucceeded, string message = null)
        {
            if (String.IsNullOrEmpty(message))
                return Json(new { success = isSucceeded });
            else
                return Json(new { success = isSucceeded, message = message });
        }
    }
}