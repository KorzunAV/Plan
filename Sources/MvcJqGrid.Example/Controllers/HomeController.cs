using System.Linq;
using System.Web.Mvc;
using Common.Data.Core;
using Entities;
using MvcJqGrid.Example.Models;
using Ninject;

namespace MvcJqGrid.Example.Controllers
{
    [HandleError]
    public class HomeController : BaseController<HomeController>
    {
        protected IBaseDao Dao { get { return Kernel.Get<IBaseDao>(); } }

        private readonly Repository _repo;

        //public HomeController() :base()
        //{
        //    _repo = new Repository();
        //}

        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewData["CompanyNames"] = _repo.GetCompanyNames();
            return View();
        }

        public ActionResult DefaultSearchValue()
        {
            ViewData["CompanyNames"] = _repo.GetCompanyNames();
            return View();
        }

        public ActionResult Toolbar()
        {
            return View();
        }

        public ActionResult Multiselect()
        {
            return View();
        }

        public ActionResult Formatters()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult VirtualScrolling()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// AJAX request, retrieves data for basic grid
        /// </summary>
        /// <param name="gridSettings">Settings received from jqGrid request</param>
        /// <returns>JSON view containing data for basic grid</returns>
        public ActionResult GridDataBasic(GridSettings gridSettings)
        {
            var items = Dao.SelectRange<UserRole>(new SelectCondition());

            var jsonData = new
            {
                total = items.ItemsCount / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = items.Result.Count,

                rows = (
                    from c in items.Result
                    select new
                    {
                        id = c.Id,
                        cell = new[] { c.Name }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

            //var customers = _repo.GetCustomers(gridSettings);
            //var totalCustomers = _repo.CountCustomers(gridSettings);

            //var jsonData = new
            //{
            //    total = totalCustomers / gridSettings.PageSize + 1,
            //    page = gridSettings.PageIndex,
            //    records = totalCustomers,
            //    rows = (
            //        from c in customers
            //        select new
            //        {
            //            id = c.CustomerId, // Remove ravendb prefix from identifier
            //            cell = new[] 
            //        { 
            //            c.CustomerId, 
            //            c.Fullname,
            //            c.Company,
            //            c.EmailAddress,
            //            c.LastModified.ToShortDateString(),
            //            c.Telephone
            //        }
            //        }).ToArray()
            //};

            //return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TreeGrid()
        {
            return View();
        }


        public ActionResult TreeGridData()
        {
            Response.ContentType = "text/xml";
            return View();
        }
    }
}
