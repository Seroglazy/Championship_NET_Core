using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data;
using Microsoft.AspNetCore;
using Championship.ViewModels;
using Championship.Data.Models;

namespace Championship.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatches _allMatches;
        private readonly IMatchParticipant _allMatchParticipant;

        public MatchesController(IMatches iMatches, IMatchParticipant imatchParticipant)
        {
            _allMatchParticipant = imatchParticipant;
            _allMatches = iMatches;
        }

        public ViewResult MatchesList()
        {
            ViewBag.Title = "Matches List";
            //var matches = _allMatches.AllMatches;
            //return View(matches);
            MatchesListViewModel MListed = new MatchesListViewModel();
            //MatchParticipantViewModel MPListed = new MatchParticipantViewModel();
            MListed.GetAllMatches = _allMatches.AllMatches;
            MListed.GetAllMatchParticipant = _allMatchParticipant.AllMatchParticipant;
            //MPListed.GetAllMatchParticipant = _allMatchParticipant.GetMatchParticipant;
            return View(MListed);
        }


    }
}
