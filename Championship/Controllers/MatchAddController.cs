using Championship.Data;
using Championship.Data.Models;
using Championship.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Controllers
{
    public class MatchAddController : Controller
    {
       // public static AppDBContent appDBContent;


        private readonly IMatchAdd _AddMatch;
        public readonly IMatches _match;
        private readonly IPlayers _allPlayers;
        private readonly IMatchParticipant _allMP;

        [ActivatorUtilitiesConstructor]
        public MatchAddController(IMatchAdd AddMatch, IMatches match, IPlayers iPlayers, IMatchParticipant iMP)
        {
            _AddMatch = AddMatch;
            _match = match;
            _allPlayers = iPlayers;
            _allMP = iMP;
        }
        //[Authorize]
        public IActionResult MA()
        {
            
            IEnumerable<SelectListItem> items = _allPlayers.AllPlayers.Select(c => new SelectListItem
            {
                Value = c.Alias,
                Text = c.Alias
            });
            ViewBag.Profile = items;


            if (_allPlayers.GetPlayerById(1) != null) ViewBag.state = _allPlayers.GetPlayerById(1).Profile;

            return View();
        }
        [HttpPost]
        public IActionResult MAPost(MatchAdd matchToAdd)
        {
            
            if (matchToAdd.win == matchToAdd.lose || matchToAdd.win == null || matchToAdd.lose == null)
            {
                ViewBag.PostResultText = "Матч не добавлен! Участники заданы неверно.";
                ViewBag.PostResult = "0";
                return View();
            }
            int PONewRating = 0; int PTNewRating = 0;

            if (matchToAdd.time == new DateTime(1, 1, 1, 0, 0, 0)) matchToAdd.time = DateTime.Now;
            Match newMatch = new Match { Time = matchToAdd.time, Comment = matchToAdd.comment+""};
            MatchParticipant ParticipantOne = new MatchParticipant { player = Convert.ToString(matchToAdd.win), matchID = Convert.ToInt32(newMatch.Id), result = 1 };
            MatchParticipant ParticipantTwo = new MatchParticipant { player = Convert.ToString(matchToAdd.lose), matchID = Convert.ToInt32(newMatch.Id), result = 0 };
            PONewRating = _allPlayers.GetPlayerByAlias(matchToAdd.win).Rating;
            PTNewRating = _allPlayers.GetPlayerByAlias(matchToAdd.lose).Rating;
            ELO.CalculateELO(ref PONewRating, ref PTNewRating, 1);
            ELO.CalculateELO(ref PTNewRating, ref PONewRating, 0);
            //POne.Rating = PONewRating;
            //PTwo.Rating = PONewRating;
            _allPlayers.UpdateRating(PONewRating, matchToAdd.win);
            _allPlayers.UpdateRating(PTNewRating, matchToAdd.lose);
            PONewRating = 0; PTNewRating = 0;
            _AddMatch.AddMatch(matchToAdd, newMatch, ParticipantOne, ParticipantTwo);

            //ViewBag.AP = _allPlayers.AllPlayers
            PlayersListViewModel PListed = new PlayersListViewModel();
            PListed.GetAllPlayers = _allPlayers.AllPlayers;
            ViewBag.PostResultText = "Матч добавлен!";
            ViewBag.PostResult = "1";
            return View();
        }
    }
}
