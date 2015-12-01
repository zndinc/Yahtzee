using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Yahtzee
{
    class YahtzeeGame
    {
        public Dice[] diceArray { get; private set; } = new Dice[5];
        public ScoreBoard scr { get; private set; } = new ScoreBoard();
        public MediaPlayer soundPlayer { get; private set; } = new MediaPlayer();
        public int totalScore { get; private set; } = 0;
        public int upperScore { get; private set; } = 0;
        public int lowerScore { get; private set; } = 0;
        public bool bonusScore { get; private set; } = false;

        public int[] upperValues { get; private set; } = new int[6] { 0, 0, 0, 0, 0, 0 };
        public int[] lowerValues { get; private set; } = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

        public bool[] finalUpperValues { get; private set; } = new bool[6] { false, false, false, false, false, false }; //storing locked in score values.
        public bool[] finalLowerValues { get; private set; } = new bool[7] { false, false, false, false, false, false, false };





        public void playSound()
        {
            soundPlayer.Open(new Uri("diceroll.mp3", UriKind.Relative));
            soundPlayer.Play();
        }

        public void rollAll()
        {
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i].Roll();
            calcUpperScore();
            calcLowerScore();
            calcTotalScore();
            calcBonusScore();
        }

        public void initDice()
        {
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i] = new Dice();
        }

        public void calcUpperScore()
        {
            for (int i = 0; i < finalUpperValues.Length; i++)
            {
                if (!finalUpperValues[i])
                {
                    upperValues[i] = scr.dieScore(diceArray, i + 1);
                }
            }
        }

        public void calcLowerScore()
        {
            for (int i = 0; i < finalLowerValues.Length; i++)
            {
                if (!finalLowerValues[i])
                {
                    switch(i)
                    {
                        case 0:
                            lowerValues[0] = scr.threeOfAKindScore(diceArray);
                            break;
                        case 1:
                            lowerValues[1] = scr.fourOfAKindScore(diceArray);
                            break;
                        case 2:
                            lowerValues[2] = scr.fullHouseScore(diceArray);
                            break;
                        case 3:
                            lowerValues[3] = scr.smallStraightScore(diceArray);
                            break;
                        case 4:
                            lowerValues[4] = scr.largeStraightScore(diceArray);
                            break;
                        case 5:
                            lowerValues[5] = scr.yahtzeeScore(diceArray);
                            break;
                        case 6:
                            lowerValues[6] = scr.chanceScore(diceArray);
                            break;
                        default:
                            throw new InvalidOperationException("Something went wrong inside calcLowerScore, i is out of range");
                            break;

                    }
                }
            }
        }

        public void calcBonusScore()
        {

        }

        public void calcTotalScore()
        {

        }
    }
}
