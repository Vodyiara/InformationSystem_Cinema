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
    /// Логика взаимодействия для Administratenter.xaml
    /// </summary>
    public partial class Administratenter : Window
    {

        public static string log = "";
        public Administratenter()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainmenu k = new Mainmenu();
            this.Close();
            k.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                   
                    if (login.Text ==  "vadik"  && password.Password == "123") // если такая запись существует       
                    {
                        log = login.Text;
                        MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался    
                        Redactormenu k = new Redactormenu();
                        this.Close();
                        k.Show();
                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для входа меню админитратора, нужна авторизация, для этого введите логи и пароль");
        }
    }
}
