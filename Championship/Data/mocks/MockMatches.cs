using Championship.Data;
using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.mocks
{
    public class MockMatches : IMatches
    {
        public IEnumerable<Match> AllMatches
        {
            get
            {
                return new List<Match>
                {
                    new Match { Id = 1, Player1 = "Tanya", Player2 = "Serega", Time = new DateTime (2020,02,01), Winner = "Tanya", Comment = "Матч 1"},
                    new Match { Id = 2, Player1 = "Tanya", Player2 = "Serega", Time = new DateTime (2020,02,01), Winner = "Serega", Comment = "Матч 2"}
                };
            }
        }

    }
}
