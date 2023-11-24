using BE;
using BLL;
using Newtonsoft.Json;
using Services;
using Services.Multilanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class User_Desempenio : Form,IObserver
    {
        BLL_Equipo bllEquipo;
        List<Participante> participaciones;
        BLL_Traductor traductor;
        public User_Desempenio()
        {
            InitializeComponent();
            bllEquipo = new BLL_Equipo();
            Session._publisherIdioma.Subscribe(this);
            traductor = new BLL_Traductor();

            flowLayoutPanel1.VerticalScroll.Visible = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;


            button1.Visible = false;
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.Controls)
                {

                    if (control.Tag != null && traducciones.ContainsKey(control.Tag.ToString()))
                        control.Text = traducciones[control.Tag.ToString()].texto;

                }
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDesempenio()
        {
            try
            {
                participaciones = bllEquipo.GetAllParticipanteByUser(Session.GetInstance.Usuario.Id);
                participaciones = participaciones.OrderBy(p => p.fecha).ToList();

                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        control.Dispose();
                    }
                    flowLayoutPanel1.Controls.Clear();
                }

                if (participaciones.Count > 0)
                {
                    foreach (Participante p in participaciones)
                    {
                        User_DesempenioDisplay edisp = new User_DesempenioDisplay(p);
                        
                        flowLayoutPanel1.Controls.Add(edisp);
                    }
                }
                else
                {
                    MessageBox.Show("Por el momento no a participado de ninguna competencia", "Sin registros disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void User_Desempenio_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDesempenio();
                if (participaciones.Count > 0)
                {
                    button1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos JSON|*.json";
                saveFileDialog.Title = "Guardar archivo JSON";
                saveFileDialog.FileName = "misParticipaciones.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;

                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(writer, participaciones);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
