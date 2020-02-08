using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data
{
    public interface IPlayers
    {
        IEnumerable<Players> AllPlayers { get; }
        Players GetPlayer(int id);
    }
}
