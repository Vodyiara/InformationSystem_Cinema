using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Seans.xaml
    /// </summary>
    public partial class Seans : System.Windows.Window
    {
        public View_1 k2;
        public int q;

        public List<Session> k1;
     
     
        public static bool flag2;

        public Seans()
        {
            InitializeComponent();

            Gridcinemfilm.ItemsSource = KursovaiaEntities1.GetContext().View_1.ToList();


        } 

        

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag2 = false;
            List<View_1>cinem = Gridcinemfilm.SelectedItems.Cast<View_1>().ToList();
            if (cinem.Count == 0) { MessageBox.Show("Выберите фильм, в который нужно добавить сенас"); }
            else
            {
               
                Addsession k = new Addsession(null, cinem);
                this.Close();
                k.Show();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cinem = Gridession.SelectedItems.Cast<Session>().ToList();

            if (cinem.Count == 0) { MessageBox.Show("Вы не выбрали элемент для удаления"); }
            else
            {

                if (MessageBox.Show($"Вы точно хотите удалить следущие {cinem.Count() } элементов", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        KursovaiaEntities1.GetContext().Sessions.RemoveRange(cinem);

                        KursovaiaEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены11");

                        //GridFilm.ItemsSource = KursovaiaEntities.GetContext().Film.ToList();
                        k1 = new List<Session>();
                        List<Session> k = KursovaiaEntities1.GetContext().Sessions.ToList();
                        foreach (Session s in k)
                        {
                            if (s.ID_cinema == k2.ID_cinema)
                            {
                                k1.Add(s);
                            }
                        }
                      Gridession.ItemsSource = k1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (q == -1) { MessageBox.Show("Выберите элемент для экспорта"); }
            else
            {
                Microsoft.Office.Interop.Excel.Application excel = new Excel.Application();
                excel.Visible = true; //www.yazilimkodlama.com
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
                for (int y = 0; y < Gridcinemfilm.Columns.Count; y++)
                {
                    Range myRange = (Range)sheet1.Cells[1, y + 1];
                    sheet1.Cells[1, y + 1].Font.Bold = true; //Başlığın Kalın olması için
                    sheet1.Columns[y + 1].ColumnWidth = 15;
                    myRange.Value2 = Gridcinemfilm.Columns[y].Header;
                }

                for (int j = 0; j < Gridession.Columns.Count; j++) //Başlıklar için
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 4];
                    sheet1.Cells[1, j + 4].Font.Bold = true; //Başlığın Kalın olması için
                    sheet1.Columns[j + 4].ColumnWidth = 15; //Sütun genişliği ayarı
                    myRange.Value2 = Gridession.Columns[j].Header;
                }




                for (int i = 0; i < Gridession.Columns.Count; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Gridession.Items.Count; j++)
                    {



                        TextBlock b = Gridession.Columns[i].GetCellContent(Gridession.Items[j]) as TextBlock;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 4];

                        if (b != null)
                        {
                            myRange.Value2 = b.Text;
                        }


                    }
                }

                for (int i = 0; i < 3; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Gridession.Items.Count; j++)
                    {


                        TextBlock b1 = new TextBlock();

                        b1 = Gridcinemfilm.Columns[i].GetCellContent(Gridcinemfilm.Items[q]) as TextBlock;




                        Microsoft.Office.Interop.Excel.Range myRange1 = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];

                        if (b1 != null)
                        {
                            myRange1.Value2 = b1.Text;
                        }
                    }

                }


            }



        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           k2 = (sender as DataGridRow).DataContext as View_1;

             q = Gridcinemfilm.SelectedIndex;


            k1 = new List<Session>();
            List<Session> k = KursovaiaEntities1.GetContext().Sessions.ToList();
            foreach (Session s in k)
            {
                if (s.ID_cinema == k2.ID_cinema && s.ID_film == k2.ID_film)
                {
                    k1.Add(s);
                }
            }

           Gridession.ItemsSource = k1;
        }

        private void Bted_Click(object sender, RoutedEventArgs e)
        {
                       List<View_1> cinem = Gridcinemfilm.SelectedItems.Cast<View_1>().ToList();
            flag2 = true;
           Addsession k = new Addsession((sender as System.Windows.Controls.Button).DataContext as Session, cinem);
            this.Close();
            k.Show();
        }
    }
    
}
