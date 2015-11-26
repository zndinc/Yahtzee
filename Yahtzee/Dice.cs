/*
Notes:

InitRandomRoll(Seed) and InitRandomRoll are redundant because of how C# handles random numbers. It's autoseeded using the clock, and each call to next produces a unique number.
Some methods were added or changed from the UML, and are noted with comments.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yahtzee
{
    class Dice : IComparable<Dice>
    {
        public int diceValue { get; private set; } //RollNumber on UML, name changed for clarity. 
        public bool isInitialized { get; private set; } = false; //Not on UML, added for constructor use in manually assigned dies.
        public bool holdDieState { get; private set; } = false;
        //public const int dieSides = 6; //const
        private static readonly Random rnd = new Random();


        public Dice(int value)
        {
            diceValue = value;
            isInitialized = true;
        }

        public Dice()
        {
            isInitialized = true;
        }

        public void Roll()
        {
            if (holdDieState)
                return;
            diceValue = rnd.Next(1, 7);
        }

        public void HoldDieState()
        {
            holdDieState = true;
        }

        public void ReleaseDieState() // Not on UML, added for clarity/ease of use.
        {
            holdDieState = false;
        }

        public void ToggleDieState() // Not on UML, added for clarity/ease of use.
        {
            holdDieState = !holdDieState;
        }

        #region Overrides
        public bool Equals(Dice other)
        {
            if (other == null || this == null)
                return false;
            
            if (this.diceValue == other.diceValue)
                return true;
            else return false;
        }

        public bool Equals(int other)
        {
            if (this == null)
                return false;

            if (this.diceValue == other)
                return true;
            else return false;
        }

        public static bool operator ==(Dice d1, Dice d2)
        {
            if (((object)d1) == null || ((object)d2) == null) //Prevents null comparisons 
                return Object.Equals(d1, d2);

            return d1.Equals(d2);
        }

        public static bool operator ==(Dice d1, int i1)
        {
            if (((object)d1) == null) //Prevents null comparisons 
                return Object.Equals(d1, i1);

            return d1.Equals(i1);
        }

        public static bool operator !=(Dice d1, int i1)
        {
            if (((object)d1) == null) //Prevents null comparisons 
                return ! Object.Equals(d1, i1);

            return !d1.Equals(i1);
        }

        public static bool operator !=(Dice d1, Dice d2)
        {
            if (((object)d1) == null || ((object)d2) == null) //Prevents null comparisons 
                return ! Object.Equals(d1, d2);

            return !d1.Equals(d2);
        }

        public override int GetHashCode()
        {
            return this.diceValue.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Dice die = obj as Dice;
            if (die == null)
                return false;
            else
                return Equals(die);
        }

        public static Dice operator +(Dice d1, Dice d2)
        {
            return new Dice(d1.diceValue + d2.diceValue);
        }

        public static Dice operator -(Dice d1, Dice d2)
        {
            return new Dice(d1.diceValue - d2.diceValue);
        }
        #endregion

        #region GUIStuff
        public void DrawDot()
        {
            throw new NotImplementedException("Draw Dot is not yet implemented.");
        }

        public void Draw1()
        {
            throw new NotImplementedException("Draw 1 is not yet implemented.");
        }

        public void Draw2()
        {
            throw new NotImplementedException("Draw 2 is not yet implemented.");
        }

        public void Draw3()
        {
            throw new NotImplementedException("Draw 3 is not yet implemented.");
        }

        public void Draw4()
        {
            throw new NotImplementedException("Draw 4 is not yet implemented.");
        }

        public void Draw5()
        {
            throw new NotImplementedException("Draw 5 is not yet implemented.");
        }

        public void Draw6()
        {
            throw new NotImplementedException("Draw 6 is not yet implemented.");
        }

        public int CompareTo(Dice other)
        {
            return this.diceValue.CompareTo(other.diceValue);
        }

        #endregion
    }
}
