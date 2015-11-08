using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W02
{
    /// <summary>
    /// simple number game. produces a set of random int values.
    /// user must guess smallest and largest value. user wins if 
    /// both of the guessed values are correct.
    /// and 
    /// </summary>
    public class NumberGame
    {
        public int [] Slots { get; set; }
        protected int MinValue => Slots.Min();
        protected int MaxValue => Slots.Max();

        private const int MaxNumber = 1000;

        private Stopwatch StopWatch { get; set; }

        /// <summary>
        /// constructor for the number game
        /// </summary>
        /// <param name="slots">number of randomly generated int values</param>
        public NumberGame(int slots)
        {
            Slots = new int[slots];
            StopWatch = new Stopwatch();

            Initialize();
            StartGame();
        }

        /// <summary>
        /// shuffles the numbers
        /// </summary>
        protected void Initialize()
        {
            var r = new Random();
            for (var i = 0; i < Slots.Length; ++i)
            {
                var v = 0;
                do
                {
                    v = r.Next(MaxNumber);
                } while (Slots.Any(x => x == v));

                Slots[i] = v;
            }
        }


        /// <summary>
        /// starts the game (the stop watch)
        /// </summary>
        protected void StartGame()
        {
            StopWatch.Start();
        }

        /// <summary>
        /// make a guess and check if it is correct
        /// </summary>
        /// <param name="smallest">the guessed smallest value</param>
        /// <param name="largest">the guessed largest value</param>
        /// <param name="elapsedSeconds">the elapsed time since the game started</param>
        /// <returns>true if guess was correct</returns>
        public bool Guess(int smallest, int largest, out double elapsedSeconds)
        {
            elapsedSeconds = StopWatch.Elapsed.TotalSeconds;
            return smallest == MinValue && largest == MaxValue;
        }
    }
}
