using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        bool isInit = false;


        public MainWindow()
        {
            InitializeComponent();
            if (!isInit) InitGame();
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

        private void randomTesting()
        {
            int die1total, die2total, die3total, die4total, die5total, die6total;
            die1total = die2total = die3total = die4total = die5total = die6total = 0;
            Dice tester = new Dice();
            for (int i = 0; i < 1000000; i++)
            {
                tester.Roll();
                switch (tester.diceValue)
                {
                    case 1:
                        die1total++;
                        break;
                    case 2:
                        die2total++;
                        break;
                    case 3:
                        die3total++;
                        break;
                    case 4:
                        die4total++;
                        break;
                    case 5:
                        die5total++;
                        break;
                    case 6:
                        die6total++;
                        break;
                }
            }
            Debug.WriteLine($"{die1total}, {die2total}, {die3total}, {die4total}, {die5total}, {die6total}");
        }

        private void InitGame()
        {
            for (int i = 0; i < diceArray.Length; i++)
               diceArray[i] = new Dice();
        }

        //Button Action to roll dice
        private void buttonRollDice_Click(object sender, RoutedEventArgs e)
        {
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


    }
}
