using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ERPolacaInversa.AFD;
using ERPolacaInversa.Arbol;
using Nodo = ERPolacaInversa.AFD.Nodo;

namespace ERPolacaInversa
{
    public partial class FrmAFD : Form
    {
        public List<Nodo> AfdNodos { get; set; }
        private int xcen = 400;
        private int ycen = 300;
        private int longi = 200;
        private Bitmap dibujo;
        private int curva = 20;
        private int dista = 10;

        private Font fuente = new Font("Arial", 18);
        private Font fuente2 = new Font("Arial", 11);
        private Font fuente3 = new Font("Arial", 25);
        private Brush coloranul = new SolidBrush(Color.Black);
        private Brush colorprimpos = new SolidBrush(Color.Black);
        private Brush colorultipos = new SolidBrush(Color.Yellow);
        private Brush colorbl = new SolidBrush(Color.White);
        private Brush relleno = new SolidBrush(Color.Chartreuse);
        private readonly Pen pincel = new Pen(Color.Blue, 2);
        private readonly Pen pincelbl = new Pen(Color.White, 2);        
        private readonly Pen _plumaFlecha = new Pen(Color.Black, 3);
        private readonly Pen _plumaFlechaR = new Pen(Color.DarkRed, 3);
        private Graphics _graphics;

        public FrmAFD()
        {
            InitializeComponent();
        }

        private void FrmAFD_Load(object sender, EventArgs e)
        {
            inicia();
        }

        private void inicia()
        {            
            if (ClientSize.Width > pBAfd.Width && ClientSize.Height > pBAfd.Height)
                dibujo = new Bitmap(ClientSize.Width, pBAfd.Height);
            else
                dibujo = new Bitmap(pBAfd.Width, pBAfd.Height);

            _graphics = Graphics.FromImage(dibujo);
            PintaNodosAfd(_graphics);
            PintaAristasAfd(_graphics);
            _graphics.DrawImage(dibujo, 0, 0);
            pBAfd.Image = dibujo;                
        }        

        private void PintaNodosAfd(Graphics g)
        {
            if (AfdNodos == null)
                return;
            int teta = 360 / AfdNodos.Count;
            double opex = 0, opey = 0;
            double ope = 0;
            int xteta = 0, yteta = 0;            
            
            for (int i = 0; i < AfdNodos.Count; i++)
            {                
                ope = (double)((((teta*i)+teta)*(Math.PI)) / 180 );                
                opex = (Math.Cos(ope));
                opey = (Math.Sin(ope));
                xteta = (int)(xcen + ((longi) * (opex)));
                yteta = (int)(ycen - ((longi) * (opey)));
                AfdNodos[i].X = xteta;
                AfdNodos[i].Y = yteta;                
            }            
        }

