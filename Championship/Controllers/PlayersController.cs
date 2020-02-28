using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data;
using Microsoft.AspNetCore;
using Championship.ViewModels;
using Championship.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Championship.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayers _allPlayers;
        

        public PlayersController(IPlayers iPlayers)
        {
            _allPlayers = iPlayers;
        }
        public ViewResult PlayersList()
        {
            ViewBag.Title = "Players List";
            //var players = _allPlayers.AllPlayers;
            PlayersListViewModel PListed = new PlayersListViewModel();
            PListed.GetAllPlayers = _allPlayers.AllPlayers;
            return View(PListed);
        }

        public IActionResult PlayerAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PlayerAddPost(Players newPlayer)
        {
            _allPlayers.AddPlayer(new Players { Profile = newPlayer.Profile, Pass = newPlayer.Pass, Alias = newPlayer.Alias, Rating = 1400 });
            return Redirect("/Home/Index");
        }
        public IActionResult PlayerLogin()
        {
            ModelState.AddModelError("Invalid Player", "Игрок с таким имененем не найден.");
            return View();
        }
        public IActionResult PlayerLoginPost(Players LoggedPlayer)
        {
            if ((_allPlayers.GetPlayerByName(LoggedPlayer.Profile) != null) && (LoggedPlayer.Pass == _allPlayers.GetPlayerByName(LoggedPlayer.Profile).Pass))
            {
                HttpContext.Session.GetString("LoggedPlayer");
                LoggedPlayer = _allPlayers.GetPlayerByName(LoggedPlayer.Profile);
                HttpContext.Session.SetString("LoggedPlayer", LoggedPlayer.Profile);
            }
            else
            {
                ModelState.AddModelError("Invalid Player", "Игрок с таким имененем не найден.");
            }
            //HttpContext.Session.SetInt32("1", 24);
            //ViewBag.test = HttpContext.Session.GetInt32("1"); 
            //Players person = SessionExtensions.Session.Get<Players>("person");
            // await context.Response.WriteAsync($"Hello {person.Name}, your age: {person.Age}!");
            //SessionExtensions.Set<Players>(context,"Logged", LoggedPlayer.Profile);
            return Redirect("/Home/Index");
        }
        public IActionResult Account()
        {
            //LoggedPlayer = _allPlayers.GetPlayerByName(HttpContext.Session.GetString("LoggedPlayer"));
            Players PListed = new Players();
            PListed = _allPlayers.GetPlayerByName(HttpContext.Session.GetString("LoggedPlayer"));
            return View(PListed);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("LoggedPlayer");
//               HttpContext.Session.SetString("LoggedPlayer", null);
            return Redirect("/Home/Index");
        }
    }
}
