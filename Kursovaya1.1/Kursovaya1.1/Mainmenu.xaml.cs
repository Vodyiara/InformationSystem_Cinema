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
    /// Логика взаимодействия для Mainmenu.xaml
    /// </summary>
    public partial class Mainmenu : Window
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administratenter j = new Administratenter();
            this.Close();
            j.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Userwindow k = new Userwindow();
            this.Close();
            k.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В главном менюесть кнопки с выбором пользовательского меню и меню админитратора");
        }
    }
}
