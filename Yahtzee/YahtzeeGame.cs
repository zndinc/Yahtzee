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
        public bool bonusScore { get; private set; } = false; //Whether bonus is achieved. Redundant as of 12/6/15

        public int[] upperValues { get; private set; } = new int[6] { 0, 0, 0, 0, 0, 0 }; //Stores upper values on board. 0= Ace, 1=2 2=3 3=4 4=5
        public int[] lowerValues { get; private set; } = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; // Stores lower values on board. 0=Three of Kind 1=Four of Kind 2= Full House 3= Small Straight 4= Large Straight 5= Yahtzee 6= Chance 7= Yahtzee Bonus

        public bool[] finalUpperValues { get; private set; } = new bool[6] { false, false, false, false, false, false }; //storing locked in score values. Coorelates directly to above arrays.
        public bool[] finalLowerValues { get; private set; } = new bool[7] { false, false, false, false, false, false, false };

        public bool yahtzeeBonusClaimable { get; private set; } = false;
        public bool yahtzeeClaimed { get; private set; } = false;

        public int rollNumber { get; private set; } = 0;//Used to determine when turn should end
        public int turnNumber { get; private set; } = 0; // TODO Implement
        public bool shouldUpdateLabel { get; private set; } = false; //Used to determine if main program should set the dice labels to "Not Held"

        public bool preventButtonClick { get; private set; } = false; //Used to prevent clicking multiple scores per turn.

        //These are done instead of allowing setters to ensure they are not altered outside of reccomended specs, and to prevent logic errors by setting to wrong value or invalid value.
        #region variableSetters

        public void yahtzeeAchieved()
        {
            yahtzeeClaimed = true;
        }

        public void labelUpdated()
        {
            shouldUpdateLabel = false;
        }

        public void yahtzeeBonusAvailible()
        {
            yahtzeeBonusClaimable = true;
        }

        public void lockUpperValue(int index)
        {
            finalUpperValues[index] = true;
        }

        public void lockLowerValue(int index)
        {
            finalLowerValues[index] = true;
        }
        #endregion

        public void turnEnd()
        {
            foreach (Dice d in diceArray)
            {
                d.ReleaseDieState();
            }
            turnNumber++;
            rollNumber = 0;
            shouldUpdateLabel = true;
            preventButtonClick = true;
            if (checkGameEnd())
                gameOver();
        }

        public void gameOver()
        {
            //calcTotalScore();
        }

        public void yahtzeeBonus()
        {
            lowerValues[7] += 100;
        }

        public void playSound()
        {
            soundPlayer.Open(new Uri("diceroll.mp3", UriKind.Relative));
            soundPlayer.Play();
        }

        public string rollAll()
        {
            rollNumber++;
            if (preventButtonClick)
                preventButtonClick = false;

            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i].Roll();

            updateUpperSection();
            updateLowerSection();
            if (rollNumber == 3)
                return "     Roll\n(New Turn)";
            else return "Roll";
        }

        public void initDice()
        {
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i] = new Dice();
        }

        public void updateUpperSection()
        {
            for (int i = 0; i < finalUpperValues.Length; i++)
            {
                if (!finalUpperValues[i])
                {
                    upperValues[i] = scr.dieScore(diceArray, i + 1);
                }
            }
        }

        public int calcUpperScoreTotal()
        {
            upperScore = 0;
            for (int i = 0; i < finalUpperValues.Length; i++)
            {
                if (finalUpperValues[i])
                {
                    upperScore += upperValues[i];
                }
            }
            if (upperScore >= 63)
            {
                bonusScore = true;
                upperScore += 35;
                return upperScore;
            }
            else return upperScore;
        }

        public int calcLowerScoreTotal()
        {
            lowerScore = 0;
            for (int i = 0; i < finalLowerValues.Length; i++)
            {
                if (finalLowerValues[i])
                {
                    lowerScore += lowerValues[i];
                }
            }
            return lowerScore;
        }

        public int calcTotalScore()
        {
            totalScore = 0;
            totalScore = upperScore + lowerScore;
            return totalScore;
        }

        public bool checkGameEnd()
        {
            foreach (bool b in finalLowerValues)
            {
                if (b == false)
                    return false;
            }
            foreach (bool c in finalUpperValues)
            {
                if (c == false)
                    return false;
            }
            return true;
        }

        public void updateLowerSection()
        {
            for (int i = 0; i < finalLowerValues.Length; i++)
            {
                if (!finalLowerValues[i])
                {
                    if (scr.yahtzeeScore(diceArray) == 50 && yahtzeeClaimed) // If joker status is achieved.
                    {
                        switch (i)
                        {
                            case 0:
                                lowerValues[0] = scr.sumOfDice(diceArray);
                                break;
                            case 1:
                                lowerValues[1] = scr.sumOfDice(diceArray);
                                break;
                            case 2:
                                lowerValues[2] = 25;
                                break;
                            case 3:
                                lowerValues[3] = 30;
                                break;
                            case 4:
                                lowerValues[4] = 40;
                                break;
                            case 5:
                                throw new InvalidOperationException("It should not be possible to get a Yahtzee Joker Bonus without having claimd a Yahtzee");
                                break;
                            case 6:
                                lowerValues[6] = scr.chanceScore(diceArray);
                                break;
                            case 7:
                                break;
                            default:
                                throw new InvalidOperationException("Something went wrong inside calcLowerScore, i is out of range");
                                break;
                        }
                        if (yahtzeeBonusClaimable)
                            lowerValues[7] += 100; //Todo JOKER rules
                    }

                    else
                    {
                        switch (i)
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
                            case 7:
                                break;
                            default:
                                throw new InvalidOperationException("Something went wrong inside calcLowerScore, i is out of range");
                                break;
                        }
                    }
                }
            }
        }
    }
}
