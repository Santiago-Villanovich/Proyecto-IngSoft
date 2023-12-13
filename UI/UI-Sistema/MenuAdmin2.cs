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

namespace UI.UI_Sistema
{
    public partial class MenuAdmin2 : Form, IObserver
    {
        BLL_Traductor traductor;

        private void TraducirForm(IIdioma idioma = null)
        {

            var traducciones = traductor.ObtenerTraducciones(idioma);

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                    if (menuItem.Tag != null && traducciones.ContainsKey(menuItem.Tag.ToString()))
                        menuItem.Text = traducciones[menuItem.Tag.ToString()].texto;

                    foreach (ToolStripItem ts in menuItem.DropDownItems)
                    {
                        if (ts.Tag != null && traducciones.ContainsKey(ts.Tag.ToString()))
                            ts.Text = traducciones[ts.Tag.ToString()].texto;
                    }
                }
            }
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

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        public MenuAdmin2()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();
            TraducirForm(Session.IdiomaActual);
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

        private void gestionarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void gestionarOrganizacionesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void gestionarIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void cerrarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout();
            this.Close();
            Application.Restart();
        }
    }
}
