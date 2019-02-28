using BootcampAngular.Context;
using BootcampAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootcampAngular.Controllers
{
    public class PlayersController : Controller
    {
        private MyContext _myContext = null;
        Player param = new Player();
        public PlayersController() {
            _myContext = new MyContext();
        }

        // GET: Players
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = _myContext.Players.ToList();
            return Json(new {list = listPlayers}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int Id)
        {
            Player player = _myContext.Players.Where(x => x.Id == Id).SingleOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player)
        {
            var get = _myContext.Countries.Find(player.Countries.Id);
            param.Name = player.Name;
            param.Club = player.Club;
            param.Age = player.Age;
            param.Countries = get;
            _myContext.Players.Add(param);
            _myContext.SaveChanges();
            return Json(new { status = "Player added successfully" });
        }
        public JsonResult EditPlayer(Player player)
        {
            var get = _myContext.Countries.Find(player.Countries.Id);
            param.Name = player.Name;
            param.Club = player.Club;
            param.Age = player.Age;
            param.Countries = get;
            _myContext.Entry(param).State = System.Data.Entity.EntityState.Modified;
            _myContext.SaveChanges();
            return Json(new { status = "Player updated successfully" });
        }

        public JsonResult DeletePlayer(int Id)
        {
            Player player = _myContext.Players.Where(x => x.Id == Id).SingleOrDefault();
            _myContext.Players.Remove(player);
            _myContext.SaveChanges();
            return Json(new { status = "Player deleted successfully" });
        }
    }
}