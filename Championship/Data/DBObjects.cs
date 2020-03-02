using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data.Models;

namespace Championship.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            content.Database.EnsureCreated();
            //if (!content.Players.Any())
            //{
            //    //content.Players.AddRange(PlayerRange.Select(p => p.Value));
            //    content.Players.Add(new Players { Alias = "SSS", Profile = "TestPlayer1", Rating = 1400, Pass = "12345" });
            //    content.Players.Add(new Players { Alias = "TTT", Profile = "TestPlayer2", Rating = 1400, Pass = "12345" });
            //}
                
            
            //if (!content.Matches.Any())
            //{
            //    content.Matches.Add(new Match { Comment = "Матч 1", Time = new DateTime(2020, 2, 29, 14, 30, 0) });
            //    content.Matches.Add(new Match { Comment = "Матч 2", Time = new DateTime(2020, 2, 29, 15, 30, 0) });
            //    content.Matches.Add(new Match { Comment = "Матч 3", Time = new DateTime(2020, 2, 29, 16, 30, 0) });

            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 1, player = "TestPlayer1", result = 1 });
            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 1, player = "TestPlayer2", result = 0 });
            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 2, player = "TestPlayer1", result = 0 });
            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 2, player = "TestPlayer2", result = 1 });
            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 3, player = "TestPlayer1", result = 0 });
            //    content.MatchParticipant.Add(new MatchParticipant { matchID = 3, player = "TestPlayer2", result = 1 });
            //}

            content.SaveChanges();
        }


    }
}
