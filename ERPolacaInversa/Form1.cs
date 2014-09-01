using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows.Forms;
using ERPolacaInversa.AFD;
using ERPolacaInversa.Arbol;
using Nodo = ERPolacaInversa.AFD.Nodo;

namespace ERPolacaInversa
{
	public partial class Form1 : Form
	{
	    private Bitmap dibujo;
        private Font fuente = new Font("Arial", 18);
        private Font fuente2 = new Font("Arial", 9);
        private Brush coloranul = new SolidBrush(Color.Black);
        private Brush colorprimpos = new SolidBrush(Color.Red);
        private Brush colorultipos = new SolidBrush(Color.Purple);
        private Brush relleno = new SolidBrush(Color.Chartreuse);
        private Pen pincel = new Pen(Color.Blue, 2);
        private Pen lapiz = new Pen(Color.Cyan, 2);

	    private List<Nodo> GrafoNodos;

		public Form1()
		{
			InitializeComponent();
		}
		
        private void btnConvertir_Click(object sender, EventArgs e)
        {
            var re = new RegularExpression();
            var cadena = rTxtBNInfija.Text;
            if (cadena != string.Empty)
                cadena = re.Normaliza(cadena);
            else
                MessageBox.Show("Introduce Cadena Valida", "Compiladores e Interpretes A", MessageBoxButtons.OK);

            rTxtBNormalizada.Text = cadena + ".#" ;
            rTxtBPInversa.Text = rTxtBNormalizada.Text == "ERROR" ? "ERROR" : RegularExpression.PolacaInv(cadena) + "#.";
            this.btnArbol.Enabled = true;
        }

        private void btnArbol_Click(object sender, EventArgs e)
        {            
            try
            {
                var arbol  = new Arbol.Arbol(this.rTxtBPInversa.Text);                
                var afd = new AFD.Afd(arbol);
                GrafoNodos = afd.GetGraph();

                MuestraSigPos(arbol);
                PopulateTreeViewWithAfd(GrafoNodos, this.rTxtBPInversa.Text);
                LlenaArbol(arbol.Cabeza);
                //PintaAfd(afd.GetGraph());
                this.btnAFD.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar arbol", "Compiladores e Interpretes A", MessageBoxButtons.OK);
            }
        }        
	    
        private void LlenaArbol(Arbol.Nodo cabeza)
        {

            if (ClientSize.Width > pBArbol.Width && ClientSize.Height > pBArbol.Height)
                dibujo = new Bitmap(ClientSize.Width, pBArbol.Height);
            else            
                dibujo = new Bitmap(pBArbol.Width, pBArbol.Height);
            
            Graphics g = Graphics.FromImage(dibujo);                        
            PintaArbol(cabeza, g);
            g.DrawImage(dibujo,0,0);
            pBArbol.Image = dibujo;
        }

        private void PintaArbol(Arbol.Nodo cabeza, Graphics dib)
        {
            if (cabeza == null)
                return;
            if (cabeza.Padre == null)
            {
                cabeza.X = (pBArbol.Width / 2) + 350;
                cabeza.Y = 30;
                cabeza.visitado = true;
            }
            if (cabeza.Padre != null)
            {
                if (cabeza.visitado != true)
                {
                    cabeza.X = cabeza.Padre.X - 75;
                    cabeza.Y = cabeza.Padre.Y + 50;
                    cabeza.visitado = true;
                }
                if (cabeza.Id == '#')                
                    cabeza.X = cabeza.Padre.X + 75;                                    
            }            
            PintaArbol(cabeza.Izquierdo, dib);
            if (cabeza.Derecho != null)
            {
                if (cabeza.Padre != null)
                {
                    cabeza.Derecho.X = cabeza.X + 75;
                    cabeza.Derecho.Y = cabeza.Y + 50;
                    cabeza.Derecho.visitado = true;
                }
                PintaArbol(cabeza.Derecho, dib);                                
            }           
            dibuja(cabeza, dib);
        }

