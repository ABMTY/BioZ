namespace BioZFinger
{
    partial class frmListaEmpleados
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
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRegistrarHuella = new System.Windows.Forms.Button();
            this.lblCloseButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTituloForm = new System.Windows.Forms.Panel();
            this.lblTituloBuscar = new System.Windows.Forms.Label();
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.btnValidarHuella = new System.Windows.Forms.Button();
            this.btnCapturarFoto = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.pnlTituloForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 67);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.Size = new System.Drawing.Size(1113, 462);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.Click += new System.EventHandler(this.dgvEmpleados_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 573);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(1135, 25);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "lblEstatus";
            // 
            // btnRegistrarHuella
            // 
            this.btnRegistrarHuella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnRegistrarHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarHuella.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarHuella.Location = new System.Drawing.Point(12, 535);
            this.btnRegistrarHuella.Name = "btnRegistrarHuella";
            this.btnRegistrarHuella.Size = new System.Drawing.Size(123, 33);
            this.btnRegistrarHuella.TabIndex = 9;
            this.btnRegistrarHuella.Text = "Registrar Huella";
            this.btnRegistrarHuella.UseVisualStyleBackColor = false;
            this.btnRegistrarHuella.Click += new System.EventHandler(this.btnRegistrarHuella_Click);
            // 
            // lblCloseButton
            // 
            this.lblCloseButton.AutoSize = true;
            this.lblCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCloseButton.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseButton.ForeColor = System.Drawing.Color.White;
            this.lblCloseButton.Location = new System.Drawing.Point(1078, 5);
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
            this.label3.Size = new System.Drawing.Size(141, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "Lista de Empleados";
            // 
            // pnlTituloForm
            // 
            this.pnlTituloForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTituloForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.pnlTituloForm.Controls.Add(this.lblTituloBuscar);
            this.pnlTituloForm.Controls.Add(this.txtBuscarEmpleado);
            this.pnlTituloForm.Controls.Add(this.lblCloseButton);
            this.pnlTituloForm.Controls.Add(this.label3);
            this.pnlTituloForm.Location = new System.Drawing.Point(12, 12);
            this.pnlTituloForm.Name = "pnlTituloForm";
            this.pnlTituloForm.Size = new System.Drawing.Size(1113, 38);
            this.pnlTituloForm.TabIndex = 92;
            this.pnlTituloForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTituloForm_MouseDown);
            // 
            // lblTituloBuscar
            // 
            this.lblTituloBuscar.AutoSize = true;
            this.lblTituloBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBuscar.ForeColor = System.Drawing.Color.White;
            this.lblTituloBuscar.Location = new System.Drawing.Point(695, 10);
            this.lblTituloBuscar.Name = "lblTituloBuscar";
            this.lblTituloBuscar.Size = new System.Drawing.Size(52, 17);
            this.lblTituloBuscar.TabIndex = 94;
            this.lblTituloBuscar.Text = "Buscar";
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(753, 9);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(274, 21);
            this.txtBuscarEmpleado.TabIndex = 95;
            this.txtBuscarEmpleado.TextChanged += new System.EventHandler(this.txtBuscarEmpleado_TextChanged);
            // 
            // btnValidarHuella
            // 
            this.btnValidarHuella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnValidarHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarHuella.ForeColor = System.Drawing.Color.White;
            this.btnValidarHuella.Location = new System.Drawing.Point(255, 535);
            this.btnValidarHuella.Name = "btnValidarHuella";
            this.btnValidarHuella.Size = new System.Drawing.Size(117, 33);
            this.btnValidarHuella.TabIndex = 93;
            this.btnValidarHuella.Text = "Validar Huella";
            this.btnValidarHuella.UseVisualStyleBackColor = false;
            this.btnValidarHuella.Click += new System.EventHandler(this.btnValidarHuella_Click);
            // 
            // btnCapturarFoto
            // 
            this.btnCapturarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnCapturarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturarFoto.ForeColor = System.Drawing.Color.White;
            this.btnCapturarFoto.Location = new System.Drawing.Point(137, 535);
            this.btnCapturarFoto.Name = "btnCapturarFoto";
            this.btnCapturarFoto.Size = new System.Drawing.Size(117, 33);
            this.btnCapturarFoto.TabIndex = 94;
            this.btnCapturarFoto.Text = "Capturar Foto";
            this.btnCapturarFoto.UseVisualStyleBackColor = false;
            this.btnCapturarFoto.Click += new System.EventHandler(this.btnCapturarFoto_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(378, 535);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(117, 33);
            this.btnRefrescar.TabIndex = 95;
            this.btnRefrescar.Text = "Actualizar Lista";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // frmListaEmpleados
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1135, 598);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnCapturarFoto);
            this.Controls.Add(this.btnValidarHuella);
            this.Controls.Add(this.pnlTituloForm);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRegistrarHuella);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Empleados";
            this.Load += new System.EventHandler(this.frmListaEmpleados_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmListaEmpleados_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.pnlTituloForm.ResumeLayout(false);
            this.pnlTituloForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRegistrarHuella;
        private System.Windows.Forms.Label lblCloseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTituloForm;
        private System.Windows.Forms.Button btnValidarHuella;
        private System.Windows.Forms.Label lblTituloBuscar;
        private System.Windows.Forms.TextBox txtBuscarEmpleado;
        private System.Windows.Forms.Button btnCapturarFoto;
        private System.Windows.Forms.Button btnRefrescar;
    }
}