using BioZFinger.Utilities;
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
using EntBioZ.Modelo.Seguridad;

namespace BioZFinger
{
    public partial class frmAcceso : Form
    {
        CtrlUsuarios ctrlUsuarios = new CtrlUsuarios();
        public frmAcceso()
        {
            InitializeComponent();
        }

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTituloAcceso_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmAcceso_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccesar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarUsuario();
            }
            catch (Exception ex)
            {
                EtiquetaMensaje("No hay conexión con la Base de Datos",false);
            }
        }

        private void ValidarUsuario()
        {
            bool AccessoAutorizado = ObtenerUsuario(txtUsuario.Text, txtContaseña.Text);
            if (AccessoAutorizado)
            {
                frmListaEmpleados listaEmpleados = new frmListaEmpleados();
                listaEmpleados.Show();
                this.Hide();
            }
            else
            {
                EtiquetaMensaje("Usuario y/o Contreña Incorrecta!", false);
            }
        }

        private bool ObtenerUsuario(string Nombre, string Contraseña)
        {
            List<EntUsuario> listaUsuarios = new List<EntUsuario>();
            listaUsuarios = ctrlUsuarios.ObtenerTodos();
            bool Acceso = false;

            foreach (var entUsuario in listaUsuarios)
            {
                if (Nombre == entUsuario.usuario && Contraseña == entUsuario.password)
                {
                    Acceso = true;
                    break;
                }
            }

            return Acceso;
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
            {
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            }
            else
            {
                txtUsuario.Focus();
                lblStatus.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContaseña.Text = "";
            txtUsuario.Focus();
        }

        private void txtContaseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    ValidarUsuario();
                }
                catch (Exception ex)
                {
                    EtiquetaMensaje("No hay conexión con la Base de Datos", false);
                }
            }
        }
    }
}
