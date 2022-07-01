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
    /// Логика взаимодействия для Addzal.xaml
    /// </summary>
    public partial class Addzal : Window
    {
        public List<View_2> ci;
        private static Lounge cureses = new Lounge();
        public Addzal(Lounge selecteession, List<View_2> y)
        {
            InitializeComponent();
            if (selecteession != null)
            {
                cureses = selecteession;

            }
            else
            {
                cureses = new Lounge();
            }
            ci = y;

            DataContext = cureses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Zal.flag2 == true)
            {
                if (cureses.Lounge_number == 0) { KursovaiaEntities1.GetContext().Lounges.Add(cureses); }

                try
                {
                    KursovaiaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!1111");
                    Zal k = new Zal();


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

                foreach (View_2 i in ci)
                {
                    cureses.ID_session = i.ID_session;
                   

                    KursovaiaEntities1.GetContext().Lounges.Add(cureses);


                    KursovaiaEntities1.GetContext().SaveChanges();
                }
                MessageBox.Show("Информация сохранена!");
                Zal k = new Zal();


                this.Close();
                k.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Zal k = new Zal();
            k.Show();
        }
    }
}
