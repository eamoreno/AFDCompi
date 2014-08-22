namespace ERPolacaInversa
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rTxtBNInfija = new System.Windows.Forms.RichTextBox();
            this.lblNInfija = new System.Windows.Forms.Label();
            this.lblNormailizada = new System.Windows.Forms.Label();
            this.rTxtBNormalizada = new System.Windows.Forms.RichTextBox();
            this.lblPInversa = new System.Windows.Forms.Label();
            this.rTxtBPInversa = new System.Windows.Forms.RichTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.abrirDialogo = new System.Windows.Forms.OpenFileDialog();
            this.GuardarDialogo = new System.Windows.Forms.SaveFileDialog();
            this.btnCargaP = new System.Windows.Forms.Button();
            this.btnEjecutarP = new System.Windows.Forms.Button();
            this.dtGVPruebas = new System.Windows.Forms.DataGridView();
            this.ER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBArbol = new System.Windows.Forms.PictureBox();
            this.ArbolGB = new System.Windows.Forms.GroupBox();
            this.btnArbol = new System.Windows.Forms.Button();
            this.Aceptacionesgb = new System.Windows.Forms.GroupBox();
            this.tVAceptaciones = new System.Windows.Forms.TreeView();
            this.sigposgb = new System.Windows.Forms.GroupBox();
            this.dGVSigPos = new System.Windows.Forms.DataGridView();
            this.Hoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SigPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAFD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPruebas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBArbol)).BeginInit();
            this.ArbolGB.SuspendLayout();
            this.Aceptacionesgb.SuspendLayout();
            this.sigposgb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSigPos)).BeginInit();
            this.SuspendLayout();
            // 
            // rTxtBNInfija
            // 
            this.rTxtBNInfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtBNInfija.Location = new System.Drawing.Point(187, 34);
            this.rTxtBNInfija.Name = "rTxtBNInfija";
            this.rTxtBNInfija.Size = new System.Drawing.Size(255, 25);
            this.rTxtBNInfija.TabIndex = 0;
            this.rTxtBNInfija.Text = "";
            // 
            // lblNInfija
            // 
            this.lblNInfija.AutoSize = true;
            this.lblNInfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNInfija.Location = new System.Drawing.Point(24, 34);
            this.lblNInfija.Name = "lblNInfija";
            this.lblNInfija.Size = new System.Drawing.Size(154, 18);
            this.lblNInfija.TabIndex = 1;
            this.lblNInfija.Text = "ER. Notacion Infija:";
            // 
            // lblNormailizada
            // 
            this.lblNormailizada.AutoSize = true;
            this.lblNormailizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormailizada.Location = new System.Drawing.Point(24, 79);
            this.lblNormailizada.Name = "lblNormailizada";
            this.lblNormailizada.Size = new System.Drawing.Size(141, 18);
            this.lblNormailizada.TabIndex = 3;
            this.lblNormailizada.Text = "ER. Normalizada:";
            // 
            // rTxtBNormalizada
            // 
            this.rTxtBNormalizada.Enabled = false;
            this.rTxtBNormalizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtBNormalizada.Location = new System.Drawing.Point(187, 79);
            this.rTxtBNormalizada.Name = "rTxtBNormalizada";
            this.rTxtBNormalizada.Size = new System.Drawing.Size(255, 25);
            this.rTxtBNormalizada.TabIndex = 2;
            this.rTxtBNormalizada.Text = "";
            // 
            // lblPInversa
            // 
            this.lblPInversa.AutoSize = true;
            this.lblPInversa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPInversa.Location = new System.Drawing.Point(24, 125);
            this.lblPInversa.Name = "lblPInversa";
            this.lblPInversa.Size = new System.Drawing.Size(157, 18);
            this.lblPInversa.TabIndex = 5;
            this.lblPInversa.Text = "ER. Polaca Inversa:";
            // 
            // rTxtBPInversa
            // 
            this.rTxtBPInversa.Enabled = false;
            this.rTxtBPInversa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtBPInversa.Location = new System.Drawing.Point(187, 125);
            this.rTxtBPInversa.Name = "rTxtBPInversa";
            this.rTxtBPInversa.Size = new System.Drawing.Size(255, 25);
            this.rTxtBPInversa.TabIndex = 4;
            this.rTxtBPInversa.Text = "";
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Location = new System.Drawing.Point(274, 626);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(102, 28);
            this.btnAbrir.TabIndex = 6;
            this.btnAbrir.Text = "Abir";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(371, 626);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 28);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            // 
            // btnConvertir
            // 
            this.btnConvertir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConvertir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertir.Location = new System.Drawing.Point(36, 184);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(102, 28);
            this.btnConvertir.TabIndex = 8;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = false;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // abrirDialogo
            // 
            this.abrirDialogo.FileName = "openFileDialog1";
            // 
            // btnCargaP
            // 
            this.btnCargaP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCargaP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaP.Location = new System.Drawing.Point(274, 647);
            this.btnCargaP.Name = "btnCargaP";
            this.btnCargaP.Size = new System.Drawing.Size(231, 33);
            this.btnCargaP.TabIndex = 9;
            this.btnCargaP.Text = "Carga Archivos de Pruebas";
            this.btnCargaP.UseVisualStyleBackColor = false;
            this.btnCargaP.Visible = false;
            // 
            // btnEjecutarP
            // 
            this.btnEjecutarP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEjecutarP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutarP.Location = new System.Drawing.Point(274, 621);
            this.btnEjecutarP.Name = "btnEjecutarP";
            this.btnEjecutarP.Size = new System.Drawing.Size(150, 33);
            this.btnEjecutarP.TabIndex = 10;
            this.btnEjecutarP.Text = "Ejecutar Pruebas";
            this.btnEjecutarP.UseVisualStyleBackColor = false;
            this.btnEjecutarP.Visible = false;
            // 
            // dtGVPruebas
            // 
            this.dtGVPruebas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPruebas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ER,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dtGVPruebas.Location = new System.Drawing.Point(274, 596);
            this.dtGVPruebas.Name = "dtGVPruebas";
            this.dtGVPruebas.Size = new System.Drawing.Size(220, 84);
            this.dtGVPruebas.TabIndex = 11;
            this.dtGVPruebas.Visible = false;
            // 
            // ER
            // 
            this.ER.HeaderText = "ER";
            this.ER.Name = "ER";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Resultado Esperado";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Resultado Obtenido";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estado de la Prueba";
            this.Column3.Name = "Column3";
            // 
            // pBArbol
            // 
            this.pBArbol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pBArbol.Location = new System.Drawing.Point(6, 21);
            this.pBArbol.Name = "pBArbol";
            this.pBArbol.Size = new System.Drawing.Size(740, 576);
            this.pBArbol.TabIndex = 12;
            this.pBArbol.TabStop = false;
            // 
            // ArbolGB
            // 
            this.ArbolGB.Controls.Add(this.pBArbol);
            this.ArbolGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArbolGB.Location = new System.Drawing.Point(511, 34);
            this.ArbolGB.Name = "ArbolGB";
            this.ArbolGB.Size = new System.Drawing.Size(758, 615);
            this.ArbolGB.TabIndex = 13;
            this.ArbolGB.TabStop = false;
            this.ArbolGB.Text = "Arbol";
            // 
            // btnArbol
            // 
            this.btnArbol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnArbol.Enabled = false;
            this.btnArbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArbol.Location = new System.Drawing.Point(187, 184);
            this.btnArbol.Name = "btnArbol";
            this.btnArbol.Size = new System.Drawing.Size(255, 28);
            this.btnArbol.TabIndex = 14;
            this.btnArbol.Text = "Genera Arbol";
            this.btnArbol.UseVisualStyleBackColor = false;
            this.btnArbol.Click += new System.EventHandler(this.btnArbol_Click);
            // 
            // Aceptacionesgb
            // 
            this.Aceptacionesgb.Controls.Add(this.tVAceptaciones);
            this.Aceptacionesgb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aceptacionesgb.Location = new System.Drawing.Point(12, 247);
            this.Aceptacionesgb.Name = "Aceptacionesgb";
            this.Aceptacionesgb.Size = new System.Drawing.Size(223, 407);
            this.Aceptacionesgb.TabIndex = 15;
            this.Aceptacionesgb.TabStop = false;
            this.Aceptacionesgb.Text = "Aceptaciones";
            // 
            // tVAceptaciones
            // 
            this.tVAceptaciones.Location = new System.Drawing.Point(15, 28);
            this.tVAceptaciones.Name = "tVAceptaciones";
            this.tVAceptaciones.Size = new System.Drawing.Size(196, 356);
            this.tVAceptaciones.TabIndex = 0;
            // 
            // sigposgb
            // 
            this.sigposgb.Controls.Add(this.dGVSigPos);
            this.sigposgb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigposgb.Location = new System.Drawing.Point(252, 247);
            this.sigposgb.Name = "sigposgb";
            this.sigposgb.Size = new System.Drawing.Size(242, 241);
            this.sigposgb.TabIndex = 16;
            this.sigposgb.TabStop = false;
            this.sigposgb.Text = "Sigpos";
            // 
            // dGVSigPos
            // 
            this.dGVSigPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSigPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hoja,
            this.SigPos});
            this.dGVSigPos.Location = new System.Drawing.Point(6, 28);
            this.dGVSigPos.Name = "dGVSigPos";
            this.dGVSigPos.Size = new System.Drawing.Size(230, 207);
            this.dGVSigPos.TabIndex = 0;
            // 
            // Hoja
            // 
            this.Hoja.FillWeight = 50F;
            this.Hoja.HeaderText = "Hoja";
            this.Hoja.Name = "Hoja";
            this.Hoja.Width = 50;
            // 
            // SigPos
            // 
            this.SigPos.HeaderText = "SigPos";
            this.SigPos.Name = "SigPos";
            this.SigPos.Width = 135;
            // 
            // btnAFD
            // 
            this.btnAFD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAFD.Enabled = false;
            this.btnAFD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAFD.Location = new System.Drawing.Point(274, 527);
            this.btnAFD.Name = "btnAFD";
            this.btnAFD.Size = new System.Drawing.Size(183, 38);
            this.btnAFD.TabIndex = 17;
            this.btnAFD.Text = "Muestra AFD";
            this.btnAFD.UseVisualStyleBackColor = false;
            this.btnAFD.Click += new System.EventHandler(this.btnAFD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 717);
            this.Controls.Add(this.btnAFD);
            this.Controls.Add(this.sigposgb);
            this.Controls.Add(this.Aceptacionesgb);
            this.Controls.Add(this.btnArbol);
            this.Controls.Add(this.ArbolGB);
            this.Controls.Add(this.dtGVPruebas);
            this.Controls.Add(this.btnEjecutarP);
            this.Controls.Add(this.btnCargaP);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblPInversa);
            this.Controls.Add(this.rTxtBPInversa);
            this.Controls.Add(this.lblNormailizada);
            this.Controls.Add(this.rTxtBNormalizada);
            this.Controls.Add(this.lblNInfija);
            this.Controls.Add(this.rTxtBNInfija);
            this.Name = "Form1";
            this.Text = "ER Polaca Inversa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPruebas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBArbol)).EndInit();
            this.ArbolGB.ResumeLayout(false);
            this.Aceptacionesgb.ResumeLayout(false);
            this.sigposgb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVSigPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtBNInfija;
        private System.Windows.Forms.Label lblNInfija;
        private System.Windows.Forms.Label lblNormailizada;
        private System.Windows.Forms.RichTextBox rTxtBNormalizada;
        private System.Windows.Forms.Label lblPInversa;
        private System.Windows.Forms.RichTextBox rTxtBPInversa;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.OpenFileDialog abrirDialogo;
        private System.Windows.Forms.SaveFileDialog GuardarDialogo;
        private System.Windows.Forms.Button btnCargaP;
        private System.Windows.Forms.Button btnEjecutarP;
        private System.Windows.Forms.DataGridView dtGVPruebas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.PictureBox pBArbol;
        private System.Windows.Forms.GroupBox ArbolGB;
        private System.Windows.Forms.Button btnArbol;
        private System.Windows.Forms.GroupBox Aceptacionesgb;
        private System.Windows.Forms.TreeView tVAceptaciones;
        private System.Windows.Forms.GroupBox sigposgb;
        private System.Windows.Forms.DataGridView dGVSigPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn SigPos;
        private System.Windows.Forms.Button btnAFD;
    }
}

