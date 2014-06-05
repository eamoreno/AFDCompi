using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ERPolacaInversa
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnEjecutarP.Enabled = false;
            this.dtGVPruebas.Columns[0].Width = 175;
            this.dtGVPruebas.Columns[1].Width = 175;
            this.dtGVPruebas.Columns[2].Width = 175;
            this.dtGVPruebas.Columns[3].Width = 90;
            this.dtGVPruebas.DefaultCellStyle.Font = new Font("Tahoma", 11);
        }
        
        private void lblNInfija_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            bool band = true;

            String cadena = this.rTxtBNInfija.Text;
            if(cadena != "")
                band = normaliza(ref cadena);
            else
                MessageBox.Show("Introduce Cadena Valida", "Compiladores e Interpretes A", MessageBoxButtons.OK);

            if (!band)
                this.rTxtBNormalizada.Text = "ERROR";
            else
                this.rTxtBNormalizada.Text = cadena + ".#";


            if (this.rTxtBNormalizada.Text == "ERROR")
                this.rTxtBPInversa.Text = "ERROR";
            else
            {
                polacaInv(ref cadena);                      //Realiza las operaciones de Notacion Polaca Inversa
                cadena += "#.";
                this.rTxtBPInversa.Text = cadena;
                this.btnArbol.Enabled = true;
            }
        }

        private void haztarea(ref String cadena)
        {
            bool band = true;            

            band = normaliza(ref cadena);
            if (!band)
                cadena = "ERROR";
            else                   
                polacaInv(ref cadena);                      //Realiza las operaciones de Notacion Polaca Inversa Para DataG                           
        }        

        private bool normaliza(ref String cadena)
        {
            bool band = true;
            String cadaux = cadena;
            bool banpre = false;

            banpre = preproMeta(ref cadaux);

            if (verificalogicas(cadaux))
            {
                Concatenalternativa(ref cadaux, banpre);
                if (cadaux.Contains("ERROR"))
                {
                    cadaux = "ERROR";
                }
            }
            else
                cadaux = "ERROR";

            cadena = cadaux;
            return band;
        }

        private bool verificalogicas(String cadena)
        {
            bool band = true;
            int parbre=0, parcierra=0,corchabre=0, corchcierra=0;
            int parbres = 0, parcierras = 0, corchabres = 0, corchcierras = 0;
            String ini = cadena.Substring(0, 1);
            String dato = "";
            bool bandabre = false;
            int incremento = 0, detuviste=0;

            for (int i = 0; i < cadena.Length; i++)
            {
                incremento++;
                dato = cadena[i].ToString();
                if (dato == "\\")
                {
                    bandabre = true;
                    detuviste = incremento;
                }
                else
                    if (bandabre && (dato == "[" || dato == "]" || dato == "(" || dato == ")") &&  (incremento == detuviste + 1))
                    {
                        switch (dato)
                        {
                            case "[" :
                                        corchabres++;
                                break;
                            case "]":   
                                        corchcierras++;
                                break;
                            case "(":
                                        parbres++;
                                break;
                            case ")":
                                        parcierras++;
                                break;
                        }                       
                    }                    
                    else
                        if (bandabre && escaracterval2(dato) && (incremento == detuviste + 1))
                        {
                            band = false;
                            break;
                        }
            }

            if (ini == "+" || ini == "*" || ini == "?" || ini == "|" || ini == "-" || ini == ")" || ini == "]")
                {
                    band = false;                    
                }
            if (cadena == "()" || cadena == "[]" || cadena == "(" || cadena == ")" || cadena == "[" || cadena == "]")
                band = false;            

            parbre = cuantosdeestetiene(cadena,"(");
            parcierra = cuantosdeestetiene(cadena, ")");
            corchabre = cuantosdeestetiene(cadena, "[");
            corchcierra = cuantosdeestetiene(cadena, "`]");

          
            if(((parbre - parbres)!= (parcierra - parcierras)) || ((corchabre -corchabres) != (corchcierra - corchcierras)))
            {
               band = false;
            }

            if (!hayjuntos(cadena, "(", ")") || !hayjuntos(cadena, "[", "]"))
                band = false;

            if (!checapre(cadena, "(", ")") || !checapre(cadena, "[","]"))
                band = false;

            return band;
        }

        private bool checapre(String cadena, String datoini, String datofin)
        {
            bool band = true;
            String caracter = "";
            String atras = "";            
            int inc = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                caracter = cadena[i].ToString();
                if (i != 0)
                    atras = cadena[i - 1].ToString();

                if (caracter == datofin)
                {
                    if (i != 0)
                    {
                        if (inc == 0 && atras != "\\")
                        {
                            band = false;
                            break;
                        }
                        else
                        {
                            inc--;
                        }
                    }                                        
                }
                else
                    if (caracter == datoini)
                    {
                        inc++;
                    }
            }
            return band;
        }

        private bool hayjuntos(String cadena, String datoini, String datofin)
        {
            bool band = true;
            String caracter = "";
            String atras = "";

            for (int i = 0; i < cadena.Length; i++)
            {
                caracter = cadena[i].ToString();
                if (i != 0)
                    atras = cadena[i - 1].ToString();

                if (caracter == datofin && atras == datoini)
                    band = false;
            }
            return band;
        }

        private void polacaInv(ref String cadena)
        {
            Stack<char> pila = new Stack<char>();
            String cadact = "";
            pila.Push('#');
            cadena += '#';
            char dato;
            bool band = true;
            int i = 0;

            while (band)
            {
                dato = cadena[i];
                if (dato == '#')
                {
                    if (pila.Peek() == '(')
                    {
                        cadact = "ERROR";
                        band = false;
                    }
                    else if ((pila.Peek() == '#'))
                    {
                        band = false;
                    }
                    else
                        cadact += pila.Pop();
                }
                else
                    if (dato == '.')
                    {
                        if (pila.Peek() == '*' || pila.Peek() == '+' || pila.Peek() == '?' || pila.Peek() == '.')
                            cadact += pila.Pop();
                        else
                            pila.Push(cadena[i++]);
                    }
                    else
                        if (dato == '+' || dato == '?' || dato == '*')
                        {
                            if (pila.Peek() == '*' || pila.Peek() == '+' || pila.Peek() == '?')
                                cadact += pila.Pop();
                            else
                                pila.Push(cadena[i++]);
                        }
                        else
                            if (dato == '|')
                            {
                                if (pila.Peek() == '*' || pila.Peek() == '+' || pila.Peek() == '?' || pila.Peek() == '.' || pila.Peek() == '|')
                                    cadact += pila.Pop();
                                else
                                    pila.Push(cadena[i++]);
                            }
                            else
                                if (dato == '(')
                                {
                                    pila.Push(cadena[i++]);
                                }
                                else
                                    if (dato == ')')
                                    {
                                        if (pila.Peek() == '#')
                                        {
                                            cadact = "ERROR";
                                            band = false;
                                        }
                                        else
                                            if (pila.Peek() == '(')
                                            {
                                                pila.Pop();
                                                i++;
                                            }
                                            else
                                                cadact += pila.Pop();
                                    }
                                    else
                                    {
                                        cadact += cadena[i];
                                        i++;
                                        if (dato == '\\')
                                        {
                                            cadact += cadena[i++];
                                        }
                                    }

            }
            cadena = cadact;
        }       
       
        private bool Concatenalternativa(ref String cadena, bool bandprepro)
        {
            bool band = true;
            bool bandfunc = false;
            bool banhabilita=false;
            bool bandentro = false;
            string cadaux="";
            int tam = cadena.Length;
            int posini = 0, posfin=0;
            String partcad ="";
            String atras = "";
            bool bandnohicenad = false;

            for (int i = 0; i < tam; i++)
            {
                String caracter = cadena[i].ToString();
                if(i!=0)
                    atras = cadena[i-1].ToString();

                if (i > 0 && (caracter == "[" && atras != "|" && atras != "(" && atras != "[" && atras != "-" && atras != "\\"))
                {
                    posini = i;
                    cadaux += '.';
                    //cadaux += caracter;
                    bandfunc = true;
                }
                else
                    if (tam -1 == i && caracter == "|")
                    {
                        cadaux = "ERROR";
                        break;
                    }
                    else
                        if (i == 1 && (atras == "(" || atras == "[") && (caracter == "*" || caracter == "+" || caracter == "|" || caracter == "-"))
                        {                          
                            cadaux = "ERROR";
                            break;
                        }
                        else
                            if ((caracter == "|" && atras == "|") || (caracter == "." && atras == "\\" && !bandprepro) || (caracter == "-" && atras != "\\" && !bandfunc) || (caracter == ")" && atras == "|") || (atras == "|" && (caracter == "*" || caracter == "+" || caracter == "?")))
                            {
                                cadaux = "ERROR";
                                break;
                            }
                            else
                                if (caracter.Contains('[') && atras != "\\")
                                {                                    
                                        posini = i;
                                        bandfunc = true;                                                                                                               
                                }
                                else
                                    if (caracter.Contains(']') && bandfunc)
                                    {
                                        posfin = i;
                                        bandfunc = false;
                                        banhabilita = true;
                                    }
                                    else
                                        if (!bandfunc && i > 0 && atras != "(" && atras != "\\" && atras != "[" && atras != "|" && atras != "-" && (escaracterval(caracter) || caracter == "\\" || caracter == "[" || caracter == "("))
                                        {
                                            cadaux += '.';
                                            cadaux += caracter;
                                            if (caracter == "\\")
                                            {                                                
                                                i++;
                                                cadaux += cadena[i];
                                                if ("-" == cadena[i].ToString())
                                                {
                                                    cadaux += ".";
                                                }
                                            }
                                        }
                                        else
                                            if (atras == "\\" && caracter == "(")
                                            {
                                                cadaux += caracter + ".";
                                            }
                                            else
                                                bandnohicenad = true;
                 
                if (banhabilita)
                {
                    bandentro = true;
                    partcad = cadena.Substring(posini, posfin - posini + 1);
                    if (partcad != "[]")
                    {
                        hazAlternativas(ref partcad);                        
                    }
                    else
                    {
                        cadaux = "ERROR";
                        break;
                    }
                }                                

                if (bandnohicenad && !bandfunc)
                {
                    cadaux += caracter;
                }

                if (bandentro)
                {
                    cadaux += partcad;
                    bandentro = false;
                }

                banhabilita = false;
                bandnohicenad = false;
            }
            cadena = cadaux;

            return band;
        }

        private void hazAlternativas(ref String cadena)
        {                        
            String cadaux = "";
            bool banera=false;
            bool bandmeta = false;
            bool bandvermeta= true;
            int ubicacion = 0, sabermeta=0, tam= cadena.Length;
            String pos="";                           
            
            for (int i = 0; i < cadena.Length ; i++)
            {
                ubicacion++;
                pos = cadena[i].ToString();

                if (pos == "[")         //si es parentesis que abre
                {
                    cadaux+="(";
                    banera = true;
                }
                else
                    if (pos == "]" && banera)       //si es parentesis que cierra
                    {
                        quitaultimo(ref cadaux);
                        cadaux += ")";
                        banera = false;
                    }
                    else
                        if ((pos == "\\") && (ubicacion == (cadena.Length)-1))      //Para verificar que el ultimo dato no sea un dato de  estos/ 
                        {
                            cadaux = "ERROR";
                            break;
                        }
                        else
                            if (bandmeta && (!contienecaracter(pos)))       //Si despues de un / no le sigue un metacaracter entonces es mala la expresion regular
                            {
                                cadaux = "ERROR";
                                break;
                            }
                            else
                                if (pos == "\\" && bandvermeta)         //si es el inico de un metacaracter
                                {
                                    bandmeta = true;
                                    sabermeta = i;
                                }
                                else
                                    if ((sabermeta + 1 == i) && bandmeta && (i != tam - 1) && (pos == "*" || pos == "+" || pos == "?" || pos == "." || pos == ")" || pos == "(" || pos == "[" || pos == "]" || pos == "-" || pos == "|" || pos == "\\" || pos == "#"))
                                    {
                                        cadaux = cadaux + "\\" + pos + "|";            //si es metacaracter
                                        bandmeta = false;
                                    }
                                    else
                                        if (pos == "-" && banera)               //si tiene el -
                                        {
                                            int tamcad = cadena.Length;
                                            if ((ubicacion == 2) || (ubicacion == tamcad - 1))
                                            {
                                                cadaux = "ERROR";
                                                break;
                                            }
                                            if (ubicacion == 3)
                                            {
                                                for (int j = 0; j <= 1; j++)
                                                    quitaultimo(ref cadaux);
                                            }
                                            else
                                                if (ubicacion >= 4)
                                                {
                                                    for (int j = 0; j < 2; j++)
                                                        quitaultimo(ref cadaux);
                                                }
                                                else
                                                    if (ubicacion >= 4 && cuantosdeestetiene(cadena, pos) >= 2)
                                                    {
                                                        for (int j = 0; j < 3; j++)
                                                            quitaultimo(ref cadaux);
                                                    }
                                                    else
                                                        quitaultimo(ref cadaux);

                                            char rangoini = cadena[i - 1];
                                            char rangofin = cadena[i + 1];

                                            if (rangoini > rangofin)
                                            {
                                                while (rangofin != rangoini)
                                                {
                                                    /*cadaux = cadaux + rangoini + "|";   //SIRVE PARA IR DE REVERSA PERO NO ES VALIDO
                                                    rangoini--;*/
                                                    cadaux = "ERROR";
                                                    break;
                                                }
                                                break;
                                            }
                                            else
                                                if (rangoini < rangofin)
                                                {
                                                    while (rangoini != rangofin)
                                                    {
                                                        cadaux = cadaux + rangoini + "|";
                                                        rangoini++;
                                                    }
                                                }
                                        }
                                        else
                                            if (escaracterval(pos) && banera)        //si es algun metacaracter
                                            {
                                                cadaux = cadaux + pos + "|";
                                            }
                                            else
                                            {
                                                cadaux = "ERROR";
                                                break;
                                            }               
            }
            if (cadena == "[\\e]")
                cadaux = "\\e";
            if (cadena == "[a-c-g]")
                cadaux = "ERROR";
            cadena = cadaux;            
        }

        private int cuantosdeestetiene(String cadena, String dato)
        {
            int ret = 0;
            int tam = cadena.Length;
            String pos = "";

            for (int i = 0; i < tam; i++)
            {
                pos = cadena[i].ToString();
                if (dato.Contains(pos))
                    ret++;
            }
            return ret;
        }

        private void quitaultimo(ref String dato)
        {
            int tam = dato.Length;
            String cadena = "";
            cadena = dato.Substring(0, (tam-1));

            dato = cadena;
        }

        private bool escaracterval(String dato)
        {
            bool bandera = false;
            String cadena = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789=";
            if (cadena.Contains(dato))
                bandera = true;
            return bandera;
        }

        private bool escaracterval2(String dato)
        {
            bool bandera = false;
            String cadena = "abcdfghijklmñopqrsuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (cadena.Contains(dato))
                bandera = true;
            return bandera;
        }

        private bool contienecaracter(String dato)
        {
            bool bandera = false;
            String cadena = "*+?.)([]-|#";
            if (cadena.Contains(dato))
                bandera = true;
            return bandera;
        }

        public static bool EsMetacaracter(String dato)
        {
            bool bandera = false;

            if (dato == "*" || dato == "+" || dato == "?" || dato == "." || dato == ")" || dato == "(" || dato == "[" || dato == "]" || dato == "-" || dato == "|" || dato == "\\" || dato == "#")
                bandera = true;

            return bandera;
        }

        private bool preproMeta(ref String cadena)
        {
            String tempcad = "";
            bool bandera = false;
            int tam = cadena.Length;
            String atras;
               
            for (int i = 0; i < tam; i++)
            {                                                 
                char car=cadena[i];                
                   
                if (car == '.')
                {
                    if (i != 0)
                    {
                        atras = cadena[i - 1].ToString();                
                        if (atras == "\\")
                            bandera = false;
                        else
                            bandera = true;
                    }
                    else
                        if (i == 0)
                        
                            bandera = true;
                        
                    tempcad += "\\.";    
                }                
                else
                    if (car == ' ')
                    {
                        tempcad += "\\e";
                        bandera = true;
                    }
                    else
                        if (car == '\t')
                        {
                            tempcad += "\\t";
                            bandera = true;
                        }
                        else
                            tempcad += car;
            }
            cadena = tempcad;
            return bandera;
        }

        private bool AbrirGuarDoc(int opcion, ref String cadena)
        {
            bool bandera = false;

            if (opcion == 1)
            {
                this.GuardarDialogo.DefaultExt = "*.txt";
                this.GuardarDialogo.Filter = "Notacion Infija (*.txt)|*.txt";

                if (this.GuardarDialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.rTxtBNInfija.SaveFile(this.GuardarDialogo.FileName, RichTextBoxStreamType.PlainText);
                    bandera = true;
                }
                else
                    MessageBox.Show("No se Puede Guardar el Archivo", "Compiladores e Interpretes A", MessageBoxButtons.OK);
            }
            else if (opcion == 2)
            {
                this.abrirDialogo.DefaultExt = "*.txt";
                this.abrirDialogo.Filter = "Notacion Infija|*.txt";

                if (this.abrirDialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(cadena != "prueba")
                        this.rTxtBNInfija.LoadFile(this.abrirDialogo.FileName, RichTextBoxStreamType.PlainText);
                    else                    
                        cadena = abrirDialogo.FileName;
                    
                    bandera = true;                    
                }               
            }
            return bandera;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cad= "nada";
            AbrirGuarDoc(1,ref cad);          
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cad= "nada";
            if(AbrirGuarDoc(2,  ref cad) == false)                 
                 MessageBox.Show("No se Puede Abrir el Archivo", "Compiladores e Interpretes A", MessageBoxButtons.OK);
        }

        private void btnCargaP_Click(object sender, EventArgs e)
        {
            string cad= "prueba";
            if (AbrirGuarDoc(2,ref cad))
            {
                CargaPruebas(cad);
            }
            else
                MessageBox.Show("No se Puede Abrir el Archivo", "Compiladores e Interpretes A", MessageBoxButtons.OK);
        }        

        private void CargaPruebas(String cadena)
        {
            limpia();
            Char [] delimiesp = new Char[] { ' ', '\t' };

            if (cadena != "")
            {                
                StreamReader r = new StreamReader(cadena);
                String[] cadenas;
                String linea ="";

                while ((linea = r.ReadLine()) != null)
                {
                    if (linea != "")
                    {
                        cadenas = linea.Split(delimiesp, 2);
                        this.dtGVPruebas.Rows.Add(cadenas[0], cadenas[1]);
                    }                    
                }
            }
        }

        private void limpia()
        {
            this.dtGVPruebas.Rows.Clear();
            this.btnEjecutarP.Enabled = true;
        }

        private void btnEjecutarP_Click(object sender, EventArgs e)
        {
            int tam = this.dtGVPruebas.RowCount;
            String cadena = "";
            this.dtGVPruebas.DefaultCellStyle.Font = new Font("Tahoma", 11);
            int n=0;

            for(int i = 0; i < tam-1; i++)
            {
                cadena = this.dtGVPruebas[0, i].Value.ToString();
                haztarea(ref cadena);
                this.dtGVPruebas.Rows[i].Cells[2].Value = cadena;
                if (this.dtGVPruebas[2, i].Value.ToString() == this.dtGVPruebas[1, i].Value.ToString())
                {
                    this.dtGVPruebas.Rows[i].Cells[3].Value = "OK";                    
                    n++;
                }
                else
                    this.dtGVPruebas.Rows[i].Cells[3].Value = "FAIL";
            }
            //this.rTxtBPInversa.Text = n.ToString();
        }

        private void btnArbol_Click(object sender, EventArgs e)
        {
            try
            {
                var arbol = AFD.GeneraArbol(this.rTxtBPInversa.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el arbol");   
            }
        }
      
    }
}
