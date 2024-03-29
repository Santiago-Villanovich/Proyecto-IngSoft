﻿using Services;
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
using UI.UI_Sistema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class MenuAdmin : Form, IObserver
    {
        private Idioma IdiomaActual { get; set; }
        private void TraducirForm(IIdioma idioma = null)
        {

            var traducciones = traductor.ObtenerTraducciones(idioma);

            if (administrarToolStripMenuItem.Tag != null && traducciones.ContainsKey(administrarToolStripMenuItem.Tag.ToString()))
                administrarToolStripMenuItem.Text = traducciones[administrarToolStripMenuItem.Tag.ToString()].texto;

            if (gestionarUsuariosToolStripMenuItem.Tag != null && traducciones.ContainsKey(gestionarUsuariosToolStripMenuItem.Tag.ToString()))
                gestionarUsuariosToolStripMenuItem.Text = traducciones[gestionarUsuariosToolStripMenuItem.Tag.ToString()].texto;

            if (verBitacoraToolStripMenuItem.Tag != null && traducciones.ContainsKey(verBitacoraToolStripMenuItem.Tag.ToString()))
                verBitacoraToolStripMenuItem.Text = traducciones[verBitacoraToolStripMenuItem.Tag.ToString()].texto;

            if (opcionesToolStripMenuItem.Tag != null && traducciones.ContainsKey(opcionesToolStripMenuItem.Tag.ToString()))
                opcionesToolStripMenuItem.Text = traducciones[opcionesToolStripMenuItem.Tag.ToString()].texto;

            if (configuracionToolStripMenuItem.Tag != null && traducciones.ContainsKey(configuracionToolStripMenuItem.Tag.ToString()))
                configuracionToolStripMenuItem.Text = traducciones[configuracionToolStripMenuItem.Tag.ToString()].texto;

            if (permisosToolStripMenuItem.Tag != null && traducciones.ContainsKey(permisosToolStripMenuItem.Tag.ToString()))
                permisosToolStripMenuItem.Text = traducciones[permisosToolStripMenuItem.Tag.ToString()].texto;
        }

        public static bool FormEstaAbierto(Type Form)
        {
            foreach (Form formulario in Application.OpenForms)
            {
                if (formulario.GetType() == Form)
                {
                    return true;
                }
            }
            return false;
        }

        public MenuAdmin()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();

            //Session.IdiomaActual = (Idioma)traductor.ObtenerIdiomaDefault();
            //IdiomaActual = Session.IdiomaActual;
            //TraducirForm(Session.IdiomaActual);
        }

        BLL_Traductor traductor;

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
            IdiomaActual = Session.IdiomaActual;

        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestUsuarios menu = new GestUsuarios();
            if (!Session.tiene_permiso(1032))
            {
                MessageBox.Show("No tiene permisos adecuados");
                return;
            }
            if (!FormEstaAbierto(typeof(GestUsuarios)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }
            
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout();
            LogIn form = new LogIn();
            this.Close();
            form.Show();
        }

        private void verBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacoras form = new FormBitacoras();
            if (!Session.tiene_permiso(1006))
            {
                MessageBox.Show("No sos admin");
                return;
            }
            if (!FormEstaAbierto(typeof(FormBitacoras)))
            {
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }

        }


        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPermisos menu = new FormPermisos();
            if (!Session.tiene_permiso(1025))
            {
                MessageBox.Show("No sos admin");
                return;
            }
            if (!FormEstaAbierto(typeof(FormPermisos)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }


        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregarIdioma menu = new FormAgregarIdioma();
            if (!Session.tiene_permiso(1011))
            {
                MessageBox.Show("No tiene permisos adecuados");
                return;
            }
            if (!FormEstaAbierto(typeof(FormAgregarIdioma)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }
            
        }

        private void verHistorialDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistorialCambios menu = new FormHistorialCambios();
            if (!Session.tiene_permiso(1033))
            {
                MessageBox.Show("No ttiene permisos adecuados");
                return;
            }
            if (!FormEstaAbierto(typeof(FormHistorialCambios)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarOrganizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaOrganizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCrearOrg menu = new FormCrearOrg();
            /*if (!Session.tiene_permiso(1037))
            {
                MessageBox.Show("No tiene permisos adecuados");
                return;
            }*/
            if (!FormEstaAbierto(typeof(FormConfiguracion)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }
        }

        private void asociarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarioOrg menu = new FormUsuarioOrg();
            /*if (!Session.tiene_permiso(1037))
            {
                MessageBox.Show("No tiene permisos adecuados");
                return;
            }*/
            if (!FormEstaAbierto(typeof(FormConfiguracion)))
            {
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya se encuentra abierto. Para abrir uno nuevo cierre el que esta en uso");
            }
        }

        private void gestionarUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
