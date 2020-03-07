using Championship.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.Repository
{
    public class MatchesRepository : IMatches
    {
        private readonly AppDBContent appDBContent;
        public MatchesRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //public IEnumerable<Match> Matches => appDBContent.Matches.Include(c => c);
        public IEnumerable<Match> AllMatches => appDBContent.Matches;
        public IEnumerable<Players> AllPlayers => appDBContent.Players;



    }
}
