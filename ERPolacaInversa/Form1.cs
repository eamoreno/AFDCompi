using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ERPolacaInversa.Properties;

namespace ERPolacaInversa
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
		}

		private void BtnConvertirClick(object sender, EventArgs e)
		{
			var re = new RegularExpression();
			var cadena = rTxtBNInfija.Text;
			if (cadena != string.Empty)
				cadena = re.Normaliza(cadena);
			else
				MessageBox.Show(Resources.Msg_Introduce_Cadena_Valida, Resources.Msg_Compiladores_e_Interpretes_A, MessageBoxButtons.OK);

			rTxtBNormalizada.Text = cadena;
			rTxtBPInversa.Text = rTxtBNormalizada.Text == Resources.Msg_ERROR ? Resources.Msg_ERROR : RegularExpression.PolacaInv(cadena);

			var rpn = Rpn.PolacaInversa(cadena);


		}

		private void BtnArbolClick(object sender, EventArgs e)
		{
			try
			{
				var arbol = AFD.GeneraArbol(this.rTxtBPInversa.Text);
			}
			catch (Exception)
			{
				MessageBox.Show(Resources.Msg_ErrorToGenerateArbol);   
			}
		}

	}
}
