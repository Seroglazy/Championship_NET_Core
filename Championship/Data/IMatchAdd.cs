using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data
{
    public interface IMatchAdd
    {
        IEnumerable<Players> AllPlayers { get; }
        void AddMatch(MatchAdd matchToAdd, Match newMatch, MatchParticipant MP1, MatchParticipant MP2);
    }
}
