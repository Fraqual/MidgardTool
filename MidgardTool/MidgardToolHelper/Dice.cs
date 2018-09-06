using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardToolHelper
{
    public static class Dice
    {
        private static Random m_Random = new Random();

        public static int Roll(int sides)
        {
            return m_Random.Next(sides) + 1;
        }

        public static int[] RollMultiple(int sides, int rolls)
        {
            int[] results = new int[rolls];

            for(int i = 0; i < rolls; i++)
            {
                results[i] = m_Random.Next(sides) + 1;
            }

            return results;
        }

    }
}
