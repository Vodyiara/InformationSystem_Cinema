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
    /// Логика взаимодействия для Redactormenu.xaml
    /// </summary>
    public partial class Redactormenu : Window
    {
        public Redactormenu()
        {
            InitializeComponent();
            Login.Text += Administratenter.log;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow k = new MainWindow();
           
            k.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Films k = new Films();
            
            k.Show();
        }




        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Seans k = new Seans();
            k.Show();
             
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Zal k = new Zal();
            k.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Actorcrew k = new Actorcrew();
            k.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Reziser k = new Reziser();
            k.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Poster2 k = new Poster2();
            k.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Mainmenu j = new Mainmenu();
            this.Close();
            j.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В этом меню можно выбирать элементы для редактирования.");
        }
    }
}
