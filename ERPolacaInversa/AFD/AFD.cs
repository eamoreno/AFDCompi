using System;
using System.Collections.Generic;
using System.Linq;
using ERPolacaInversa.Arbol;

namespace ERPolacaInversa.AFD
{
    public class Afd
    {
        char _id = 'B';
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
            var nuevosEstados = new List<Nodo> { new Nodo { Arreglo = _arbol.PrimeraPos, Id = 'A', Type = NodoType.Inicio, Aristas = new List<Arista>() } };
            
            while (i < nuevosEstados.Count)
            {
                var nuevoEstado = nuevosEstados[i];
                var hojasX = HojasX(nuevoEstado);
                var list = ObtenListaDeMultiplicaciones(alfabeto, hojasX);
                var estadosSigPos = EstadosSigPos(list);
                nuevosEstados = nuevosEstados.Union(ObtenNuevosEstados(estadosSigPos, nuevosEstados, i)).ToList();
                i++;
            }
        }              

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

        private Hoja[] HojasX(Nodo nodoA)
        {
            var hojasA = (from h in _nodos
                          where h.GetType() == typeof(Hoja) && nodoA.Arreglo.Contains(((Hoja)h).Numero)
                          select (Hoja)h).ToArray();
            return hojasA;
        }        

        private IEnumerable<Nodo> ObtenNuevosEstados(IEnumerable<int[]> estadosSigPos, IEnumerable<Nodo> estadosX, int idActual)
        {
            var newEst = new List<Nodo>();
            var sigPos = estadosSigPos as int[][] ?? estadosSigPos.ToArray();
            var nuevosEstados = (from e in sigPos
                                 where !estadosX.SequenceContains(e) && e.Count() > 0
                                 select e).ToList();

            var nodos = estadosX as Nodo[] ?? estadosX.ToArray();
            var origen = nodos.ElementAt(idActual);

            CreaNodos(nuevosEstados, newEst);
            CreaAristas(sigPos, nodos, newEst, origen);
            return newEst;
        }

        private static void CreaAristas(IEnumerable<int[]> sigPos, IEnumerable<Nodo> nodos, IEnumerable<Nodo> newEst, Nodo origen)
        {
            var id = 'a';
            foreach (var nodo in sigPos.Select(destino => GetNodoFromArray(nodos.Union(newEst), destino)).
                Where(nodo => nodo != null))
            {
                origen.Aristas.Add(new Arista {Id = id++, Nodo = nodo});
            }
        }

        private void CreaNodos(IEnumerable<int[]> nuevosEstados, ICollection<Nodo> newEst)
        {
            foreach (var nodo in nuevosEstados.Where(nE => !newEst.SequenceContains(nE)).
                Select(nE => new Nodo {Arreglo = nE, Id = _id++, Type = NodoType.Estado, Aristas = new List<Arista>()}))
            {
                newEst.Add(nodo);
            }
        }

        private static Nodo GetNodoFromArray(IEnumerable<Nodo> estadosX, IEnumerable<int> destino)
        {
            var result = estadosX.FirstOrDefault(nodo => nodo.Arreglo.SequenceEqual(destino));
            return result;
        }
    }
}
