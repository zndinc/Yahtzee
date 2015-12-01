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
        YahtzeeGame game = new YahtzeeGame();

        public MainWindow()
        {
            InitializeComponent();
            game.initDice();            
        }

        private void updateGUI()
        {
            label3OfAKindScore.Content = String.Format($"{game.scr.threeOfAKindScore(game.diceArray)}");
            label4OfAKindScore.Content = String.Format($"{game.scr.fourOfAKindScore(game.diceArray)}");
            labelFullHouseScore.Content = String.Format($"{game.scr.fullHouseScore(game.diceArray)}");
            labelSmallStrScore.Content = String.Format($"{game.scr.smallStraightScore(game.diceArray)}");
            labelLrgStrScore.Content = String.Format($"{game.scr.largeStraightScore(game.diceArray)}");
            labelYahtzeeScore.Content = String.Format($"{game.scr.yahtzeeScore(game.diceArray)}");

            //UpdateLabels
            labelDie1.Content = game.diceArray[0].diceValue;
            labelDie2.Content = game.diceArray[1].diceValue;
            labelDie3.Content = game.diceArray[2].diceValue;
            labelDie4.Content = game.diceArray[3].diceValue;
            labelDie5.Content = game.diceArray[4].diceValue;
            labelAcesScore.Content = game.scr.dieScore(game.diceArray, 1);
            labelTwosScore.Content = game.scr.dieScore(game.diceArray, 2);
            labelThreesScore.Content = game.scr.dieScore(game.diceArray, 3);
            labelFoursScore.Content = game.scr.dieScore(game.diceArray, 4);
            labelFivesScore.Content = game.scr.dieScore(game.diceArray, 5);
            labelSixesScore.Content = game.scr.dieScore(game.diceArray, 6);

        }


        //Button Action to roll dice
        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
            game.playSound();
            game.rollAll();
            updateGUI();
        }

        
        //Button Action to hold rolled dice
        private void buttonHoldDice1_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[0].ToggleDieState();
            if (game.diceArray[0].holdDieState == true)
            {
                labelHoldStatus1.Content = "Held";
            }
            else labelHoldStatus1.Content = "Not Held";
        }

        private void buttonHoldDice2_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[1].ToggleDieState();
            if (game.diceArray[1].holdDieState == true)
            {
                labelHoldStatus2.Content = "Held";
            }
            else labelHoldStatus2.Content = "Not Held";
        }

        private void buttonHoldDice3_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[2].ToggleDieState();
            if (game.diceArray[2].holdDieState == true)
            {
                labelHoldStatus3.Content = "Held";
            }
            else labelHoldStatus3.Content = "Not Held";
        }
        private void buttonHoldDice4_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[3].ToggleDieState();
            if (game.diceArray[3].holdDieState == true)
            {
                labelHoldStatus4.Content = "Held";
            }
            else labelHoldStatus4.Content = "Not Held";
        }

        private void buttonHoldDice5_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[4].ToggleDieState();
            if (game.diceArray[4].holdDieState == true)
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
