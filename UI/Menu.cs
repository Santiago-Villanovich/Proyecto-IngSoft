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

namespace UI
{
    public partial class Menu : Form, IObserver
    {
        public Idioma IdiomaActual { get; set; }
        public Menu()
        {
            InitializeComponent();
        }

        public void Notify(Idioma idioma)
        {
            IdiomaActual = idioma;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Logout();
            LogIn form = new LogIn();
            this.Close();
            form.Show();

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Session._publisherIdioma.Subscribe(this);
        }
    }
}
