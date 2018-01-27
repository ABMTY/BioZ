
using DPFP;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using BioZFinger.Utilities;

namespace BioZFinger
{
    /*
        NOTA: Formulario de Escaneo de Huella Digital Inicial
              Dependiendo de si existe o no la huella en la base de datos
              se redirige el Usuario a CaptureForm donde se registra.
    */
    public partial class Validar : Form, DPFP.Capture.EventHandler
    {
        // Variables Globales, requeridas por el SDK
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        private DPFP.Processing.Enrollment Enroller;
        public string Id_Empleado, Nombre_Empleado;
        // Variable Global donde se almacena la huella escaneada. "Template" es una clase del SDK
        Template plantilla;
        CtrlEmpleadoHuella control = new CtrlEmpleadoHuella();
        CtrlEmpleados ctrl_empleado = new CtrlEmpleados();
        // Permitir arrastrar la ventana desde cualquier parte del formulario donde se haga Click.
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        // Todas los Usuarios del sistema se cargan en esta lista
        List<EntEmpleado> ListaEmpleados = new List<EntEmpleado>();

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message) {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        // Inicializacion del Formulario y sus componentes
        public Validar() {
            InitializeComponent();
        }

        // Métodos para convertir Imagen a Base64, y viceversa
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format) {
            using (MemoryStream ms = new MemoryStream()) {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String) {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        // Inicializar proceso de captura
        private void InicializarCaptura() {
            try {
                Capturer = new DPFP.Capture.Capture();				// Crea la operacion de captura
                this.OnTemplate += CaptureForm_OnTemplate;

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Suscribe los eventos de captura.
                else
                    SetPrompt("Can't initiate capture operation!");
            } catch {
                //MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clase utilizada para almacenar la informacion del Usuario, tabla "usuarios"

        

        // Este método carga todos los Usuarios de la base de datos
        private void ObtenerEmpleados() {

            try
            {
                ListaEmpleados = ctrl_empleado.ObtenerTodos();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // Clase utilizada para almacenar la información de la huella, tabla "huellas"


        // Todas las huellas del sistema se encargan en esta lista, para compararlas con la del usuario que pone su dedo.
        List<EmpleadoHuella> ListaHuellas = new List<EmpleadoHuella>();

        // Este método carga la lista ListaHuellas con todas las huellas de la base de datos
        private void ObtenerHuellas() {

            try
            {                
                ListaHuellas = control.ObtenerTodos();                
            }
            catch (Exception)
            {

                throw;
            }         
        }

        // Inicializacion del SDK
        protected virtual void Init() {
            // Se obtienen los Templates (Huellas)
            ObtenerHuellas();
            ObtenerEmpleados();
            // Se inicializa la Captura, para empezar a recibir huellas
            InicializarCaptura();
            Enroller = new DPFP.Processing.Enrollment();			// Evento de Registro del SDK
            UpdateStatus();
        }

        void CaptureForm_OnTemplate(DPFP.Template template) {
            // Este evento es llamado automaticamente por el SDK una vez que se escanea la huella 4 veces.
            // Y nos envia la "template" por parametro, que usamos para convertir a binario y subir al a base de datos.

            // Invoke es necesario siempre que queramos hacer cambios a objetos/elementos de nuestro formulario
            // esto se debe a que el proceso de Captura del escaner se realiza en un proceso por separado.
            this.Invoke(new MethodInvoker(delegate {
                // Si todo sale bien, la variable global "plantilla" se coloca como la plantilla generada por el escaner
                plantilla = template;
                // La convertimos a un arreglo de bytes
                MemoryStream fingerprintData = new MemoryStream();
                template.Serialize(fingerprintData);
                fingerprintData.Position = 0;
                BinaryReader br = new BinaryReader(fingerprintData);
                Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
            }));
        }

        protected virtual void ProcesarMuestra(DPFP.Sample Sample) {
            // Este evento es llamado automaticamente por el SDK cada que se pase el dedo por el escaner
            // En total, se manda a llamar 4 veces, las 4 veces requeridas por el SDK para generar el template.

            // Convierte la muestra "Sample" a imagen, y la muestra en el picturebox. (Esta es la imagen de la huella como tal)
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        protected void Start() {
            // Inicia la captura de la huella digital
            if (null != Capturer) {
                try {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                } catch {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }

        protected void Stop() {
            // Detiene la captura de la huella digital
            if (null != Capturer) {
                try {
                    Capturer.StopCapture();
                } catch {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }

        #region Form Event Handlers:

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e) {
            Stop();
        }
        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample) {
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber) {
            MakeReport("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber) {
            MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber) {
            MakeReport("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber) {
            MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback) {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The quality of the fingerprint sample is good.");
            else
                MakeReport("The quality of the fingerprint sample is poor.");
        }
        #endregion

        // Convierte el Sample a imagen y la devuelve.
        // Esto permite mostrarla en el Picturebox
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample) {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        // Este método es propia del SDK, obtiene ciertos puntos clave de la huella digital que la convierte en unica
        // y genera algo llamado "Features" o "Caracteristicas", con ellas se hace la comparativa con otras huellas.
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose) {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        // Todos estos métodos venian incluidos en el SDK, los deje por si requieren ejemplos
        // de como acceder a elementos de nuestro formulario, desde el proceso externo de captura.
        protected void SetStatus(string status) {
            StatusLine.Invoke(new MethodInvoker(delegate { Prompt.Text = status; }));
        }

        protected void SetPrompt(string prompt) {
            Prompt.Invoke(new MethodInvoker(delegate { Prompt.Text = prompt; }));
        }

        protected void MakeReport(string message) {
            StatusText.Invoke(new MethodInvoker(delegate { StatusText.AppendText(message + "\r\n"); }));
        }

        private void DrawPicture(Bitmap bitmap) {
            Picture.Invoke(new MethodInvoker(delegate { Picture.Image = new Bitmap(bitmap, Picture.Size); }));
        }

        // Aqui terminan --

        // Variable global del Capturador
        private DPFP.Capture.Capture Capturer;       

        private void UpdateStatus() {
            // Show number of samples needed.
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
        }
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
        
        protected void Process(DPFP.Sample Sample) {
            // Este método es el proceso de verificación, para revisar que la huella escaneada exista en la base de datos.
            string startupPath = Application.StartupPath;
            ProcesarMuestra(Sample);
            bool encontrado = false;
            string Nombre = string.Empty;
            // En cambio, si existen huellas, vamos a iterar sobre ellas
            foreach (EmpleadoHuella entEmpleadoHuella in ListaHuellas)
            {
                // Por cada huella... la almacenamos en un MemoryStream como arreglo de bytes.
                MemoryStream fingerprintData = new MemoryStream(entEmpleadoHuella.b64huella);
                // Creamos una plantilla a partir de esos bytes...
                DPFP.Template templateIterando = new DPFP.Template(fingerprintData);

                // Extraemos las caracteristicas de la plantilla
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                // Verificamos que las caracteristicas sean buenas
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, templateIterando, ref result);

                    // Y vemos si el resultado es valido o no, (verified)
                    // Si es verified, significa que el dedo escaneado ya existia en la base de datos.

                    if (result.Verified)
                    {
                        // Creamos una instancia de usuario, que va a equivaler al usuario cuya huella coincidio de la base
                        EntEmpleado u = ListaEmpleados.Where(x => x.id_empleado == entEmpleadoHuella.id_empleado).SingleOrDefault();
                        
                        try
                        {
                            pcbCamara.Image = null;
                            // Convert base 64 string to byte[]
                            byte[] imageBytes = Convert.FromBase64String(u.imagen);
                            // Convert byte[] to Image
                            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                            {
                                pcbCamara.Image = Image.FromStream(ms, true);                                
                            }
                           
                        }
                        catch (Exception ex)
                        {
                        }
                        encontrado = true;
                        break;
                    }
                    else
                    {
                        encontrado = false;
                    }
                }
            }
            //Si no encontro la huella, lanzar el formulario de Registro
            if (encontrado == false)
            {
                try
                {                  
                    pcbCamara.Image = Properties.Resources.NoFinger;
                    pcbCamara.Refresh();
                    pcbCamara.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("No se encuentra RegistrosHuella!", "Falta Ejecutable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                }
            }
        }
       
        void FrameFinal_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs) {
            // Evento llamado por el video de la camara, copiamos la imagen obtenida del stream
            // y la colocamos en el picturebox, simulando un video.
            pcbCamara.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Validar_FormClosed(object sender, FormClosedEventArgs e)
        {          
            // Cerramos la aplicacion
            Application.Exit();
        }

        private void lblCloseButton_Click(object sender, EventArgs e) {
            RinicializarLector();
            this.Close();
        }

        private void Validar_Load(object sender, EventArgs e) {            
            // Se inicializa el programa
            Init();
            Start();
        }

        private void lblPanelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Validar_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralUtility.Form_MouseDown();
            GeneralUtility.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void RinicializarLector()
        {            
            Stop();            
        }
    }
}