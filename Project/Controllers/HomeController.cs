using System.Web.Mvc;

namespace Project.Controllers
{
    using Base;
    using Domain.Model;
    public class HomeController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
        public JsonResult Login(User entity)
        {
            entity.Password = _uow.HashString(entity.Password.Trim());
            CurrentUser = _uow.Call<User>().Find(x => x.UserName == entity.UserName && x.Password == entity.Password);
            return AJAXResult(true);
        }
    }
}