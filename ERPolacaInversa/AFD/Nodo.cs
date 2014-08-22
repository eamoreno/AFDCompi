using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPolacaInversa.AFD
{
    public enum NodoType
    {
        Inicio, Fin, Estado
    }
    public class Nodo
    {
        public char Id { get; set; }
        public int[] Arreglo { get; set; }
        public List<Arista> Aristas { get; set; } 
        public NodoType Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }        
    }
}
