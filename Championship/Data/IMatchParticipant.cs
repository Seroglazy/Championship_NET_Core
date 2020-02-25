﻿using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data
{
    public interface IMatchParticipant
    {
        IEnumerable<MatchParticipant> AllMatchParticipant { get; }
    }
}
