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

        public Players GetPlayerById(int id) => appDBContent.Players.FirstOrDefault(p => p.Id == id);
        public Players GetPlayerByName(string name) => appDBContent.Players.FirstOrDefault(p => p.Profile == name);
        public void UpdateRating(int newRating, string name)
        {
            appDBContent.Players.FirstOrDefault(p => p.Profile == name).Rating = newRating;
            appDBContent.SaveChanges();
        }
        public void AddPlayer(Players newPlayer)
        {
            appDBContent.Players.Add(newPlayer);
            appDBContent.SaveChanges();
        }
    }
}
