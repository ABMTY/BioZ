using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.IO;
using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using BioZFinger.Utilities;

namespace BioZFinger
{
    public partial class frmCapturarFoto : Form
    {

        // The original image.
        private Bitmap OriginalImage;
        // True when we're selecting a rectangle.
        private bool IsSelecting = false;
        // The area we are selecting.
        private int X0, Y0, X1, Y1;


        private FilterInfoCollection ListaDispositivos;
        private VideoCaptureDevice FrameFinal;
        CtrlEmpleados ctrlEmpleado = new CtrlEmpleados();
        private bool ExisteDispositivo = false;        

        public string Id_Empleado, Nombre_Empleado;
        public frmCapturarFoto()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        private void frmCapturarFoto_Load(object sender, EventArgs e)
        {
            //btnGuardarFoto.Enabled = false;
            //btnActivarCamara.Enabled = false;
            lblNombre.Text = Nombre_Empleado.ToString();
            
            // Cargamos los dispositivos de video
            ListaDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (ListaDispositivos.Count > 0)
            {
                // Y por cada dispositivo detectado, lo agregamos a un combobox (ahora ya no es visible para el usuario)
                foreach (FilterInfo Dispositivo in ListaDispositivos)
                {
                    cmbDispositivos.Items.Add(Dispositivo.Name);
                }
                // Seleccionamos el primer dispositivo
                cmbDispositivos.SelectedIndex = 0;
                // Inicializamos el dispositivo
                FrameFinal = new VideoCaptureDevice();

                // Y creamos el handler para comenzar a hacer el stream de video
                try
                {
                    FrameFinal = new VideoCaptureDevice(ListaDispositivos[cmbDispositivos.SelectedIndex].MonikerString);
                    FrameFinal.NewFrame += FrameFinal_NewFrame;

                    FrameFinal.Start();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
            else
            {
                frmListaEmpleados listaEmpleados = new frmListaEmpleados();
                listaEmpleados.MessageBoxShow("Conecte el Dispositivo","Alerta");
                this.Close();
            }

            //MessageBox.Show(Id_Empleado);
        }

        public void BuscarDispositivos()
        {
            ListaDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (ListaDispositivos.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(ListaDispositivos);

            }
        }

        void FrameFinal_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pcbCamara.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void lblCloseButton_Click(object sender, EventArgs e)
        {
            TerminarFuenteDeVideo();
            this.Close();
        }



        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++) ;

            cmbDispositivos.Items.Add(Dispositivos[0].Name.ToString());
            cmbDispositivos.Text = cmbDispositivos.Items[0].ToString();

        }

        private void btnGuardarFoto_Click(object sender, EventArgs e)
        {
            //Image imagenrec = CambiarTamanoImagen(pcbFoto.Image, 320, 300);
            // Este metodo guarda la plantilla ya generada satisfactoriamente a la base de datos
            try
            {
                EntEmpleado entEmpleado = ctrlEmpleado.Obtener(int.Parse(Id_Empleado));    
                ctrlEmpleado.Actualizar(new EntEmpleado
                {
                    id_empleado = entEmpleado.id_empleado,
                    nombre= entEmpleado.nombre,
                    ap_paterno = entEmpleado.ap_paterno,
                    ap_materno = entEmpleado.ap_materno,
                    id_departamento = entEmpleado.id_departamento,
                    id_sucursal = entEmpleado.id_sucursal,
                    enrollnumber = entEmpleado.enrollnumber,
                    imagen = ImageToBase64(pcbFotoRecortada.Image, System.Drawing.Imaging.ImageFormat.Png)
                });

                frmListaEmpleados listaEmpleado = new frmListaEmpleados();
                listaEmpleado.MessageBoxShow("Se registro la foto exitosamente!", "Guardar");

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void pcbFoto_MouseDown(object sender, MouseEventArgs e)
        {
            IsSelecting = true;

            // Save the start point.
            X0 = e.X;
            Y0 = e.Y;

            btnActivarCamara.Enabled = true;
        }
        public void TerminarFuenteDeVideo()
        {
            if (!(FrameFinal == null))
                if (FrameFinal.IsRunning)
                {
                    FrameFinal.SignalToStop();
                    FrameFinal = null;
                }

        }

        private void pcbFoto_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;

            // Save the new point.
            X1 = e.X;
            Y1 = e.Y;

            // Make a Bitmap to display the selection rectangle.
            Bitmap bm = new Bitmap(OriginalImage);

            // Draw the rectangle.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawRectangle(Pens.Red,
                    Math.Min(X0, X1), Math.Min(Y0, Y1),
                    Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
            }

            // Display the temporary bitmap.
            pcbFoto.Image = bm;
        }

        private void pcbFoto_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;
            IsSelecting = false;

            // Display the original image.
            pcbFoto.Image = OriginalImage;

            // Copy the selected part of the image.
            int wid = Math.Abs(X0 - X1);
            int hgt = Math.Abs(Y0 - Y1);
            if ((wid < 1) || (hgt < 1)) return;

            Bitmap area = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(area))
            {
                Rectangle source_rectangle =
                    new Rectangle(Math.Min(X0, X1), Math.Min(Y0, Y1), wid, hgt);
                Rectangle dest_rectangle =
                    new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(OriginalImage, dest_rectangle,
                    source_rectangle, GraphicsUnit.Pixel);
            }

            // Display the result.
            pcbFotoRecortada.Image = area;
        }        

        private void btnActivarCamara_Click(object sender, EventArgs e)
        {
            FrameFinal.Start();
            pcbCamara.Enabled = true;
            pcbCamara.Visible = true;
            pcbFoto.Visible = false;
            btnCapturarFoto.Enabled = true;
            btnActivarCamara.Enabled = false;
            btnGuardarFoto.Enabled = false;
        }

        private void pnlTituloForm_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCapturarFoto_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public Image CambiarTamanoImagen(Image pImagen, int pAncho, int pAlto)
        {
            //creamos un bitmap con el nuevo tamaño
            Bitmap vBitmap = new Bitmap(pAncho, pAlto);
            //creamos un graphics tomando como base el nuevo Bitmap
            using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))
            {
                //especificamos el tipo de transformación, se escoge esta para no perder calidad.
                vGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //Se dibuja la nueva imagen
                vGraphics.DrawImage(pImagen, 0, 0, pAncho, pAlto);
            }
            //retornamos la nueva imagen
            return (Image)vBitmap;
        }

        // Métodos para convertir Imagen a Base64, y viceversa
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnCapturarFoto_Click(object sender, EventArgs e)
        {
            FrameFinal.Stop();
            pcbFoto.Image = pcbCamara.Image;           
            btnGuardarFoto.Enabled = true;
            btnCapturarFoto.Enabled = false;

            pcbCamara.Enabled = false;
            pcbCamara.Visible = false;

            pcbFoto.Visible = true;
            btnActivarCamara.Enabled = true;

            if (pcbFoto.Image != null)
                OriginalImage = new Bitmap(pcbFoto.Image);

        }
        
    }
}
