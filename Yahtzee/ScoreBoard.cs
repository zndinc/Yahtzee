using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class ScoreBoard
    {
        public int sumOfDice(Dice[] diceCount)
        {
            int totalDiceCount = new int(); // Moved this inside so it doesn't continue to add previous dice.
            for (int i = 0; i < diceCount.Length; i++) //Modified this in case more than five dice are sent. Shouldn't happen, but better code practice.
            {
                totalDiceCount += diceCount[i].diceValue; //Changed this to make it work.
            }
            return totalDiceCount;
        }

        public int threeOfAKindScore(Dice[] calcThreeOfAKind)
        {


            int score = new int();
            if (calcThreeOfAKind[0] == calcThreeOfAKind[1] && calcThreeOfAKind[1] == calcThreeOfAKind[2] || calcThreeOfAKind[0] == calcThreeOfAKind[1] && calcThreeOfAKind[1] == calcThreeOfAKind[3] ||
                calcThreeOfAKind[0] == calcThreeOfAKind[1] && calcThreeOfAKind[1] == calcThreeOfAKind[4] || calcThreeOfAKind[0] == calcThreeOfAKind[2] && calcThreeOfAKind[2] == calcThreeOfAKind[3] ||
                calcThreeOfAKind[0] == calcThreeOfAKind[2] && calcThreeOfAKind[2] == calcThreeOfAKind[4] || calcThreeOfAKind[0] == calcThreeOfAKind[3] && calcThreeOfAKind[3] == calcThreeOfAKind[4] ||
                calcThreeOfAKind[1] == calcThreeOfAKind[2] && calcThreeOfAKind[2] == calcThreeOfAKind[3] || calcThreeOfAKind[1] == calcThreeOfAKind[2] && calcThreeOfAKind[2] == calcThreeOfAKind[4] ||
                calcThreeOfAKind[2] == calcThreeOfAKind[3] && calcThreeOfAKind[3] == calcThreeOfAKind[4] || calcThreeOfAKind[1] == calcThreeOfAKind[3] && calcThreeOfAKind[3] == calcThreeOfAKind[4])
            {
                score = sumOfDice(calcThreeOfAKind);
            }
            else
                score = 0;
            return score;

        }

        public int fourOfAKindScore(Dice[] calcFourOfAKind)
        {

            int score = new int();
            if (calcFourOfAKind[1] == calcFourOfAKind[2] && calcFourOfAKind[2] == calcFourOfAKind[3] && calcFourOfAKind[3] == calcFourOfAKind[4] ||
               calcFourOfAKind[0] == calcFourOfAKind[1] && calcFourOfAKind[1] == calcFourOfAKind[2] && calcFourOfAKind[2] == calcFourOfAKind[3] ||
               calcFourOfAKind[0] == calcFourOfAKind[1] && calcFourOfAKind[1] == calcFourOfAKind[3] && calcFourOfAKind[3] == calcFourOfAKind[4] ||
               calcFourOfAKind[0] == calcFourOfAKind[2] && calcFourOfAKind[2] == calcFourOfAKind[3] && calcFourOfAKind[3] == calcFourOfAKind[4] ||
               calcFourOfAKind[0] == calcFourOfAKind[1] && calcFourOfAKind[1] == calcFourOfAKind[2] && calcFourOfAKind[2] == calcFourOfAKind[4])
            {
                score = sumOfDice(calcFourOfAKind);
            }
            else score = 0;
            return score;
        }

        public int fullHouseScore(Dice[] calcFullHouse)
        {
            int score = new int();
            if (calcFullHouse[0] == calcFullHouse[1] && calcFullHouse[1] == calcFullHouse[2] && calcFullHouse[3] == calcFullHouse[4] ||
                calcFullHouse[0] == calcFullHouse[1] && calcFullHouse[1] == calcFullHouse[3] && calcFullHouse[2] == calcFullHouse[4] ||
                calcFullHouse[0] == calcFullHouse[1] && calcFullHouse[1] == calcFullHouse[4] && calcFullHouse[2] == calcFullHouse[3] ||
                calcFullHouse[0] == calcFullHouse[2] && calcFullHouse[2] == calcFullHouse[3] && calcFullHouse[1] == calcFullHouse[4] ||
                calcFullHouse[0] == calcFullHouse[2] && calcFullHouse[2] == calcFullHouse[4] && calcFullHouse[1] == calcFullHouse[3] ||
                calcFullHouse[0] == calcFullHouse[3] && calcFullHouse[3] == calcFullHouse[4] && calcFullHouse[1] == calcFullHouse[2] ||
                calcFullHouse[1] == calcFullHouse[2] && calcFullHouse[2] == calcFullHouse[3] && calcFullHouse[0] == calcFullHouse[4] ||
                calcFullHouse[1] == calcFullHouse[2] && calcFullHouse[2] == calcFullHouse[4] && calcFullHouse[0] == calcFullHouse[3] ||
                calcFullHouse[2] == calcFullHouse[3] && calcFullHouse[3] == calcFullHouse[4] && calcFullHouse[0] == calcFullHouse[1] ||
                calcFullHouse[1] == calcFullHouse[3] && calcFullHouse[3] == calcFullHouse[4] && calcFullHouse[0] == calcFullHouse[2])
            {
                score = 25;
            }
            else score = 0;
            return score;

        }

        public int smallStraightScore(Dice[] calcSmallStraight)
        {
            int score = new int();
            Dice[] target = new Dice[5]; // Changed to not sort array being sent, was causing issues with dice being out of order.
            Array.Copy(calcSmallStraight, target, 5);
            Array.Sort(target);
            if (
                calcSmallStraight[0] == calcSmallStraight[1] && (calcSmallStraight[4] - calcSmallStraight[3]) == 1 && (calcSmallStraight[3] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 ||
                calcSmallStraight[1] == calcSmallStraight[2] && (calcSmallStraight[4] - calcSmallStraight[3]) == 1 && (calcSmallStraight[3] - calcSmallStraight[1]) == 1 && (calcSmallStraight[1] - calcSmallStraight[0]) == 1 ||
                calcSmallStraight[2] == calcSmallStraight[3] && (calcSmallStraight[4] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 && (calcSmallStraight[1] - calcSmallStraight[0]) == 1 ||
                calcSmallStraight[3] == calcSmallStraight[4] && (calcSmallStraight[3] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 && (calcSmallStraight[1] - calcSmallStraight[0]) == 1 ||
                (calcSmallStraight[4] - calcSmallStraight[3]) == 1 && (calcSmallStraight[3] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 && (calcSmallStraight[1] - calcSmallStraight[0]) == 1 ||
                calcSmallStraight[0] != calcSmallStraight[1] && (calcSmallStraight[4] - calcSmallStraight[3]) == 1 && (calcSmallStraight[3] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 ||
                calcSmallStraight[4] != calcSmallStraight[3] && (calcSmallStraight[3] - calcSmallStraight[2]) == 1 && (calcSmallStraight[2] - calcSmallStraight[1]) == 1 && (calcSmallStraight[1] - calcSmallStraight[0]) == 1
                )
            {
                score = 30;
            }
            else score = 0;
            return score;
        }

        public int largeStraightScore(Dice[] calcLargeStraight)
        {
            int score = new int();
            Dice[] target = new Dice[5]; // Changed to not sort array being sent, was causing issues with dice being out of order.
            Array.Copy(calcLargeStraight, target, 5);
            Array.Sort(target);
            if (

                (calcLargeStraight[4] - calcLargeStraight[3]) == 1 && (calcLargeStraight[3] - calcLargeStraight[2]) == 1 && (calcLargeStraight[2] - calcLargeStraight[1]) == 1 && (calcLargeStraight[1] - calcLargeStraight[0]) == 1

                )
            {
                score = 40;
            }
            else score = 0;
            return score;
        }

        public int yahtzeeScore(Dice[] calcYahtzee)
        {
            int score = new int();
            if (
                calcYahtzee[0] == calcYahtzee[1] && calcYahtzee[1] == calcYahtzee[2] && calcYahtzee[2] == calcYahtzee[3] && calcYahtzee[3] == calcYahtzee[4]
                )
            {
                score = 50;
            }

            else score = 0;
            return score;

        }
    }
}
