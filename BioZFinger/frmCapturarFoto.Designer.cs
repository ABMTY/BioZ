namespace BioZFinger
{
    partial class frmCapturarFoto
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
            this.pcbCamara = new System.Windows.Forms.PictureBox();
            this.cmbDispositivos = new System.Windows.Forms.ComboBox();
            this.btnGuardarFoto = new System.Windows.Forms.Button();
            this.lblCloseButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTituloForm = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCapturarFoto = new System.Windows.Forms.Button();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.pcbFotoRecortada = new System.Windows.Forms.PictureBox();
            this.btnActivarCamara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCamara)).BeginInit();
            this.pnlTituloForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotoRecortada)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbCamara
            // 
            this.pcbCamara.BackColor = System.Drawing.Color.AliceBlue;
            this.pcbCamara.Location = new System.Drawing.Point(12, 69);
            this.pcbCamara.Name = "pcbCamara";
            this.pcbCamara.Size = new System.Drawing.Size(482, 323);
            this.pcbCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCamara.TabIndex = 75;
            this.pcbCamara.TabStop = false;
            // 
            // cmbDispositivos
            // 
            this.cmbDispositivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDispositivos.FormattingEnabled = true;
            this.cmbDispositivos.Location = new System.Drawing.Point(13, 581);
            this.cmbDispositivos.Name = "cmbDispositivos";
            this.cmbDispositivos.Size = new System.Drawing.Size(244, 29);
            this.cmbDispositivos.TabIndex = 76;
            this.cmbDispositivos.Visible = false;
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnGuardarFoto.Enabled = false;
            this.btnGuardarFoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarFoto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarFoto.Location = new System.Drawing.Point(512, 268);
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(189, 39);
            this.btnGuardarFoto.TabIndex = 96;
            this.btnGuardarFoto.Text = "Guardar Foto";
            this.btnGuardarFoto.UseVisualStyleBackColor = false;
            this.btnGuardarFoto.Click += new System.EventHandler(this.btnGuardarFoto_Click);
            // 
            // lblCloseButton
            // 
            this.lblCloseButton.AutoSize = true;
            this.lblCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCloseButton.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseButton.ForeColor = System.Drawing.Color.White;
            this.lblCloseButton.Location = new System.Drawing.Point(668, 3);
            this.lblCloseButton.Name = "lblCloseButton";
            this.lblCloseButton.Size = new System.Drawing.Size(28, 25);
            this.lblCloseButton.TabIndex = 95;
            this.lblCloseButton.Text = "✕";
            this.lblCloseButton.Click += new System.EventHandler(this.lblCloseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "Capturar Foto";
            // 
            // pnlTituloForm
            // 
            this.pnlTituloForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTituloForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.pnlTituloForm.Controls.Add(this.lblCloseButton);
            this.pnlTituloForm.Controls.Add(this.label3);
            this.pnlTituloForm.Location = new System.Drawing.Point(4, 6);
            this.pnlTituloForm.Name = "pnlTituloForm";
            this.pnlTituloForm.Size = new System.Drawing.Size(698, 38);
            this.pnlTituloForm.TabIndex = 97;
            this.pnlTituloForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTituloForm_MouseDown);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(9, 49);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(40, 15);
            this.lblNombre.TabIndex = 98;
            this.lblNombre.Text = "label1";
            // 
            // btnCapturarFoto
            // 
            this.btnCapturarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnCapturarFoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturarFoto.ForeColor = System.Drawing.Color.White;
            this.btnCapturarFoto.Location = new System.Drawing.Point(512, 316);
            this.btnCapturarFoto.Name = "btnCapturarFoto";
            this.btnCapturarFoto.Size = new System.Drawing.Size(189, 39);
            this.btnCapturarFoto.TabIndex = 99;
            this.btnCapturarFoto.Text = "Capturar Foto";
            this.btnCapturarFoto.UseVisualStyleBackColor = false;
            this.btnCapturarFoto.Click += new System.EventHandler(this.btnCapturarFoto_Click);
            // 
            // pcbFoto
            // 
            this.pcbFoto.BackColor = System.Drawing.Color.AliceBlue;
            this.pcbFoto.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pcbFoto.InitialImage = null;
            this.pcbFoto.Location = new System.Drawing.Point(6, 69);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(500, 334);
            this.pcbFoto.TabIndex = 100;
            this.pcbFoto.TabStop = false;
            this.pcbFoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbFoto_MouseDown);
            this.pcbFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbFoto_MouseMove);
            this.pcbFoto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcbFoto_MouseUp);
            // 
            // pcbFotoRecortada
            // 
            this.pcbFotoRecortada.BackColor = System.Drawing.Color.AliceBlue;
            this.pcbFotoRecortada.Location = new System.Drawing.Point(512, 69);
            this.pcbFotoRecortada.Name = "pcbFotoRecortada";
            this.pcbFotoRecortada.Size = new System.Drawing.Size(189, 187);
            this.pcbFotoRecortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbFotoRecortada.TabIndex = 101;
            this.pcbFotoRecortada.TabStop = false;
            // 
            // btnActivarCamara
            // 
            this.btnActivarCamara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnActivarCamara.Enabled = false;
            this.btnActivarCamara.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivarCamara.ForeColor = System.Drawing.Color.White;
            this.btnActivarCamara.Location = new System.Drawing.Point(512, 364);
            this.btnActivarCamara.Name = "btnActivarCamara";
            this.btnActivarCamara.Size = new System.Drawing.Size(189, 39);
            this.btnActivarCamara.TabIndex = 102;
            this.btnActivarCamara.Text = "Activar Camara";
            this.btnActivarCamara.UseVisualStyleBackColor = false;
            this.btnActivarCamara.Click += new System.EventHandler(this.btnActivarCamara_Click);
            // 
            // frmCapturarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 411);
            this.Controls.Add(this.btnActivarCamara);
            this.Controls.Add(this.pcbFotoRecortada);
            this.Controls.Add(this.btnCapturarFoto);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnlTituloForm);
            this.Controls.Add(this.btnGuardarFoto);
            this.Controls.Add(this.cmbDispositivos);
            this.Controls.Add(this.pcbCamara);
            this.Controls.Add(this.pcbFoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCapturarFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCapturarFoto";
            this.Load += new System.EventHandler(this.frmCapturarFoto_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmCapturarFoto_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCamara)).EndInit();
            this.pnlTituloForm.ResumeLayout(false);
            this.pnlTituloForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotoRecortada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbCamara;
        private System.Windows.Forms.ComboBox cmbDispositivos;
        private System.Windows.Forms.Button btnGuardarFoto;
        private System.Windows.Forms.Label lblCloseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTituloForm;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCapturarFoto;
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.PictureBox pcbFotoRecortada;
        private System.Windows.Forms.Button btnActivarCamara;
    }
}