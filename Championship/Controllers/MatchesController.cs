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

        public ViewResult MatchesList(int ? page = 1)
        {
            ViewBag.Title = "Matches List";
            MatchesListViewModel MListed = new MatchesListViewModel();
            MListed.GetAllMatches = _allMatches.AllMatches;
            MListed.GetAllMatchParticipant = _allMatchParticipant.AllMatchParticipant;
            MListed.GetAllMatches = MListed.GetAllMatches.OrderByDescending(m => m.Time);


            var count = 0;
            foreach (Match match in MListed.GetAllMatches)
            { count++; }
            var pagesCount = (count / 10) + 1;

            ViewBag.PagesCount = pagesCount;

            MListed.GetAllMatches = MListed.GetAllMatches.Skip((Convert.ToInt32(page)-1) * 10).Take(10);
            //MListed.GetAllMatches = MListed.GetAllMatches.Take(10);
            return View(MListed);
        }


    }
}
