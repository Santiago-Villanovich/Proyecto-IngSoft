using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Services.SecurityAndValidation;

namespace UI
{
    public partial class CorruptedDataBase : Form
    {
        public CorruptedDataBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DigitoVerificador verificadorDV = new BLL_DigitoVerificador();
                verificadorDV.InsertDVTabla(new BLL_User().GetAll(), "Users");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Application.Restart();
            }
            
        }
    }
}
