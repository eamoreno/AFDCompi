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

        public static bool SequenceContains(this IEnumerable<AFD.Nodo> sequence, AFD.Nodo nodo)
        {
            return sequence.Any(arr => arr.Arreglo.SequenceEqual(nodo.Arreglo));
        }

        public static bool SequenceContains(this IEnumerable<int[]> sequence, AFD.Nodo nodo)
        {
            return sequence.Any(arr => arr.SequenceEqual(nodo.Arreglo));
        }

        public static bool SequenceContains(this IEnumerable<AFD.Nodo> sequence, int[] array)
        {
            return sequence.Any(arr => arr.Arreglo.SequenceEqual(array));
        }
    }
}
