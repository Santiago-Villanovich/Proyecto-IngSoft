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
    public partial class CalendarDay : UserControl
    {
        public CalendarDay()
        {
            InitializeComponent();
        }

        private void CalendarDay_Load(object sender, EventArgs e)
        {

        }

        public void days(int numDay)
        {
            this.numberDisplay.Text = numDay.ToString();
        }
    }
}
