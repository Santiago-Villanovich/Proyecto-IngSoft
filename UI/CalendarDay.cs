﻿using System;
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
        public DateTime fecha;
        private Color hover;
        private Color normal;
        private Color evento;
        private Color today;

        public CalendarDay()
        {
            InitializeComponent();
            hover = Color.Gainsboro;
            normal = Color.White;
            evento = Color.IndianRed;
            today = Color.LightBlue;

            lblEvento.Text = string.Empty;

        }

        private bool FechaIgualHoy(DateTime date)
        {
            if (DateTime.Now.ToShortDateString() == date.ToShortDateString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CalendarDay_Load(object sender, EventArgs e)
        {

        }

        public void days(int numDay, DateTime date)
        {
            fecha = date;
            this.numberDisplay.Text = numDay.ToString();

            if (FechaIgualHoy(date)) { this.BackColor = today; }

        }

        #region(hovers)
        private void CalendarDay_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fecha.ToString());
        }

        private void CalendarDay_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = hover;
        }

        private void CalendarDay_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = hover;
        }

        private void CalendarDay_MouseLeave(object sender, EventArgs e)
        {
            if (FechaIgualHoy(fecha))
            { this.BackColor = today; }
            else { this.BackColor = normal; }

        }

        private void numberDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = hover;
        }

        private void numberDisplay_MouseLeave(object sender, EventArgs e)
        {
            if (FechaIgualHoy(fecha))
            { this.BackColor = today; }
            else { this.BackColor = normal; }
        }

        private void numberDisplay_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = hover;
        }
        #endregion
    }
}