        private void PintaAristasAfd(Graphics g)
        {
            if (AfdNodos == null)
                return;
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlecha.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlecha.CustomEndCap = finfle;
            int incurv = 0, inletr1 = 0, inletr2=0, inletr3=0, inletr4=0;
            int inletr1r = 0, inletr2r = 0, inletr3r = 0, inletr4r = 0;  
            string letcurv = "", letra1 = "", letra2="", letra3="", letra4="";
            string letra1r = "", letra2r = "", letra3r = "", letra4r = "";
            bool band1 = false, band2 = false, band3 = false, band4 = false;
            int tam = 0, tam2 = 0;
            int tamafue1=0, tamafue1a = 0;
            int tamafue2 = 0, tamafue2a = 0;
            int tamafue3 = 0, tamafue3a = 0;
            int tamafue4 = 0, tamafue4a = 0;

            for (int i = 0; i < AfdNodos.Count; i++)
            {
                for (int j = 0; j < AfdNodos[i].Aristas.Count; j++)
                {
                    //HazFlechas(AfdNodos[i], AfdNodos[i].Aristas[j].Nodo);
                    tam = ((AfdNodos[i].X) + (AfdNodos[i].Aristas[j].Nodo.X));
                    tam2 = ((AfdNodos[i].Y) + (AfdNodos[i].Aristas[j].Nodo.Y));

                    //c hacia adelante y hacia arriba 
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 5, AfdNodos[i].Aristas[j].Nodo.Y + 30);

                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)                            
                                if(AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)                            
                                    band1 = true;                            
                        }
                        if (band1)
                        {
                            if (letra1r == "")
                                letra1r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra1r = letra1r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr1r++;
                            }
                        }
                        else
                        {
                            if (letra1 == "")
                                letra1 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra1 = letra1 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr1++;
                            }
                        }
                        tamafue1 = tam;
                        tamafue1a = tam2;                                                
                    }
                    //c hacia atras y hacia arriba
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 30, AfdNodos[i].Aristas[j].Nodo.Y + 30);
                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)                            
                                if(AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)                                
                                    band2 = true;                            
                        }
                        if (band2)
                        {
                            if (letra2r == "")
                                letra2r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra2r = letra2r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr2r++;
                            }
                        }
                        else
                        {
                            if (letra2 == "")
                                letra2 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra2 = letra2 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr2++;
                            }
                        }
                        tamafue2 = tam;
                        tamafue2a = tam2;                                                                        
                    }
                    // 
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X  && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 5, AfdNodos[i].Aristas[j].Nodo.Y + 5);
                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)                            
                                if(AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)                            
                                    band3 = true;                            
                        }
                        if (band3)
                        {
                            if (letra3r == "")
                                letra3r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra3r = letra3r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr3r++;
                            }
                        }
                        else
                        {
                            if (letra3 == "")
                                letra3 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra3 = letra3 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr3++;
                            }
                        }
                        tamafue3 = tam;
                        tamafue3a = tam2;
                        
                        //g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    //
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X  && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 30, AfdNodos[i].Aristas[j].Nodo.Y + 5);

                        if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X + 1)
                        {
                            g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int) (tam/2),
                                (int) (tam2/2) + 30);
                        }
                        else
                        {
                            if (letra4 == "")
                                letra4 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra4 = letra4 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr4++;
                            }
                            tamafue4 = tam;
                            tamafue4a = tam2;
                        }
                        //g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    //Igualdades que casi no existen, posible omitir las en y
                    if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20,AfdNodos[i].Aristas[j].Nodo.X + 15, AfdNodos[i].Aristas[j].Nodo.Y + 30);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20,AfdNodos[i].Aristas[j].Nodo.X + 15, AfdNodos[i].Aristas[j].Nodo.Y);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y == AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X -5, AfdNodos[i].Aristas[j].Nodo.Y +15);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y == AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X +35, AfdNodos[i].Aristas[j].Nodo.Y + 15);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }

                    if (AfdNodos[i].Id.ToString() == AfdNodos[i].Aristas[j].Nodo.Id.ToString())
                    {                      
                        if(letcurv == "")
                            letcurv = AfdNodos[i].Aristas[j].Id.ToString() ;
                        else
                            letcurv = letcurv + "," + AfdNodos[i].Aristas[j].Id.ToString();
                        incurv++;                        
                    }

                    if (incurv != 0)
                    {
                        creaVuelta(AfdNodos[i], g, 1);
                        g.DrawString(letcurv, fuente2, coloranul, AfdNodos[i].X - (curva * 2) - 10, AfdNodos[i].Y - 23);
                    }

                    g.DrawString(letra1, fuente2, colorprimpos, (int)(tamafue1 / 2), (int)(tamafue1a / 2) + 30);
                    g.DrawString(letra2, fuente2, colorprimpos, (int)(tamafue2 / 2), (int)(tamafue2a / 2) + 30);
                    g.DrawString(letra3, fuente2, colorprimpos, (int)(tamafue3 / 2), (int)(tamafue3a / 2) + 30);
                    g.DrawString(letra4, fuente2, colorprimpos, (int)(tamafue4 / 2), (int)(tamafue4a / 2) + 30);
                    if (band1)
                        g.DrawString(letra1r, fuente2, colorprimpos, (int)(tamafue1 / 2), (int)(tamafue1a / 2) + 40);
                    if (band2)
                        g.DrawString(letra2r, fuente2, colorprimpos, (int)(tamafue2 / 2), (int)(tamafue2a / 2) + 40);
                    if (band3)
                        g.DrawString(letra3r, fuente2, colorprimpos, (int)(tamafue3 / 2), (int)(tamafue3a / 2) + 40);
                    if (band4)
                        g.DrawString(letra4r, fuente2, colorprimpos, (int)(tamafue4 / 2), (int)(tamafue4a / 2) + 40);                                                
                }

                band1 = false;
                band2 = false;
                band3 = false;
                band4 = false;                
                incurv = 0;
                inletr2=0;
                inletr1 = 0;
                inletr3 = 0;
                inletr4 = 0;
                letcurv = "";
                letra1 = "";
                letra2="";
                letra3="";
                letra4 = "";

                dibuja(AfdNodos[i], g);
            }
            _graphics.DrawRectangle(pincelbl, 20, 20, 51, 51);
            _graphics.FillRectangle(colorbl, 20, 20, 50, 50);
        }

        private void HazFlechas(Nodo afdNodo, Nodo nodo)
        {
            
        }

        private void creaVuelta(Nodo afdNodo, Graphics g, int op)
        {
            PointF p1 = new PointF(afdNodo.X, afdNodo.Y + 15);
            PointF p2 = new PointF(afdNodo.X - curva - 10, afdNodo.Y + 15 + curva);
            PointF p3 = new PointF((afdNodo.X - (curva * 3)), afdNodo.Y + 15);
            PointF p4 = new PointF(afdNodo.X - curva - 10, afdNodo.Y - 5);
            PointF p5 = new PointF(afdNodo.X, afdNodo.Y + 15);
            PointF[] arreglo = { p1, p2, p3, p4, p5 };
            g.DrawCurve(_plumaFlecha, arreglo);
            if(op == 2)
                g.DrawCurve(_plumaFlechaR, arreglo);
        }

        private void dibuja(Nodo afdNodo, Graphics dib)
        {
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlecha.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlecha.CustomEndCap = finfle;
            
            if(afdNodo.Type  == NodoType.Inicio)
            {               
                dib.DrawString(afdNodo.Type.ToString(), fuente, coloranul, afdNodo.X -20, afdNodo.Y-50);
                dib.DrawLine(_plumaFlecha, afdNodo.X+15, afdNodo.Y - 30, afdNodo.X+15, afdNodo.Y);
            }                               
            dib.DrawEllipse(pincel, afdNodo.X, afdNodo.Y, 36, 36);
            dib.FillEllipse(relleno, afdNodo.X, afdNodo.Y, 35, 35);
            dib.DrawString(afdNodo.Id.ToString(), fuente, coloranul, afdNodo.X+5, afdNodo.Y+5);
            if (afdNodo.Type == NodoType.Fin)
                dib.DrawEllipse(pincel, afdNodo.X+2, afdNodo.Y+2, 31, 31);                                               
        }        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.txtBCadena.Text == "")
                MessageBox.Show("Introduce Valores a la Cadena", "Compiladores e Interpretes A", MessageBoxButtons.OK);
            else                            
                validaCadena(txtBCadena.Text);            
        }

        private void validaCadena(string text)
        {
            if (text == null) 
                return;

            var ind = 1;
            var nodoIni = AfdNodos.First();
            foreach (var token in text)
            {
                var t = token;
                var arista = nodoIni.Aristas.FirstOrDefault(a => a.Id == t);
                if (arista != null)
                {
                    if (arista.Nodo.Type == NodoType.Fin && text.Length == ind)
                    {
                        PintaArista(nodoIni, arista.Nodo, arista);
                        Thread.Sleep(dameSeg(Convert.ToInt32(txtTiempo.Text)));
                        MessageBox.Show("Cadena valida");
                        PintaNodosAfd(_graphics);
                        PintaAristasAfd(_graphics);
                        pBAfd.Refresh();
                        Thread.Sleep(dameSeg(Convert.ToInt32(txtTiempo.Text)));                        
                        break;
                    }                    
                    PintaArista(nodoIni, arista.Nodo, arista);         
                    nodoIni = arista.Nodo;
                    ind++;                    
                    if (text.Length == ind-1)
                        MessageBox.Show("la Cadena no termino en un estado de aceptacion");
                    Thread.Sleep(dameSeg(Convert.ToInt32(txtTiempo.Text)));
                    PintaNodosAfd(_graphics);
                    PintaAristasAfd(_graphics);
                    pBAfd.Refresh();
                }
                else
                {
                    MessageBox.Show("el valor : " + token + " no es valido en la Cadena en la posicion: " + ind);
                    PintaNodosAfd(_graphics);
                    PintaAristasAfd(_graphics);
                    pBAfd.Refresh();
                    Thread.Sleep(dameSeg(Convert.ToInt32(txtTiempo.Text)));
                    break;
                }
            }            
        }        

        private void PintaArista(Nodo nodoIni, Nodo nodoEnd, Arista arista)
        {
            var nix = nodoIni.X;
            var niy = nodoIni.Y;
            var nfx = nodoEnd.X;
            var nfy = nodoEnd.Y;
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlechaR.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlechaR.CustomEndCap = finfle;

            if (nix < nfx && niy > nfy)                            
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 5, nfy + 30);            
            if (nix > nfx && niy > nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 30, nfy + 30);           
            if (nix < nfx && niy < nfy)                 
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 5, nfy + 5);            
            if (nix > nfx && niy < nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 30, nfy + 5);            
            if (nix == nfx && nix > nfy)
               _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 15, nfy + 30);            
            if (nix == nfx && niy < nfy)
               _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 15, nfy + 30);
            if (nix < nfx && niy == nfy)            
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx - 5, nfy + 15);                            
            if (nix > nfx && niy == nfy)            
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 35, nfy + 15);                            
            if(nix == nfx && niy == nfy)
                creaVuelta(nodoIni, _graphics,2);

            _graphics.DrawRectangle(pincel, 20, 20, 51, 51);
            _graphics.FillRectangle(colorultipos,20,20,50,50);
            _graphics.DrawString(arista.Id.ToString(), fuente3, coloranul, 25,25);

            pBAfd.Refresh();
        }
       
        private int dameSeg(int tiempo)
        {
            int seg = 0;
            switch (tiempo)
            {
                case 0 :
                    seg = 300;
                    break;
                case 1 :
                    seg = 300;
                    break;
                case 2:
                    seg = 400;
                    break;
                case 3:
                    seg = 400;
                    break;
                case 4:
                    seg = 500;
                    break;
                case 5:
                    seg = 600;
                    break;
                case 6:
                    seg = 700;
                    break;
                case 7:
                    seg = 800;
                    break;
                case 8:
                    seg = 900;
                    break;                                                            
                case 9:
                    seg = 900;
                    break;
                case 10:                    
                    seg = 1000;
                    break;
            }
            return seg;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtTiempo.Text = "" + trackBar1.Value.ToString();
        }
    }
}