        private void dibuja(Arbol.Nodo cabeza, Graphics dib)
	    {
            if (cabeza.Padre != null)
                dib.DrawLine(lapiz, cabeza.X + 20, cabeza.Y + 20, cabeza.Padre.X + 20, cabeza.Padre.Y + 20);
            dib.DrawEllipse(pincel, cabeza.X, cabeza.Y, 35, 35);
            dib.FillEllipse(relleno, cabeza.X, cabeza.Y, 34, 34);
            dib.DrawString(cabeza.Id.ToString(), fuente, coloranul, cabeza.X, cabeza.Y);
            dib.DrawString(cabeza.EsAnulable.ToString(), fuente2, coloranul, cabeza.X, cabeza.Y + 35);
            string pripos = DamePrimpos(cabeza);
            string ultpos = DameUltipos(cabeza);
            dib.DrawString(pripos, fuente2, colorprimpos, cabeza.X - 50, cabeza.Y + 10);
            dib.DrawString(ultpos, fuente2, colorultipos, cabeza.X + 38, cabeza.Y + 10);
	    }

	    private string DameUltipos(Arbol.Nodo cabeza)
	    {
            String cadena = "";
            int dato = 0;
            int inf = 0;

            for (int i = 0; i < cabeza.UltimaPos.GetLongLength(0); i++)
            {
                if (cadena == "")
                    cadena = cadena + "{" + cabeza.UltimaPos[i].ToString();
                else
                    cadena = cadena + "," + cabeza.UltimaPos[i].ToString();
                dato = i + 1;
                inf = (int)cabeza.UltimaPos.GetLongLength(0);
            }
            if (dato == 1 || dato == inf)
                cadena = cadena + "}";

            return cadena;
	    }

	    private string DamePrimpos(Arbol.Nodo cabeza)
	    {
	        String cadena = "";
	        int dato = 0;	        
            int inf =0;

	        for (int i=0; i < cabeza.PrimeraPos.GetLongLength(0); i++)
	        {
	            if (cadena == "")
	                cadena = cadena + "{" + cabeza.PrimeraPos[i].ToString();	   
	            else
	                cadena = cadena + "," + cabeza.PrimeraPos[i].ToString();
	            dato = i+1;
	            inf = (int) cabeza.PrimeraPos.GetLongLength(0);
	        }
	        if (dato == 1 || dato == inf )
	            cadena = cadena + "}";

	        return cadena;
	    }

	    private void PopulateTreeViewWithAfd(List<Nodo> afd, string erpi)
	    {
            if (afd != null)
            {
                tVAceptaciones.Nodes.Clear();               
                int inc= 0;
                this.tVAceptaciones.Nodes.Add("ER. Polaca Inversa");
                this.tVAceptaciones.Nodes[0].Nodes.Add(erpi);
                this.tVAceptaciones.Nodes.Add("ER. AFD");
                foreach (var listafd in afd)
                {                    
                    if (listafd.Type.ToString() == "Inicio")                                           
                        this.tVAceptaciones.Nodes[1].Nodes.Add(listafd.Id.ToString() + "  inicio");                     
                    else if (listafd.Type.ToString() == "Estado")                    
                        this.tVAceptaciones.Nodes[1].Nodes.Add(listafd.Id.ToString() + "  Estado");                    
                    else if (listafd.Type.ToString() == "Fin")                    
                        this.tVAceptaciones.Nodes[1].Nodes.Add(listafd.Id.ToString() + "  Fin-aceptacion");                    
                    for(int i = 0; i < listafd.Aristas.Count; i++)                                                    
                        this.tVAceptaciones.Nodes[1].Nodes[inc].Nodes.Add("con " + listafd.Aristas[i].Id.ToString() + " hacia " + listafd.Aristas[i].Nodo.Id.ToString());                    
                    inc++;
                }                                                
            }
	    }	    

	    private void MuestraSigPos(Arbol.Arbol arbol)
	    {
            this.dGVSigPos.Rows.Clear();
            this.dGVSigPos.DefaultCellStyle.Font = new Font("Tahoma", 11);
	        int i = 0;

            if (arbol != null)
	        {
                var hojas = (from h in arbol.GetNodos where h.GetType() == typeof(Hoja) select (Hoja)h).ToArray();
	            foreach (var pos in hojas)
	            {
	                string agrega = "";
	                for (int j = 0; j < pos.SigPos.Length; j++)
	                {
	                    if (j + 1 == pos.SigPos.Length)
	                        agrega += pos.SigPos[j].ToString();
	                    else
	                        agrega += pos.SigPos[j].ToString() + " ,";
	                }
	                this.dGVSigPos.Rows.Add(pos.Numero.ToString(), agrega);
	            }
	        }
	    }

        private void btnAFD_Click(object sender, EventArgs e)
        {
            FrmAFD pinta = new FrmAFD();
            pinta.AfdNodos = GrafoNodos;
            pinta.ShowDialog();
        }
	}
}

