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
            //Lower section
            label3OfAKindScore.Content = game.lowerValues[0];
            label4OfAKindScore.Content = game.lowerValues[1];
            labelFullHouseScore.Content = game.lowerValues[2];
            labelSmallStrScore.Content = game.lowerValues[3];
            labelLrgStrScore.Content = game.lowerValues[4];
            labelYahtzeeScore.Content = game.lowerValues[5];
            labelChanceScore.Content = game.lowerValues[6];
            labelYahtzeeBonusScore.Content = game.lowerValues[7];

            //Dice
            labelDie1.Content = game.diceArray[0].diceValue;
            labelDie2.Content = game.diceArray[1].diceValue;
            labelDie3.Content = game.diceArray[2].diceValue;
            labelDie4.Content = game.diceArray[3].diceValue;
            labelDie5.Content = game.diceArray[4].diceValue;

            //Upper section - TODO: Move into gamelogic
            labelAcesScore.Content = game.upperValues[0];
            labelTwosScore.Content = game.upperValues[1];
            labelThreesScore.Content = game.upperValues[2];
            labelFoursScore.Content = game.upperValues[3];
            labelFivesScore.Content = game.upperValues[4];
            labelSixesScore.Content = game.upperValues[5];

        }


        //Button Action to roll dice
        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
            game.playSound();
            buttonRollDice.Content = game.rollAll();
            updateGUI();
            if (game.shouldUpdateLabel)
                unholdLabels();
        }

        
        //Button Action to hold rolled dice
        private void buttonHoldDice1_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[0].ToggleDieState();
            if (game.diceArray[0].holdDieState == true)
            {
                labelHoldStatus1.Content = "Held";
                labelHoldStatus1.Foreground = Brushes.Red;

            }
            else
            {
                labelHoldStatus1.Content = "Not Held";
                labelHoldStatus1.Foreground = Brushes.Black;

            }
        }

        private void buttonHoldDice2_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[1].ToggleDieState();
            if (game.diceArray[1].holdDieState == true)
            {
                labelHoldStatus2.Content = "Held";
                labelHoldStatus2.Foreground = Brushes.Red;
            }
            else
            {
                labelHoldStatus2.Content = "Not Held";
                labelHoldStatus2.Foreground = Brushes.Black;

            }
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

        private void buttonAcesScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(0);
            buttonAcesScore.IsEnabled = false;
        }

        private void buttonTwosScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(1);
            buttonTwosScore.IsEnabled = false;
        }

        private void buttonThreesScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(2);
            buttonThreesScore.IsEnabled = false;
        }

        private void buttonFoursScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(3);
            buttonFoursScore.IsEnabled = false;
        }

        private void buttonFivesScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(4);
            buttonFivesScore.IsEnabled = false;
        }

        private void buttonSixesScore_Click(object sender, RoutedEventArgs e)
        {
            game.lockUpperValue(5);
            buttonSixesScore.IsEnabled = false;
        }

        private void button3OfAKindScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4OfAKindScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonFullHouseScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSmallStrScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLrgStrScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonYahtzeeScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.lowerValues[5] == 50)
            {
                game.claimYahtzee();
            }
            game.lockLowerValue(5);
            buttonYahtzeeScore.IsEnabled = false;
        }

        private void buttonChanceScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonYahtzeeBonusScore_Click(object sender, RoutedEventArgs e)
        {
            if (!game.finalLowerValues[5] == true) //check that original Yahtzee is done first.
                MessageBox.Show("You cannot claim a Yahtzee bonus without having an original Yahtzee!", "Invalid Selection");
            else if (game.yahtzeeClaimed == false)
                MessageBox.Show("You cannot claim a Yahtzee bonus when you claimed a zero on Yahtzee!", "Invalid Selection");
            else
            {
                game.yahtzeeBonus();
                labelYahtzeeBonusScore.Content = game.lowerValues[7];
            }
        }


        private void unholdLabels()
        {
            labelHoldStatus1.Content = "Not Held";
            labelHoldStatus1.Foreground = Brushes.Black;
            labelHoldStatus2.Content = "Not Held";
            labelHoldStatus2.Foreground = Brushes.Black;
            labelHoldStatus3.Content = "Not Held";
            labelHoldStatus3.Foreground = Brushes.Black;
            labelHoldStatus4.Content = "Not Held";
            labelHoldStatus4.Foreground = Brushes.Black;
            labelHoldStatus5.Content = "Not Held";
            labelHoldStatus5.Foreground = Brushes.Black;
            game.labelUpdated();
        }
    }
}
