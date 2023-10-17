
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI_Negocio
{
    public partial class User_Inicio : Form
    {
        int day,month, year;
        static DateTime currentDT;
        static int currentYear;
        static int currentMonth;

        public List<Evento> events;

        public User_Inicio()
        {
            InitializeComponent();
            currentDT = DateTime.Now;
            currentMonth = currentDT.Month;
            currentYear = currentDT.Year;

            events = new BLL_Evento().GetAllByUser();
        }

        private void User_Inicio_Load(object sender, EventArgs e)
        { 
            MostrarDias();
        }

        private void MostrarDias()
        {

            //Establezco el lbl de fecha
            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            lblMesNow.Text = mesNombre + " " + currentYear.ToString();

            //Calculo dias para completar el container
            DateTime startDayMonth = new DateTime(currentYear, currentMonth, 1);
            int days = DateTime.DaysInMonth(currentYear, currentMonth);
            int dayOfWeek = Convert.ToInt32(startDayMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayOfWeek; i++)
            {
                CalendarDayBlank CDayBlank = new CalendarDayBlank();
                DaysContainer.Controls.Add(CDayBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                CalendarDay CDay = new CalendarDay();
                DateTime fecha = new DateTime(currentYear, currentMonth, i);
                Evento ev = events.Find(objeto => objeto.Fecha == fecha);
                if (ev != null)
                {
                    CDay.eventoDia = ev;
                }

                CDay.days(fecha);

                DaysContainer.Controls.Add(CDay);
            }
        }

        private void btnAnteriorMes_Click(object sender, EventArgs e)
        {
            DaysContainer.Controls.Clear();
            if (currentMonth == 1)
            {
                currentMonth = 12;
                currentYear--;
                MostrarDias();
            }
            else
            {
                currentMonth--;
                MostrarDias();
            }
            
        }

        private void btnSiguienteMes_Click(object sender, EventArgs e)
        {
            DaysContainer.Controls.Clear();
            if (currentMonth == 12)
            {
                currentMonth = 1;
                currentYear++;
                MostrarDias();
            }
            else
            {
                currentMonth++;
                MostrarDias();
            }
        }
    }
}
