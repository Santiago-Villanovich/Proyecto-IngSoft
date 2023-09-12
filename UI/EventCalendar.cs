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
    public partial class EventCalendar : UserControl
    {
        public EventCalendar()
        {
            InitializeComponent();
        }

        private void EventCalendar_Load(object sender, EventArgs e)
        {
            MostrarDias();
        }

        private void MostrarDias()
        {
            DateTime now = DateTime.Now;
            DateTime starDayMonth = new DateTime(now.Year, now.Month, 1);
            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int dayOfWeek = Convert.ToInt32(starDayMonth.DayOfWeek.ToString("d")) +1;

            for (int i = 1; i <dayOfWeek; i++)
            {
                CalendarDayBlank CDayBlank = new CalendarDayBlank();
                dayContainer.Controls.Add(CDayBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                CalendarDay CDay = new CalendarDay();
                CDay.days(i);
                dayContainer.Controls.Add(CDay);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}
