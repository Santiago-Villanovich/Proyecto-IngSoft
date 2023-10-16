using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class FormPagar : Form
    {
        private int validator;
        public FormPagar()
        {
            InitializeComponent();
        }

        public void generarQr()
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                validator = new Random().Next(1111, 9999);
                string numVerificacion =Convert.ToString(validator);

                QRCodeData qrCodeData = qrGenerator.CreateQrCode(numVerificacion, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            int input;

            if (int.TryParse(textBox1.Text, out input))
            {
                if (validator == input)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Número verificador incorrecto");
                    button1.Enabled = true; 
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "Ingresa un número válido");
                button1.Enabled = true; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormPagar_Load(object sender, EventArgs e)
        {
            generarQr();
        }
    }
}
