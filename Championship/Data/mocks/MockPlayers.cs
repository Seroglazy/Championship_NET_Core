using Championship.Data;
using Championship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.mocks
{
    public class MockPlayers : IPlayers
    {
        public IEnumerable<Players> AllPlayers
        {
            get
            {
                return new List<Players>
                {
                    new Players { Id = 1, Alias = "Chudo", Name = "Serega", Pass = "12345", Rating = 0, Img = "/img/rp.png"},
                    new Players { Id = 2, Alias = "Lisa", Name = "Tanya", Pass = "54321", Rating = 0, Img = "/img/rp.png"}
                };
            }
        }

        public Players GetPlayer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
