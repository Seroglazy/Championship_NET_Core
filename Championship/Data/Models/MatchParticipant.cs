using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data.Models
{
    public class MatchParticipant
    {
        public int ID { set; get; }
        public string player { set; get; }
        public int matchID { set; get; }
        public int result { set; get; }
    }
}
