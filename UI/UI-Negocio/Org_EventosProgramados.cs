using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class Org_EventosProgramados : Form
    {

        
        BLL_Evento bllEvento;
        List<Evento> listEventos;
        private Evento eventoSeleccionado;
        string Imagename;

        public Org_EventosProgramados()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
            bllEvento = new BLL_Evento();
            flowLayoutPanel1.HorizontalScroll.Visible = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
        }
        public void MostrarOpciones(Evento evento)
        {
            eventoSeleccionado = evento;

            this.groupBox1.Visible = true;
            this.groupBox1.Enabled = true;

            txtNombre.Text = evento.nombre;
            richTextDescripcion.Text = evento.Descripcion;
            dateTimePicker1.MinDate = evento.Fecha;
            dateTimePicker1.Value = evento.Fecha;
            if (evento.portada != null)
            {
                pictureBox1.Visible = true;
                using (MemoryStream stream = new MemoryStream(evento.portada))
                {
                    Image imagen = Image.FromStream(stream);

                    pictureBox1.Image = imagen;
                }
                picCancel.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
                picCancel.Visible = false;
            }

        }
        public void CancelarEvento(Evento evento)
        {
            string mensaje = $"Esta seguro que desea cancelar el evento '{evento.nombre}' , una vez cancelado\nse le comunicara a los participantes inscriptos y posteriormente se le\ndevolvera el coste de inscripcion ";
            DialogResult result = MessageBox.Show(mensaje,"Cancelar evento", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (bllEvento.Cancel(evento))
                {
                    MessageBox.Show("Evento cancelado exitosamente","Evento Cancelado",MessageBoxButtons.OK);
                    this.OnLoad(null);
                }
            }
        }
        private void CargarEventos()
        {
            try
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        control.Dispose();
                    }
                    flowLayoutPanel1.Controls.Clear();
                }

                if (listEventos.Count>0)
                {
                    

                    foreach (Evento evento in listEventos)
                    {
                        Org_EventoDisplay Edisp = new Org_EventoDisplay(evento);
                        Edisp.SetEvento(evento.nombre, evento.Fecha, evento.portada);
                        Edisp.editarHandler += (sender, e) =>
                        {
                            MostrarOpciones(Edisp.MiEvento);
                        };
                        Edisp.cancelarHandler += (sender, e) =>
                        {
                            CancelarEvento(Edisp.MiEvento);
                        };

                        flowLayoutPanel1.Controls.Add(Edisp);
                    }
                }
                else
                {
                    MessageBox.Show("Por el momento no tiene eventos publicados","Sin eventos disponibles",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Org_EventosProgramados_Load(object sender, EventArgs e)
        {
            listEventos = bllEvento.GetAllByOrg();
            CargarEventos();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Imagename = string.Empty;
            eventoSeleccionado.portada = null;
            picCancel.Visible = false;
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string imageDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");
                        if (!Directory.Exists(imageDirectory))
                        {
                            Directory.CreateDirectory(imageDirectory);
                        }

                        Imagename = Guid.NewGuid().ToString() + ".jpg";
                        string fileName = Imagename;
                        string imagePath = Path.Combine(imageDirectory, fileName);

                        File.Copy(openFileDialog.FileName, imagePath);

                        pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
                    }

                    picCancel.Visible = true;
                    eventoSeleccionado.portada = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "/Images/" + Imagename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                #region(ErrorProvider)
                errorProvider1.Clear();
                errorProvider1.SetError(txtNombre, "");
                errorProvider1.SetError(richTextDescripcion, "");
                errorProvider1.SetError(dateTimePicker1, "");

                bool errorFlag = false;

                if (richTextDescripcion.Text == string.Empty)
                {
                    errorProvider1.SetError(richTextDescripcion, "Descripcion del evento obligatoria");
                    errorFlag = true;
                }
                if (txtNombre.Text == string.Empty)
                {
                    errorProvider1.SetError(txtNombre, "Nombre del evento obligatorio");
                    errorFlag = true;
                }
                #endregion

                if (!errorFlag) 
                {
                    eventoSeleccionado.nombre = txtNombre.Text;
                    eventoSeleccionado.Descripcion = richTextDescripcion.Text;
                    eventoSeleccionado.Fecha = dateTimePicker1.Value;

                    bllEvento.Update(eventoSeleccionado);
                    this.OnLoad(null);
                    groupBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
