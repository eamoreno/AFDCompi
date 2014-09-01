namespace ERPolacaInversa
{
    partial class FrmAFD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBAfd = new System.Windows.Forms.PictureBox();
            this.gBValidar = new System.Windows.Forms.GroupBox();
            this.lblIntCadena = new System.Windows.Forms.Label();
            this.txtBCadena = new System.Windows.Forms.TextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.gBAfd = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.gBtiempo = new System.Windows.Forms.GroupBox();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAfd)).BeginInit();
            this.gBValidar.SuspendLayout();
            this.gBAfd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.gBtiempo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pBAfd);
            this.panel1.Location = new System.Drawing.Point(6, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 592);
            this.panel1.TabIndex = 0;
            // 
            // pBAfd
            // 
            this.pBAfd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pBAfd.Location = new System.Drawing.Point(3, 3);
            this.pBAfd.Name = "pBAfd";
            this.pBAfd.Size = new System.Drawing.Size(953, 576);
            this.pBAfd.TabIndex = 0;
            this.pBAfd.TabStop = false;
            // 
            // gBValidar
            // 
            this.gBValidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gBValidar.Controls.Add(this.lblIntCadena);
            this.gBValidar.Controls.Add(this.txtBCadena);
            this.gBValidar.Controls.Add(this.btnValidar);
            this.gBValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBValidar.Location = new System.Drawing.Point(28, 37);
            this.gBValidar.Name = "gBValidar";
            this.gBValidar.Size = new System.Drawing.Size(233, 338);
            this.gBValidar.TabIndex = 1;
            this.gBValidar.TabStop = false;
            this.gBValidar.Text = "Cadena";
            // 
            // lblIntCadena
            // 
            this.lblIntCadena.AutoSize = true;
            this.lblIntCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntCadena.Location = new System.Drawing.Point(12, 76);
            this.lblIntCadena.Name = "lblIntCadena";
            this.lblIntCadena.Size = new System.Drawing.Size(210, 18);
            this.lblIntCadena.TabIndex = 2;
            this.lblIntCadena.Text = "Introduce Cadena a Validar";
            // 
            // txtBCadena
            // 
            this.txtBCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCadena.Location = new System.Drawing.Point(40, 140);
            this.txtBCadena.Name = "txtBCadena";
            this.txtBCadena.Size = new System.Drawing.Size(147, 24);
            this.txtBCadena.TabIndex = 1;
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(58, 215);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(107, 58);
            this.btnValidar.TabIndex = 0;
            this.btnValidar.Text = "Validar Cadena";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // gBAfd
            // 
            this.gBAfd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gBAfd.Controls.Add(this.panel1);
            this.gBAfd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBAfd.Location = new System.Drawing.Point(281, 37);
            this.gBAfd.Name = "gBAfd";
            this.gBAfd.Size = new System.Drawing.Size(974, 625);
            this.gBAfd.TabIndex = 2;
            this.gBAfd.TabStop = false;
            this.gBAfd.Text = "AFD";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(89, 624);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 38);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(61, 48);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(107, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // gBtiempo
            // 
            this.gBtiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gBtiempo.Controls.Add(this.txtTiempo);
            this.gBtiempo.Controls.Add(this.trackBar1);
            this.gBtiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBtiempo.Location = new System.Drawing.Point(28, 418);
            this.gBtiempo.Name = "gBtiempo";
            this.gBtiempo.Size = new System.Drawing.Size(233, 183);
            this.gBtiempo.TabIndex = 4;
            this.gBtiempo.TabStop = false;
            this.gBtiempo.Text = "Velocidad";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Enabled = false;
            this.txtTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempo.Location = new System.Drawing.Point(72, 111);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(79, 24);
            this.txtTiempo.TabIndex = 5;
            this.txtTiempo.Text = "0";
            this.txtTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmAFD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1261, 689);
            this.Controls.Add(this.gBtiempo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gBAfd);
            this.Controls.Add(this.gBValidar);
            this.Name = "FrmAFD";
            this.Text = "FrmAFD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAFD_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBAfd)).EndInit();
            this.gBValidar.ResumeLayout(false);
            this.gBValidar.PerformLayout();
            this.gBAfd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.gBtiempo.ResumeLayout(false);
            this.gBtiempo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pBAfd;
        private System.Windows.Forms.GroupBox gBValidar;
        private System.Windows.Forms.Label lblIntCadena;
        private System.Windows.Forms.TextBox txtBCadena;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.GroupBox gBAfd;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox gBtiempo;
        private System.Windows.Forms.TextBox txtTiempo;
    }
}