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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private static Cinema currentcinema = new Cinema();
        public Window1(Cinema selctedcinema)
        {
            List<string> city = new List<string> { "Perm", "Moscow", "Saransk", "Rostov", "Sochi", "Ekaterinburg" };
           
            InitializeComponent();

            if (selctedcinema != null)
            {
                currentcinema = selctedcinema;
                
            }
            else
            {
                currentcinema = new Cinema();
            }

            CB.ItemsSource = city;
            DataContext = currentcinema;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            do
            {
                if (string.IsNullOrWhiteSpace(currentcinema.Name_cinema))
                {
                    errors.AppendLine("Укажите название кинотеатра");
                }
                if (string.IsNullOrWhiteSpace(currentcinema.Address_cinema))
                    errors.AppendLine("Укажите адресс кинотеатра");

                if (currentcinema.Telephone_number < 0 || currentcinema.Telephone_number > 8999999)
                    errors.AppendLine("Введен неправильно номер");

                if (string.IsNullOrWhiteSpace(currentcinema.Telephone_number.ToString()))
                    errors.AppendLine("Укажите номер телефона");

                
                
               
                if (string.IsNullOrWhiteSpace(currentcinema.Number_films.ToString()))
                    errors.AppendLine("Укажите количество фильмов");

                if (string.IsNullOrWhiteSpace(currentcinema.Number_session.ToString()))
                    errors.AppendLine("Укажите   количество сеансов");

                if (string.IsNullOrWhiteSpace(currentcinema.Work_timecinema))
                    errors.AppendLine("Укажите время работы");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

            } while (errors.Length > 0);



            if (currentcinema.ID_cinema == 0) { KursovaiaEntities1.GetContext().Cinemas.Add(currentcinema); }

            try
            {
                currentcinema.City = CB.Text;
                KursovaiaEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                MainWindow k = new MainWindow();
                this.Close();
                k.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        


          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow k = new MainWindow();
           

            this.Close();
            k.Show();

        }

        private void CB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CB.IsDropDownOpen = true;
            // убрать selection, если dropdown только открылся
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CB.ItemsSource);
            cv.Filter = s =>
                ((string)s).IndexOf(CB.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
