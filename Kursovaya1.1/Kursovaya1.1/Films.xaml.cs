using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Films.xaml
    /// </summary>
    public partial class Films : System.Windows.Window
    {
        public int q = -1;
        public Cinema k2;
        public List<Film> k1;
        public static bool flag1;
        public Films()
        {
            InitializeComponent();
            

            GridFilm.Items.Clear();
           
            Gridcinname.ItemsSource = KursovaiaEntities1.GetContext().Cinemas.ToList();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add
            flag1 = false;
            List<Cinema> cinem = Gridcinname.SelectedItems.Cast<Cinema>().ToList();
            if (cinem.Count == 0) { MessageBox.Show("Выберите кинотеатр, в который нужно добавить фильм"); }
            else
            {
                Film k1 = new Film();
                Addfilm k = new Addfilm(null, cinem);
                this.Close();
                k.Show();

            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cinem = GridFilm.SelectedItems.Cast<Film>().ToList();

            if (cinem.Count == 0) { MessageBox.Show("Вы не выбрали элемент для удаления"); }
            else
            {

                if (MessageBox.Show($"Вы точно хотите удалить следущие {cinem.Count() } элементов", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        KursovaiaEntities1.GetContext().Films.RemoveRange(cinem);

                        KursovaiaEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены11");

                        //GridFilm.ItemsSource = KursovaiaEntities.GetContext().Film.ToList();
                        k1 = new List<Film>();
                        List<Film> k = KursovaiaEntities1.GetContext().Films.ToList();
                        foreach (Film s in k)
                        {
                            if (s.ID_cinema == k2.ID_cinema)
                            {
                                k1.Add(s);
                            }
                        }
                        GridFilm.ItemsSource = k1;
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
            List<Cinema> cinem = Gridcinname.SelectedItems.Cast<Cinema>().ToList();
            flag1 = true;
       Addfilm k = new Addfilm((sender as System.Windows.Controls.Button).DataContext as Film, cinem);
            this.Close();
            k.Show();
        }

        private void Gridcinname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            // DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            //if (row == null) return;
       
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             k2 = (sender as DataGridRow).DataContext as Cinema;

            q = Gridcinname.SelectedIndex;

        k1 = new List<Film>();
        List<Film> k = KursovaiaEntities1.GetContext().Films.ToList();
            foreach (Film s in k)
            {
                if (s.ID_cinema == k2.ID_cinema)
                {
                    k1.Add(s);
                }
            }

            GridFilm.ItemsSource = k1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (q == -1) { MessageBox.Show("Выберите элемент для экспорта"); }
            else { 
            Microsoft.Office.Interop.Excel.Application excel = new Excel.Application();
            excel.Visible = true; //www.yazilimkodlama.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            for (int y = 0; y < Gridcinname.Columns.Count; y++)
            {
                Range myRange = (Range)sheet1.Cells[1, y + 1];
                sheet1.Cells[1, y + 1].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[y + 1].ColumnWidth = 15;
                myRange.Value2 = Gridcinname.Columns[y].Header;
            }

            for (int j = 0; j < GridFilm.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 3];
                sheet1.Cells[1, j + 3].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[j + 3].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = GridFilm.Columns[j].Header;
            }




            for (int i = 0; i < GridFilm.Columns.Count; i++)
            { //www.yazilimkodlama.com
                for (int j = 0; j < GridFilm.Items.Count; j++)
                {



                    TextBlock b = GridFilm.Columns[i].GetCellContent(GridFilm.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 3];

                    if (b != null)
                    {
                        myRange.Value2 = b.Text;
                    }


                }
            }

                for (int i = 0; i < 2; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < GridFilm.Items.Count; j++)
                    {


                        TextBlock b1 = new TextBlock();

                        b1 = Gridcinname.Columns[i].GetCellContent(Gridcinname.Items[q]) as TextBlock;




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
