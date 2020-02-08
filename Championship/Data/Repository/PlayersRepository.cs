using Championship.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.Repository
{
    public class PlayersRepository : IPlayers
    {
        private readonly AppDBContent appDBContent;
        public PlayersRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        
        public IEnumerable<Players> AllPlayers => appDBContent.Players;

        public Players GetPlayer(int id) => appDBContent.Players.FirstOrDefault(p => p.Id == id);
    }
}
