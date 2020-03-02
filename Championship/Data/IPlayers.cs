using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace Championship.Data
{
    public interface IPlayers
    {
        IEnumerable<Players> AllPlayers { get; }
        Players GetPlayerById(int id);
        Players GetPlayerByName(string name);
        void UpdateRating(int newRating, string name);
        void AddPlayer(Players newPlayer);
        void ProfilePic(IFormFile uploadedFile, int LoggedId);
    }
}
