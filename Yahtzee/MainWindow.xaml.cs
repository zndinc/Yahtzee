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
        //string die1ImagePath = "Resources\\images\\die1.png";

        public MainWindow()
        {
            InitializeComponent();
            game.initDice();
        }

        private string imagePath(int dieValue)
        {
            switch (dieValue)
            {
                case 1:
                    return "Resources\\images\\die1.png";
                case 2:
                    return "Resources\\images\\die2.png";
                case 3:
                    return "Resources\\images\\die3.png";
                case 4:
                    return "Resources\\images\\die4.png";
                case 5:
                    return "Resources\\images\\die5.png";
                case 6:
                    return "Resources\\images\\die6.png";
                
            }
            throw new ArgumentException("Invalid integer sent to ImagePath");
        }

        private void updateScoreGUI()
        {
            labelUpperTotal.Content = game.calcUpperScoreTotal();
            labelLowerTotal.Content = game.calcLowerScoreTotal();
            if (game.bonusScore) labelUpperBonusScore.Content = 35;
            labelTotalScore.Content = game.calcTotalScore();
        }

        private void checkGameOver()
        {
            if (game.checkGameEnd())
            {
                MessageBox.Show($"Game Over! Your final score was {game.totalScore}", "Game Over!");
                buttonRollDice.IsEnabled = false;
                buttonHoldDice1.IsEnabled = false;
                buttonHoldDice2.IsEnabled = false;
                buttonHoldDice3.IsEnabled = false;
                buttonHoldDice4.IsEnabled = false;
                buttonHoldDice5.IsEnabled = false;
            }
            else return;
        }

        private void updateGUI()
        {
            //Upper section
            labelAcesScore.Content = game.upperValues[0];
            labelTwosScore.Content = game.upperValues[1];
            labelThreesScore.Content = game.upperValues[2];
            labelFoursScore.Content = game.upperValues[3];
            labelFivesScore.Content = game.upperValues[4];
            labelSixesScore.Content = game.upperValues[5];

            //Lower section
            label3OfAKindScore.Content = game.lowerValues[0];
            label4OfAKindScore.Content = game.lowerValues[1];
            labelFullHouseScore.Content = game.lowerValues[2];
            labelSmallStrScore.Content = game.lowerValues[3];
            labelLrgStrScore.Content = game.lowerValues[4];
            labelYahtzeeScore.Content = game.lowerValues[5];
            labelChanceScore.Content = game.lowerValues[6];

            //Dice
            imageDie1.Source = new BitmapImage(new Uri(imagePath(game.diceArray[0].diceValue), UriKind.Relative));
            imageDie2.Source = new BitmapImage(new Uri(imagePath(game.diceArray[1].diceValue), UriKind.Relative));
            imageDie3.Source = new BitmapImage(new Uri(imagePath(game.diceArray[2].diceValue), UriKind.Relative));
            imageDie4.Source = new BitmapImage(new Uri(imagePath(game.diceArray[3].diceValue), UriKind.Relative));
            imageDie5.Source = new BitmapImage(new Uri(imagePath(game.diceArray[4].diceValue), UriKind.Relative));

        }


        //Button Action to roll dice
        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
            game.playSound();
            if (game.rollNumber == 3)
            {
                MessageBox.Show("You have not yet made a choice. Please choose a score category.", "Invalid Selection");
                return;
            }
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
                labelHoldStatus3.Foreground = Brushes.Red;
            }
            else
            {
                labelHoldStatus3.Content = "Not Held";
                labelHoldStatus3.Foreground = Brushes.Black;
            }
        }
        private void buttonHoldDice4_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[3].ToggleDieState();
            if (game.diceArray[3].holdDieState == true)
            {
                labelHoldStatus4.Content = "Held";
                labelHoldStatus4.Foreground = Brushes.Red;
            }
            else
            {
                labelHoldStatus4.Content = "Not Held";
                labelHoldStatus4.Foreground = Brushes.Black;
            }
        }

        private void buttonHoldDice5_Click(object sender, RoutedEventArgs e)
        {
            game.diceArray[4].ToggleDieState();
            if (game.diceArray[4].holdDieState == true)
            {
                labelHoldStatus5.Content = "Held";
                labelHoldStatus5.Foreground = Brushes.Red;
            }
            else
            {
                labelHoldStatus5.Content = "Not Held";
                labelHoldStatus5.Foreground = Brushes.Black;
            }
        }

        private void clickButtonLogic(int index, bool upperOrLower) //false for upper, true for lower
        {
            if (upperOrLower)
                game.lockLowerValue(index);
            else
                game.lockUpperValue(index);
            game.turnEnd();
            buttonRollDice.Content = "     Roll\n(New Turn)";
            updateScoreGUI();
            checkGameOver();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yathzee, coded by Tanner Menzel, Greg Garner, and Zach Herbert.\nDice roll sound effect recorded by Mike Koenig", "About");
        }

        private void buttonAcesScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonAcesScore.IsEnabled = false;
            clickButtonLogic(0, false);
        }

        private void buttonTwosScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonTwosScore.IsEnabled = false;
            clickButtonLogic(1, false);
        }

        private void buttonThreesScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonThreesScore.IsEnabled = false;
            clickButtonLogic(2, false);
        }

        private void buttonFoursScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonFoursScore.IsEnabled = false;
            clickButtonLogic(3, false);
        }

        private void buttonFivesScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonFivesScore.IsEnabled = false;
            clickButtonLogic(4, false);
        }

        private void buttonSixesScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonSixesScore.IsEnabled = false;
            clickButtonLogic(5, false);
        }

        private void button3OfAKindScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            button3OfAKindScore.IsEnabled = false;
            clickButtonLogic(0, true);
        }

        private void button4OfAKindScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            button4OfAKindScore.IsEnabled = false;
            clickButtonLogic(1, true);
        }

        private void buttonFullHouseScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonFullHouseScore.IsEnabled = false;
            clickButtonLogic(2, true);
        }

        private void buttonSmallStrScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonSmallStrScore.IsEnabled = false;
            clickButtonLogic(3, true);
        }

        private void buttonLrgStrScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonLrgStrScore.IsEnabled = false;
            clickButtonLogic(4, true);
        }

        private void buttonYahtzeeScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonYahtzeeScore.IsEnabled = false;
            clickButtonLogic(5, true);

            game.yahtzeeAchieved();
            if (game.lowerValues[5] == 50)
            {
                game.yahtzeeBonusAvailible();
            }
        }

        private void buttonChanceScore_Click(object sender, RoutedEventArgs e)
        {
            if (game.preventButtonClick)
                return;
            buttonChanceScore.IsEnabled = false;
            clickButtonLogic(6, true);
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
