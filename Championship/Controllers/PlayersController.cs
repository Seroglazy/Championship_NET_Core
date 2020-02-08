using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data;
using Microsoft.AspNetCore;
using Championship.ViewModels;

namespace Championship.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IMatches _allMatches;
        private readonly IPlayers _allPlayers;

        public PlayersController(IMatches iMatches, IPlayers iPlayers)
        {
            _allMatches = iMatches;
            _allPlayers = iPlayers;
        }

        public ViewResult MatchesList()
        {
            var matches = _allMatches.AllMatches;
            return View(matches);
        }
        public ViewResult PlayersList()
        {
            ViewBag.Title = "Players List";
            //var players = _allPlayers.AllPlayers;
            PlayersListViewModel PListed = new PlayersListViewModel();
            PListed.GetAllPlayers = _allPlayers.AllPlayers;
            return View(PListed);
        }

    }
}
