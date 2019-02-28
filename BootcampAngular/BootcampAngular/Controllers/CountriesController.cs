using BootcampAngular.Context;
using BootcampAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootcampAngular.Controllers
{
    public class CountriesController : Controller
    {
        private MyContext _myContext;
        public CountriesController() {
            _myContext = new MyContext();
        }
        // GET: Countries
        public JsonResult GetCountries()
        {
            List<Country> listCountry = _myContext.Countries.ToList();
            return Json(new { list = listCountry }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountryById(int Id) {
            Country country = _myContext.Countries.Where(x => x.Id == Id).SingleOrDefault();
            return Json(new { country = country }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCountry(Country country)
        {
            _myContext.Countries.Add(country);
            _myContext.SaveChanges();
            return Json(new { status = "Add country successfully" });
        }

        public JsonResult UpdateCountry(Country country)
        {
            _myContext.Entry(country).State = System.Data.Entity.EntityState.Modified;
            _myContext.SaveChanges();
            return Json(new { status = "Update country successfully" });
        }

        public JsonResult DeleteCountry(int Id)
        {
            Country country = _myContext.Countries.Where(x => x.Id == Id).SingleOrDefault();
            _myContext.Countries.Remove(country);
            _myContext.SaveChanges();
            return Json(new { status = "Delete country Successfully" });
        }
    }
}