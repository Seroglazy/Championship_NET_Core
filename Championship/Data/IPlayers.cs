﻿using Championship.Data.Models;
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
        Players GetPlayerById(int id);
        Players GetPlayerByName(string name);
        void UpdateRating(int newRating, string name);
    }
}
