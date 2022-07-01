using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Kursovaya1._1
{
    /// <summary>
    /// Логика взаимодействия для Adddirector.xaml
    /// </summary>
    public partial class Adddirector : Window
    {
        public static string cs = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Kursovaia; Integrated Security =true;";
        public string fileName = null;

        public List<View_1> ci;
        public View_1 r1;
        private static Director cureses = new Director();
        public Adddirector(Director selecteession, List<View_1> y, View_1 r)
        {
            InitializeComponent();
            if (selecteession != null)
            {
                cureses = selecteession;
                Imagact.Source = LoadImage(cureses.Imagedirector);

            }
            else
            {
                cureses = new Director();
            }
            ci = y;
            r1 = r;

            DataContext = cureses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Reziser.flag2 == true)
            {
                //if (cureses.ID_film == 0) { KursovaiaEntities1.GetContext().Directors.Add(cureses); }

                try
                {
                    cureses.Imagedirector = getJPGFromImageControl(Imagact.Source as BitmapImage);
                    KursovaiaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Reziser k = new Reziser();
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
                if (Imagact.Source == null) { MessageBox.Show("Добавьте фото"); }
                else
                {
                    var sql = @"INSERT INTO Director (ID_film, FIO,Country,Birth_year,Gender,Filmdirected,Filmawards,Imagedirector) 
                SELECT @ID_film, @FIO, @Cou, @Bir,@Gen,@Pl,@awa, @Ima;";
                    using (var cn = new SqlConnection(cs))
                    {
                        cn.Open();



                        var cmd = new SqlCommand(sql, cn);

                        cmd.Parameters.AddWithValue("@ID_film", r1.ID_film);
                        cmd.Parameters.AddWithValue("@FIO", Fio.Text);
                        cmd.Parameters.AddWithValue("@Cou", Cou.Text);
                        cmd.Parameters.AddWithValue("@Bir", Convert.ToInt32(Bir.Text));
                        cmd.Parameters.AddWithValue("@Gen", Gen.Text);
                        cmd.Parameters.AddWithValue("@Pl", Convert.ToInt32(Play.Text));
                        cmd.Parameters.AddWithValue("@awa", Convert.ToInt32(awards.Text));
                        cmd.Parameters.AddWithValue("@Ima", getJPGFromImageControl(Imagact.Source as BitmapImage));

                        cmd.ExecuteNonQuery();
                    }

                    //cureses.Imagedirector = getJPGFromImageControl(Imagact.Source as BitmapImage);
                    //KursovaiaEntities1.GetContext().Directors.Add(cureses);


                    MessageBox.Show("Информация сохранена!hh");
                    Reziser k = new Reziser();

                    this.Close();
                    k.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Reziser k = new Reziser();
            k.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files (*.JPG;*.BMP)|*.JPG; *.BMP|All files(*.*)|*.*";
                ofd.Title = "Выберите актера ";

                if (ofd.ShowDialog() == true)
                {
                    fileName = ofd.FileName;
                    Imagact.Source = new BitmapImage(new Uri(fileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
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
    }
}
