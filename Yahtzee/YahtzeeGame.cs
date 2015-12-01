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



        public void playSound()
        {
            soundPlayer.Open(new Uri("diceroll.mp3", UriKind.Relative));
            soundPlayer.Play();
        }

        public void rollAll()
        {
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i].Roll();
        }

        public void initDice()
        {
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i] = new Dice();
        }
    }
}
