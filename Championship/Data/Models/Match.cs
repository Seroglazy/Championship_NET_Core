﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data.Models
{
    public class Match
    {
        public int Id { set; get; }
        public string Player1 { set; get; }
        public string Player2 { set; get; }
        public string Winner { set; get; }
        public DateTime Time { set; get; }
        public string Comment { set; get; }
    }
}
