using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPolacaInversa
{
    public class AFD
    {
        public static Nodo GeneraArbol(string expresionRegular)
        {
            int number = 1;
            var pila = new Stack<Nodo>();
            
            foreach(var c in expresionRegular)
            //Parallel.ForEach(expresionRegular, c =>
            {
                if (c != '#' && Form1.EsMetacaracter(c.ToString()))
                {
                    var op1 = pila.Pop();
                    Nodo op2 = null;
                    if (!EsUnario(c)) // es operador binario
                    {
                        op2 = pila.Pop();
                    }
                    var resultado = Resolver(c, op1, op2);
                    pila.Push(resultado);
                }
                else // operando ó token
                {
                    pila.Push(new Hoja { Id = c, Numero = number++ });
                }
            };

            /*var hojas = (from n in pila 
                         where n.EsAnulable 
                         select n);*/
           

            return pila.Pop();
        }

        public static Nodo Resolver(char operador, Nodo op1, Nodo op2 = null)
        {
            Nodo nodoOp;
            if (op2 == null || EsUnario(operador))
            {
                nodoOp = new Nodo { Id = operador, Izquierdo = op1 };
            }
            else
            {
                nodoOp = new Nodo { Id = operador, Derecho = op1, Izquierdo = op2 };
                op2.Padre = nodoOp;
            }
            op1.Padre = nodoOp;
            return nodoOp;
        }

        public static bool EsUnario(char operador)
        {
            return (operador == '+' || operador == '*' || operador == '?') ? true : false; 
        }

    }
}
