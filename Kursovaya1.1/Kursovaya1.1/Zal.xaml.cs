using System;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
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
    /// Логика взаимодействия для Zal.xaml
    /// </summary>
    public partial class Zal : System.Windows.Window
    {
        public View_2 k2;
       public int q = -1;
        public List<Lounge> k1;
        public static bool flag2;
        public Zal()
        {
            InitializeComponent();
            Gridcinemfilmseans.ItemsSource = KursovaiaEntities1.GetContext().View_2.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag2 = false;
            List<View_2> cinem = Gridcinemfilmseans.SelectedItems.Cast<View_2>().ToList();
            if (cinem.Count == 0) { MessageBox.Show("Выберите фильм, в который нужно добавить сенас"); }
            else
            {

                Addzal k = new Addzal(null, cinem);
                this.Close();
                k.Show();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cinem = Gridzal.SelectedItems.Cast<Lounge>().ToList();

            if (cinem.Count == 0) { MessageBox.Show("Вы не выбрали элемент для удаления"); }
            else
            {

                if (MessageBox.Show($"Вы точно хотите удалить следущие {cinem.Count() } элементов", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        KursovaiaEntities1.GetContext().Lounges.RemoveRange(cinem);

                        KursovaiaEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены11");

                        //GridFilm.ItemsSource = KursovaiaEntities.GetContext().Film.ToList();
                        k1 = new List<Lounge>();
                        List<Lounge> k = KursovaiaEntities1.GetContext().Lounges.ToList();
                        foreach (Lounge s in k)
                        {
                            if (s.ID_session == k2.ID_session)
                            {
                                k1.Add(s);
                            }
                        }
                        Gridzal.ItemsSource = k1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void Bted_Click(object sender, RoutedEventArgs e)
        {
            List<View_2> cinem = Gridcinemfilmseans.SelectedItems.Cast<View_2>().ToList();
            flag2 = true;
           Addzal k =  new Addzal((sender as System.Windows.Controls.Button).DataContext as Lounge, cinem);
            this.Close();
            k.Show();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            k2 = (sender as DataGridRow).DataContext as View_2;
            q = Gridcinemfilmseans.SelectedIndex;
            k1 = new List<Lounge>();
            List<Lounge> k = KursovaiaEntities1.GetContext().Lounges.ToList();
            foreach (Lounge s in k)
            {
                if (s.ID_session == k2.ID_session)
                {
                    k1.Add(s);
                }
            }

           Gridzal.ItemsSource = k1;
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
                for (int y = 0; y < Gridcinemfilmseans.Columns.Count; y++)
                {
                    Range myRange = (Range)sheet1.Cells[1, y + 1];
                    sheet1.Cells[1, y + 1].Font.Bold = true; //Başlığın Kalın olması için
                    sheet1.Columns[y + 1].ColumnWidth = 15;
                    myRange.Value2 = Gridcinemfilmseans.Columns[y].Header;
                }

                for (int j = 0; j < Gridzal.Columns.Count; j++) //Başlıklar için
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 6];
                    sheet1.Cells[1, j + 6].Font.Bold = true; //Başlığın Kalın olması için
                    sheet1.Columns[j + 6].ColumnWidth = 15; //Sütun genişliği ayarı
                    myRange.Value2 = Gridzal.Columns[j].Header;
                }




                for (int i = 0; i < Gridzal.Columns.Count; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Gridzal.Items.Count; j++)
                    {



                        TextBlock b = Gridzal.Columns[i].GetCellContent(Gridzal.Items[j]) as TextBlock;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 6];

                        if (b != null)
                        {
                            myRange.Value2 = b.Text;
                        }


                    }
                }

                for (int i = 0; i < 5; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Gridzal.Items.Count; j++)
                    {


                        TextBlock b1 = new TextBlock();

                        b1 = Gridcinemfilmseans.Columns[i].GetCellContent(Gridcinemfilmseans.Items[q]) as TextBlock;




                        Microsoft.Office.Interop.Excel.Range myRange1 = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];

                        if (b1 != null)
                        {
                            myRange1.Value2 = b1.Text;
                        }
                    }

                }


            }
        }
    }
}
