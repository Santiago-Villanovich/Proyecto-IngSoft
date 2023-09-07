using Syncfusion.WinForms.Input;
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
    public partial class User_Inicio : Form
    {
        public User_Inicio()
        {
            InitializeComponent();
        }

        private void User_Inicio_Load(object sender, EventArgs e)
        {
            SpecialDate specialDate1 = new SpecialDate();
            List<SpecialDate> SpecialDates = new List<SpecialDate>();

            specialDate1.BackColor = System.Drawing.Color.Red;
            specialDate1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            specialDate1.ForeColor = System.Drawing.Color.White;
            specialDate1.Description = "Evento";
            /*specialDate1.Image = Properties.Resources.icons_Womens_day;
            specialDate1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;*/
            specialDate1.IsDateVisible = false;
            specialDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            specialDate1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            specialDate1.Value = new System.DateTime(2023, 09, 15);
            SpecialDates.Add(specialDate1);
            this.CalendarioInicio.SpecialDates = SpecialDates;
        }
    }
}
