using BE;
using BLL;
using Services;
using Services.Multilanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UI_Negocio;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;

namespace UI
{
    public partial class Org_Menu : Form,IObserver
    {
        BLL_Evento bllEvento;
        BLL_Traductor traductor;
        public Org_Menu()
        {
            InitializeComponent();
            this.Size = new Size(1200, 650);
            this.MinimumSize = new Size(1200, 650);
            bllEvento = new BLL_Evento();
            traductor = new BLL_Traductor();
            Session._publisherIdioma.Subscribe(this);

            TraducirForm(Session.IdiomaActual);
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                TraducirFormPanel(this.panelNav,idioma);
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

        private void TraducirFormPanel(Panel panel,IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in panel.Controls)
                {

                    if (control is System.Windows.Forms.Button)
                    {
                        System.Windows.Forms.Button boton = (System.Windows.Forms.Button)control;
                        if (boton.Tag != null && traducciones.ContainsKey(boton.Tag.ToString()))
                            boton.Text = traducciones[boton.Tag.ToString()].texto;
                    }
                    else if (control is Label)
                    {
                        Label label = (Label)control;
                        if (label.Tag != null && traducciones.ContainsKey(label.Tag.ToString()))
                            label.Text = traducciones[label.Tag.ToString()].texto;

                    }
                    else if (control is System.Windows.Forms.GroupBox)
                    {
                        foreach (Control cont in control.Controls)
                        {
                            if (control is System.Windows.Forms.Button)
                            {
                                System.Windows.Forms.Button boton = (System.Windows.Forms.Button)control;
                                if (boton.Tag != null && traducciones.ContainsKey(boton.Tag.ToString()))
                                    boton.Text = traducciones[boton.Tag.ToString()].texto;
                            }
                            else if (control is Label)
                            {
                                Label label = (Label)control;
                                if (label.Tag != null && traducciones.ContainsKey(label.Tag.ToString()))
                                    label.Text = traducciones[label.Tag.ToString()].texto;

                            }
                        }
                    }

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

        private void CargarMenuContenedor(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                Session._publisherIdioma.Unsuscribe((IObserver)panelContenedor.Controls[0].Tag);
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form frm = formHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frm);
            this.panelContenedor.Tag = frm;

            if (frm is Org_IniciarEvento orgIniciarEventoForm)
            {
                orgIniciarEventoForm.mostrarIniciar += (sender, e) => MostrarEventoIniciado(orgIniciarEventoForm.eventoIniciado);
            }

            
            frm.Show();
        }


        private void MostrarEventoIniciado(Evento ev)
        {
            CargarMenuContenedor(new Org_EventoIniciado(ev));
            this.MinimumSize = new Size(1080, 680);
            this.Size = new Size(1080, 680);
            
        }

        private void btnNuevoEvento_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_NuevoEvento());
            this.MinimumSize = new Size(1125, 755);
            this.Size = new Size(1125, 755);
        }

        private void btnIniciarEvento_Click(object psender, EventArgs ea)
        {
            CargarMenuContenedor(new Org_IniciarEvento());
            this.MinimumSize = new Size(1100, 650);
            this.Size = new Size(1100, 650);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Close();
            Application.Restart();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormConfiguracion form = new FormConfiguracion();
            form.Show();
        }

        private void btnEventosProgramados_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_EventosProgramados());
            this.MinimumSize = new Size(980, 780);
            this.Size = new Size(980, 780);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Org_Inicio());
        }
    }
}
