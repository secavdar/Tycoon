using System.Web.Mvc;

namespace Project.Controllers.Base
{
    public class GenericController<T> : BaseController where T : class
    {
        public virtual ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public virtual PartialViewResult Get(int id)
        {
            T entity = _uow.Call<T>().Find(id);
            return PartialView("Edit", entity);
        }
        [HttpPost]
        public virtual PartialViewResult New()
        {
            return PartialView("Edit");
        }
    }
}