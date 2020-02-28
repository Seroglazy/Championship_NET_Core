using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship
{
    public class ELO
    {
        static double ExpectationToWin(int playerOneRating, int playerTwoRating)
        {
            return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }

        public enum GameOutcome
        {
            Win = 1,
            Loss = 0
        }
        public static void CalculateELO(ref int playerOneRating, ref int playerTwoRating, int outcome)
        {
            int eloK = 32;

            int delta = (int)(eloK * (outcome - ExpectationToWin(playerOneRating, playerTwoRating)));

            playerOneRating += delta;
            playerTwoRating -= delta;
        }

    }
}
