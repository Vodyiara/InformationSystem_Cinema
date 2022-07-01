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
    /// Логика взаимодействия для Addfilm.xaml
    /// </summary>
    public partial class Addfilm : Window
    {
       
        public List<Cinema> ci;
        private static Film currentfilm = new Film();
        public Addfilm(Film selectedfilm, List<Cinema> y)
        {
            
            InitializeComponent();
            if (selectedfilm != null)
            {
                currentfilm = selectedfilm;

            }
            else
            {
                currentfilm = new Film();
            }
            ci = y;

            DataContext = currentfilm;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            do
            {
                if (string.IsNullOrWhiteSpace(currentfilm.Film_name))
                {
                    errors.AppendLine("Укажите название фильма");
                }
                if (string.IsNullOrWhiteSpace(currentfilm.genre))
                    errors.AppendLine("Укажите жанр фильма");

                if (!(currentfilm.Duration is  int))
                    errors.AppendLine("Введена неправильно продолжительность");
                if (!(currentfilm.Foundation_year is int))
                    errors.AppendLine("Введен неправильно год создания");

                if (string.IsNullOrWhiteSpace(currentfilm.Foundation_year.ToString()))
                    errors.AppendLine("Укажите год созданиыя ");
                if (string.IsNullOrWhiteSpace(currentfilm.Studio))
                    errors.AppendLine("Укажите студию ");
                if (string.IsNullOrWhiteSpace(currentfilm.Film_rating.ToString()))
                    errors.AppendLine("Укажите рейтинг фильма ");
                if (string.IsNullOrWhiteSpace(currentfilm.Film_rating.ToString()))
                    errors.AppendLine("Укажите рейтинг фильма ");
                if (string.IsNullOrWhiteSpace(currentfilm.Film_scores.ToString()))
                    errors.AppendLine("Укажите рейтинг фильма ");

                if (string.IsNullOrWhiteSpace(currentfilm.Start_distribution))
                    errors.AppendLine("Укажите дату начала проката");

                if (string.IsNullOrWhiteSpace(currentfilm.End_distribution))
                    errors.AppendLine("Укажите дату конца проката");

             

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

            } while (errors.Length > 0);


            if (Films.flag1 == true)
            {
                if (currentfilm.ID_film == 0) { KursovaiaEntities1.GetContext().Films.Add(currentfilm); }

                try
                {
                    KursovaiaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!1111");
                   Films k = new Films();


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

                foreach (Cinema i in ci)
                {
                    currentfilm.ID_cinema = i.ID_cinema;

                    KursovaiaEntities1.GetContext().Films.Add(currentfilm);


                    KursovaiaEntities1.GetContext().SaveChanges();
                }
                MessageBox.Show("Информация сохранена!");
                Films k = new Films();


                this.Close();
                k.Show();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Films k = new Films();


            this.Close();
            k.Show();
        }
    }
}
