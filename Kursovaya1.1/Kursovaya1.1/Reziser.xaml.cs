using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kursovaya1._1
{
    /// <summary>
    /// Логика взаимодействия для Reziser.xaml
    /// </summary>
    public partial class Reziser : System.Windows.Window
    {
        public View_1 k2;
        public List<Director> k1;
        public static bool flag2;
        public int q = -1;
        public Reziser()
        {
            InitializeComponent();
            Gridcinemfilm.ItemsSource = KursovaiaEntities1.GetContext().View_1.ToList();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            k2 = (sender as DataGridRow).DataContext as View_1;
            q = Gridcinemfilm.SelectedIndex;
            k1 = new List<Director>();
            List<Director> k = KursovaiaEntities1.GetContext().Directors.ToList();
            foreach (Director s in k)
            {
                if (s.ID_film == k2.ID_film)
                {
                    k1.Add(s);
                }
            }
       Griderector.ItemsSource = k1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag2 = false;
            List<View_1> cinem = KursovaiaEntities1.GetContext().View_1.ToList();

            List<View_1> cinem1 = Gridcinemfilm.SelectedItems.Cast<View_1>().ToList();


            if (cinem1.Count == 0) { MessageBox.Show("Выберите фильм, в который нужно добавить актера "); }
            else
            {
                View_1 k2 = cinem[Gridcinemfilm.SelectedIndex];

                Adddirector k = new Adddirector(null, cinem, k2);
                this.Close();
                k.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cinem = Griderector.SelectedItems.Cast<Director>().ToList();

            if (cinem.Count == 0) { MessageBox.Show("Вы не выбрали элемент для удаления"); }
            else
            {

                if (MessageBox.Show($"Вы точно хотите удалить следущие {cinem.Count() } элементов", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        KursovaiaEntities1.GetContext().Directors.RemoveRange(cinem);

                        KursovaiaEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены11");

                        //GridFilm.ItemsSource = KursovaiaEntities.GetContext().Film.ToList();
                        k1 = new List<Director>();
                        List<Director> k = KursovaiaEntities1.GetContext().Directors.ToList();
                        foreach (Director s in k)
                        {
                            if (s.ID_film == k2.ID_film)
                            {
                                k1.Add(s);
                            }
                        }
                        Griderector.ItemsSource = k1;
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
            View_1 z = new View_1();
            List<View_1> cinem = Gridcinemfilm.SelectedItems.Cast<View_1>().ToList();
            flag2 = true;
            Adddirector k = new Adddirector((sender as System.Windows.Controls.Button).DataContext as Director, cinem, z);
            this.Close();
            k.Show();
        }

        private void DataGridRow_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var z = (sender as DataGridRow).DataContext as Director;

           imagedirect.Source = LoadImage(z.Imagedirector);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
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

                for (int j = 0; j < Griderector.Columns.Count; j++) //Başlıklar için
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 4];
                    sheet1.Cells[1, j + 4].Font.Bold = true; //Başlığın Kalın olması için
                    sheet1.Columns[j + 4].ColumnWidth = 15; //Sütun genişliği ayarı
                    myRange.Value2 = Griderector.Columns[j].Header;
                }




                for (int i = 0; i < Griderector.Columns.Count; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Griderector.Items.Count; j++)
                    {



                        TextBlock b = Griderector.Columns[i].GetCellContent(Griderector.Items[j]) as TextBlock;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 4];

                        if (b != null)
                        {
                            myRange.Value2 = b.Text;
                        }


                    }
                }

                for (int i = 0; i < 3; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < Griderector.Items.Count; j++)
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
    }
}
