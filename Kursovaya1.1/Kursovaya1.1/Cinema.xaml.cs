using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;





namespace Kursovaya1._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        

      
        public MainWindow()
        {
            InitializeComponent();
           
            DgridCinema.ItemsSource = KursovaiaEntities1.GetContext().Cinemas.ToList();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var cinem = DgridCinema.SelectedItems.Cast<Cinema>().ToList();

            if (cinem.Count == 0) { MessageBox.Show("Вы не выбрали элемент для удаления"); }
            else
            {

                if (MessageBox.Show($"Вы точно хотите удалить следущие {cinem.Count() } элементов", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        KursovaiaEntities1.GetContext().Cinemas.RemoveRange(cinem);

                        KursovaiaEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");
                        DgridCinema.ItemsSource = KursovaiaEntities1.GetContext().Cinemas.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
         


        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Window1 k = new Window1((sender as System.Windows.Controls.Button).DataContext as Cinema);
            this.Close();
            k.Show();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                KursovaiaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p =>p.Reload());
                DgridCinema.ItemsSource = KursovaiaEntities1.GetContext().Cinemas.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 k = new Window1(null);
            this.Close();
            k.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app =
        new Microsoft.Office.Interop.Excel.Application();

            app.Visible = true;

            Workbook wb = app.Workbooks.Add();
            Worksheet ws = wb.Worksheets[1];

            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Kursovaia; Integrated Security =true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"Select*
From Cinema", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            ws.Cells[1, 1].Value = reader.GetName(0);
            ws.Cells[1, 2].Value = reader.GetName(1);
            ws.Cells[1, 3].Value = reader.GetName(2);
            ws.Cells[1, 4].Value = reader.GetName(3);
            ws.Cells[1, 5].Value = reader.GetName(4);
            ws.Cells[1, 6].Value = reader.GetName(5);
            ws.Cells[1, 7].Value = reader.GetName(6);
            ws.Cells[1, 8].Value = reader.GetName(7);

            int i = 2;
            while (reader.Read())
            {
                ws.Cells[i, 1].Value = reader[0];
                ws.Cells[i, 2].Value = reader[1];
                ws.Cells[i, 3].Value = reader[2];
                ws.Cells[i, 4].Value = reader[3];
                ws.Cells[i, 5].Value = reader[4];
                ws.Cells[i, 6].Value = reader[5];
                ws.Cells[i, 7].Value = reader[6];
                ws.Cells[i, 8].Value = reader[7];
                i++;
            }

            reader.Close();
            conn.Close();

        }
    }
}
