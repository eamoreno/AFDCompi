using System;
using System.Windows.Forms;
using ERPolacaInversa.AFD;

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
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar arbol");
            }
        }

	}
}

