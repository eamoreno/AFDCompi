using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPolacaInversa
{
    static public class Extensions
    {
        public static bool SequenceContains(this IEnumerable<int[]> sequence, int[] array)
        {
            return sequence.Any(arr => arr.SequenceEqual(array));
        }
    }
}
