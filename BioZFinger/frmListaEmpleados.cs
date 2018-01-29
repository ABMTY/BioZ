using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using BioZFinger.Utilities;

namespace BioZFinger
{
    public partial class frmListaEmpleados : Form
    {
        CtrlEmpleados ctrlEmpleados = new CtrlEmpleados();
        public string Id_Empleado,Nombre_Empleado;
        private DataTable dtEmpleados;
        private DataView dvEmpleados;
        public frmListaEmpleados()
        {
            
            InitializeComponent();
            //ObtenerListaEmpleados();
        }

        private void frmListaEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarBotones(false);
                ObtenerListaEmpleados();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }
       
        private void dgvEmpleados_Click(object sender, EventArgs e)
        {
            Id_Empleado = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            Nombre_Empleado= dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            HabilitarBotones(true);
        }

        private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitarBotones(false);
                dvEmpleados.RowFilter = string.Format("Nombre LIKE '%{0}%' OR Departamento LIKE '%{0}%' OR Sucursal LIKE '%{0}%'", txtBuscarEmpleado.Text);
                dgvEmpleados.DataSource = dvEmpleados;
            }
            catch
            {

            }

        }

        private void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            Registro registroHuella = new Registro();
            registroHuella.Id_Empleado = Id_Empleado;
            registroHuella.Nombre_Empleado = Nombre_Empleado;
            registroHuella.Show();

        }
        
        private void btnCapturarFoto_Click(object sender, EventArgs e)
        {
            frmCapturarFoto frmCapturarFoto = new frmCapturarFoto();
            frmCapturarFoto.Nombre_Empleado = Nombre_Empleado;
            frmCapturarFoto.Id_Empleado = Id_Empleado;
            frmCapturarFoto.Show();
        }

        private void btnValidarHuella_Click(object sender, EventArgs e)
        {
            Validar valHuella = new Validar();
            valHuella.Id_Empleado = Id_Empleado;
            valHuella.Nombre_Empleado = Nombre_Empleado;
            valHuella.Show();
        }    

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAcceso frmAcceso = new frmAcceso();
            frmAcceso.Show();
        }

        private void LlenarGrid(List<EntEmpleado> Lista)
        {
            LimpiarGrid();
            dtEmpleados = new DataTable();
            dtEmpleados.Columns.Add("No.");
            dtEmpleados.Columns.Add("Nombre");
            dtEmpleados.Columns.Add("Departamento");
            dtEmpleados.Columns.Add("Sucursal");

            foreach (var item in Lista)
            {
                dtEmpleados.Rows.Add(item.id_empleado, item.nombre_completo, item.desc_departamento, item.desc_sucursal);
            }
            dvEmpleados = new DataView(dtEmpleados);

            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.DataSource = dvEmpleados;
            CambioPropiedadGridView(dgvEmpleados);
        }

        private void ObtenerListaEmpleados()
        {
            EtiquetaMensaje(string.Empty, true);
            List<EntEmpleado> ListaEmpleados = new List<EntEmpleado>();
            ListaEmpleados = ctrlEmpleados.ObtenerTodos();


            if (ListaEmpleados != null && ListaEmpleados.Count > 0)
            {
                LlenarGrid(ListaEmpleados);
            }
            else
                Mensaje("No Existe Empleados");
        }

        private void LimpiarGrid()
        {
            if (dgvEmpleados.Controls.Count > 2)
            { dgvEmpleados.Controls.RemoveAt(2); }


            dgvEmpleados.DataSource = null;
            dgvEmpleados.Controls.Clear();
            dgvEmpleados.Rows.Clear();
            dgvEmpleados.Columns.Clear();
        }

        private void Mensaje(string message)
        {
            if (dgvEmpleados.Controls.Count > 2)
            {
                dgvEmpleados.Controls.RemoveAt(2);
                EtiquetaMensaje(message, false);
            }
            else
            {
                EtiquetaMensaje("No hay conexión con la Base de Datos", false);
            }
        }

        public void MessageBoxShow(string mensaje, string tipomensaje)
        {
            MessageBox.Show(new Form() { TopMost = true }, mensaje, tipomensaje);
        }

        public void EtiquetaMensaje(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void HabilitarBotones(bool activo)
        {
            btnRegistrarHuella.Enabled = activo;
            btnCapturarFoto.Enabled = activo;
            //btnValidarHuella.Enabled = activo;        
        }

        private void pnlTituloForm_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmListaEmpleados_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(false);
            ObtenerListaEmpleados();
        }

        public static void CambioPropiedadGridView(DataGridView dgvEmpleados)
        {
            dgvEmpleados.Columns["No."].Width = 40;
            dgvEmpleados.Columns["Departamento"].Width = 200;
            dgvEmpleados.Columns["Sucursal"].Width = 200;

            dgvEmpleados.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.RowHeadersWidth = 10;
            dgvEmpleados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.RowTemplate.DefaultCellStyle.Padding = new Padding(5, 0, 10, 0);
            dgvEmpleados.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3C8DBC");
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvEmpleados.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn c in dgvEmpleados.Columns)
            {
                c.Resizable = DataGridViewTriState.False;
                c.ReadOnly = true;
            }
            dgvEmpleados.AllowUserToOrderColumns = true;
            dgvEmpleados.BackgroundColor = SystemColors.Control;
            dgvEmpleados.BorderStyle = BorderStyle.Fixed3D;
        }

    }
}
