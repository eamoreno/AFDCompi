using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ERPolacaInversa.AFD;
using ERPolacaInversa.Arbol;
using Nodo = ERPolacaInversa.AFD.Nodo;

namespace ERPolacaInversa
{
	public partial class Form1 : Form
	{       
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
                var afd = new Afd(arbol);                            
                MuestraSigPos(arbol);
                PopulateTreeViewWithAfd(afd.GetGraph(), this.rTxtBPInversa.Text);
                PintaAfd(afd.GetGraph());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar arbol", "Compiladores e Interpretes A", MessageBoxButtons.OK);
            }
        }

	    private void PintaAfd(List<Nodo> afd)
	    {
            this.pictureBox1
	        var graphics = this.CreateGraphics();
            graphics.DrawEllipse(Pens.Blue,30,30,30,30);
	    }

	    private void PopulateTreeViewWithAfd(List<Nodo> afd, string erpi)
	    {
            if (afd != null)
            {
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
	}
}

