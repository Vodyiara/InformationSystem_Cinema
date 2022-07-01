using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovaya1._1
{
    /// <summary>
    /// Логика взаимодействия для Addsession.xaml
    /// </summary>
    public partial class Addsession : Window
    {
        public List<View_1> ci;
        private static Session cureses = new Session();
        public Addsession(Session selecteession, List<View_1> y)
        {
            InitializeComponent();
            if (selecteession != null)
            {
                cureses = selecteession;

            }
            else
            {
                cureses = new Session();
            }
            ci = y;
            vod1.Text = "";

            DataContext = cureses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            do
            {
                if (vod1.Text == "")
                {
                    errors.AppendLine("Укажите дату сеанса");
                }
                if (string.IsNullOrWhiteSpace(cureses.Lounge_number.ToString()))
                    errors.AppendLine("Укажите номер зал");

               

                if (string.IsNullOrWhiteSpace(cureses.Session_time))
                    errors.AppendLine("Укажите время сеанса ");

             

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

            } while (errors.Length > 0);

            if (Seans.flag2 == true)
            {
                if (cureses.ID_film == 0) { KursovaiaEntities1.GetContext().Sessions.Add(cureses); }

                try
                {

                    cureses.Data_session = vod1.Text;
                    KursovaiaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Seans k = new Seans();


                    this.Close();
                    k.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                cureses.Data_session = vod1.Text;
                foreach (View_1 i in ci)
                {
                   cureses.ID_cinema = i.ID_cinema;
                    cureses.ID_film = i.ID_film;

                    KursovaiaEntities1.GetContext().Sessions.Add(cureses);


                    KursovaiaEntities1.GetContext().SaveChanges();
                }
                MessageBox.Show("Информация сохранена!");
                Seans k = new Seans();


                this.Close();
                k.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Seans k = new Seans();
            k.Show();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;

          vod1.Text = selectedDate.Value.Date.ToShortDateString();
        }
    }
}
