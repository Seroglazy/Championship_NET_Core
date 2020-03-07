using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.ViewModels
{
    public class MatchesListViewModel
    {
        public IEnumerable<Match> GetAllMatches { get; set; }
        public IEnumerable<MatchParticipant> GetAllMatchParticipant { get; set; }
        public IEnumerable<Players> GetAllPlayers { get; set; }

    }
}
