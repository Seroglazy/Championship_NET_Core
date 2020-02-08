using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<Players> GetAllPlayers { get; set; }

    }
}
