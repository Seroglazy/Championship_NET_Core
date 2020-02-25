using Championship.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.Repository
{
    public class MatchParticipantRepository : IMatchParticipant
    {
        private readonly AppDBContent appDBContent;
        public MatchParticipantRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //public IEnumerable<Match> Matches => appDBContent.Matches.Include(c => c);
        public IEnumerable<MatchParticipant> AllMatchParticipant => appDBContent.MatchParticipant;
    }
}
