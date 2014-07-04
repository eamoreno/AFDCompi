namespace ERPolacaInversa.Arbol
{
    /*Clase generada para crear los nodos del arbol*/
    public class Nodo
    {
        public char Id { get; set; }
        public bool EsAnulable { get; set; }

        public Nodo Padre { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public int[] PrimeraPos { get; set; }
        public int[] UltimaPos { get; set; }
    }
}
