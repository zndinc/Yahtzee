using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dice[] diceArray = new Dice[5];
        ScoreBoard scr = new ScoreBoard();
        MediaPlayer soundPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            InitGame();
            
        }

        private void updateGUI()
        {
            //Need to set up calculations for the upper section
            label3OfAKindScore.Content = String.Format($"{scr.threeOfAKindScore(diceArray)}");
            label4OfAKindScore.Content = String.Format($"{scr.fourOfAKindScore(diceArray)}");
            labelFullHouseScore.Content = String.Format($"{scr.fullHouseScore(diceArray)}");
            labelSmallStrScore.Content = String.Format($"{scr.smallStraightScore(diceArray)}");
            labelLrgStrScore.Content = String.Format($"{scr.largeStraightScore(diceArray)}");
            labelYahtzeeScore.Content = String.Format($"{scr.yahtzeeScore(diceArray)}");

            //UpdateLabels
            labelDie1.Content = diceArray[0].diceValue;
            labelDie2.Content = diceArray[1].diceValue;
            labelDie3.Content = diceArray[2].diceValue;
            labelDie4.Content = diceArray[3].diceValue;
            labelDie5.Content = diceArray[4].diceValue;
        }


        private void InitGame()
        {
            for (int i = 0; i < diceArray.Length; i++)
               diceArray[i] = new Dice();
        }

        //Button Action to roll dice
        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Open(new Uri("diceroll.mp3", UriKind.Relative));
            soundPlayer.Play();
            for (int i = 0; i < diceArray.Length; i++)
                diceArray[i].Roll();
            updateGUI();
        }

        
        //Button Action to hold rolled dice
        private void buttonHoldDice1_Click(object sender, RoutedEventArgs e)
        {
            diceArray[0].ToggleDieState();
            if (diceArray[0].holdDieState == true)
            {
                labelHoldStatus1.Content = "Held";
            }
            else labelHoldStatus1.Content = "Not Held";
        }

        private void buttonHoldDice2_Click(object sender, RoutedEventArgs e)
        {
            diceArray[1].ToggleDieState();
            if (diceArray[1].holdDieState == true)
            {
                labelHoldStatus2.Content = "Held";
            }
            else labelHoldStatus2.Content = "Not Held";
        }

        private void buttonHoldDice3_Click(object sender, RoutedEventArgs e)
        {
            diceArray[2].ToggleDieState();
            if (diceArray[2].holdDieState == true)
            {
                labelHoldStatus3.Content = "Held";
            }
            else labelHoldStatus3.Content = "Not Held";
        }
        private void buttonHoldDice4_Click(object sender, RoutedEventArgs e)
        {
            diceArray[3].ToggleDieState();
            if (diceArray[3].holdDieState == true)
            {
                labelHoldStatus4.Content = "Held";
            }
            else labelHoldStatus4.Content = "Not Held";
        }

        private void buttonHoldDice5_Click(object sender, RoutedEventArgs e)
        {
            diceArray[4].ToggleDieState();
            if (diceArray[4].holdDieState == true)
            {
                labelHoldStatus5.Content = "Held";
            }
            else labelHoldStatus5.Content = "Not Held";
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yathzee, coded by Tanner Menzel, Greg Garner, and Zach Herbert.\nDice roll sound effect recorded by Mike Koenig", "About");
        }
    }
}
