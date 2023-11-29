using Jfortnerd.Aod2k15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aod2k15.Dailies
{
    internal class Day01 : Jfortnerd.Aod2k15.Dailies.Day
    {
        public override void RunSolution()
        {
            int currentPosition = 1;
            int currentFloor = 0;
            char ascendFloor = '(';
            char descendFloor = ')';
            int basementFirstPosition = -1;

            foreach (char c in Sample)
            {
                if (c == ascendFloor)
                {
                    currentFloor++;
                }
                else if (c == descendFloor)
                {
                    currentFloor--;

                    // check if descend into basement
                    if (currentFloor < 0)
                    {
                        if (basementFirstPosition == -1)
                        {
                            basementFirstPosition = currentPosition;
                        }
                    }
                }

                currentPosition++;
            }

            // Part 1 of solution
            Solution = String.Concat(Solution, "The instructions take Santa to floor: " + currentFloor + "\n");

            Solution = String.Concat(Solution, "The position of the character that causes Santa to first enter the basement is position #: " + basementFirstPosition + "\n");

            Console.Write(Solution);
        }
    }
}
