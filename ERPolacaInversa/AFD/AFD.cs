using System;
using System.Collections.Generic;
using System.Linq;
using ERPolacaInversa.Arbol;

namespace ERPolacaInversa.AFD
{
    public class Afd
    {

        private readonly Arbol.Nodo _arbol;
        private readonly List<Arbol.Nodo> _nodos = new List<Arbol.Nodo>();

        public Afd(Arbol.Arbol arbol)
        {
            _arbol = arbol.Cabeza;
            _nodos = arbol.GetNodos;
            Genera();
        }

        private void Genera()
        {
            var alfabeto = (from h in _nodos
                            where h.GetType() == typeof(Hoja) && h.Id != '#'
                            select h.Id).Distinct().ToArray();
            var i = 0;
            var nuevosEstados = new List<int[]> { _arbol.PrimeraPos };
            while (i < nuevosEstados.Count)
            {
                var nuevoEstado = nuevosEstados[i];
                var hojasX = HojasX(nuevoEstado);
                var list = ObtenListaDeMultiplicaciones(alfabeto, hojasX);
                var estadosSigPos = EstadosSigPos(list);
                nuevosEstados = nuevosEstados.Union(ObtenNuevosEstados(estadosSigPos, nuevosEstados)).ToList();
                i++;

                //CreaNodo(estadosSigPos, i);
               // var afd = new Nodo {Id = (char) (65 + 1), Aristas = estadosSigPos};

            }
        }

        //private void CreaNodo(IEnumerable<int[]> estadosSigPos, int i)
        //{

        //    foreach (var estsigpos in estadosSigPos)
        //    {
        //        var afd = new Arista { Id = (char)(65 + 1) };
        //    }             
        //}


        private IEnumerable<int[]> EstadosSigPos(IEnumerable<int[]> list)
        {
            var estadosSigPos = list.Select(arr => (from h in _nodos
                                                    where h.GetType() == typeof(Hoja) && arr.Contains(((Hoja)h).Numero)
                                                    select ((Hoja)h).SigPos).SelectMany(x => x).
                Distinct().OrderBy(x => x).ToArray()).ToList();
            return estadosSigPos;
        }

        private static IEnumerable<int[]> ObtenListaDeMultiplicaciones(char[] alfabeto, Hoja[] hojasA)
        {
            var list = alfabeto.Select(letra => (from e in hojasA
                                                 where e.Id == letra
                                                 select e.Numero).ToArray()).ToList();
            return list;
        }

        private Hoja[] HojasX(int[] A)
        {
            var hojasA = (from h in _nodos
                          where h.GetType() == typeof(Hoja) && A.Contains(((Hoja)h).Numero)
                          select (Hoja)h).ToArray();
            return hojasA;
        }

        private static IEnumerable<int[]> ObtenNuevosEstados(IEnumerable<int[]> estadosSigPos, IEnumerable<int[]> estadosX)
        {
            var newEst = new List<int[]>();
            var nuevosEstados = (from e in estadosSigPos
                                 where !estadosX.SequenceContains(e) && e.Count() > 0
                                 select e).ToList();

            foreach (var nE in nuevosEstados.Where(nE => !newEst.SequenceContains(nE)))
            {
                newEst.Add(nE);
            }
            return newEst;
        }
    }
}
