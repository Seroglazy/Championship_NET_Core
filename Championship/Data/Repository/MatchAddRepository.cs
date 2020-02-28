using Championship.Data.Models;
using Championship.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.Repository
{
    public class MatchAddRepository : IMatchAdd
    {

        private readonly AppDBContent appDBContent;
        
        public MatchAddRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Players> AllPlayers => appDBContent.Players;
        public void AddMatch(MatchAdd matchToAdd, Match newMatch, MatchParticipant MP1, MatchParticipant MP2)
        {
            appDBContent.Matches.Add(newMatch);
            appDBContent.SaveChanges();
            appDBContent.MatchParticipant.Add(new MatchParticipant { player = Convert.ToString(matchToAdd.win), matchID = Convert.ToInt32(newMatch.Id), result = 1 });
            appDBContent.MatchParticipant.Add(new MatchParticipant { player = Convert.ToString(matchToAdd.lose), matchID = Convert.ToInt32(newMatch.Id), result = 0 });
            appDBContent.SaveChanges();
        }
    }
}
