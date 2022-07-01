using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace Kursovaya1._1
{
    /// <summary>
    /// Логика взаимодействия для Userwindow.xaml
    /// </summary>
    public partial class Userwindow : Window
    {
        DispatcherTimer timer;
        List<Cinema> k;
        public int r = 0;
        double panelwidth;
        bool hidden;
        List<Film> t = new List<Film>();
        List<Session> t3 = new List<Session>();
        List<Actor> t1= new List<Actor>();
        List<string> city = new List<string> { "Perm", "Moscow", "Saransk", "Rostov", "Sochi", "Ekaterinburg" };
        public static bool flag1 = false;
        public static bool flag2 = false;
        public static bool flag3 = false;
        public static bool flag4 = false;
        Film m1 = new Film();
        Session m2 = new Session();
        Cinema m3 = new Cinema();
        public Userwindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelwidth = sidePanel.Width;
            UpdateCinema();
            LVFilm.Visibility = Visibility.Collapsed;
            Lvactor.Visibility = Visibility.Collapsed;
            Lvdirector.Visibility = Visibility.Collapsed;
            LVsession.Visibility = Visibility.Collapsed;
            Lvposter.Visibility = Visibility.Collapsed;
            LVlounge.Visibility = Visibility.Collapsed;
            LVFilmsses.Visibility = Visibility.Collapsed;
          


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 1;
                if (sidePanel.Width >= panelwidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 30)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void UpdateCinema()
        {
            Calend.Visibility = Visibility.Collapsed;
            r = 1;
            Header.Text = "Кинотеатры";
            Poisk.Text = "Введите название кинотеатра для поиска: ";
            Poisk.Visibility = Visibility.Visible;
            Txserarch.Visibility = Visibility.Visible;
            k = KursovaiaEntities1.GetContext().Cinemas.ToList();
            var currentcinema = k;

    


            currentcinema = currentcinema.Where(p => p.Name_cinema.ToLower().Contains(Txserarch.Text.ToLower())).ToList();

            LVcinema.ItemsSource = currentcinema.OrderBy(p => p.Name_cinema).ToList();

        }

        private void UpdateFilm(List<Film> t)
        {
            Calend.Visibility = Visibility.Collapsed;
            r = 2;
            Header.Text = "Фильмы";
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

           

          LVFilm.ItemsSource = currentcinema.OrderBy(p => p.Film_name).ToList();
        }


        private void UpdateFilmes()
        {
            Calend.Visibility = Visibility.Collapsed;
            Header.Text = "Фильмы";
            Poisk.Text = "Введите название фильма для поиска: ";
            Poisk.Visibility = Visibility.Visible;
            Txserarch.Visibility = Visibility.Visible;
            var currentcinema = KursovaiaEntities1.GetContext().Films.ToList();

            currentcinema = currentcinema.Where(p => p.Film_name.ToLower().Contains(Txserarch.Text.ToLower())).ToList();

           LVFilmsses.ItemsSource = currentcinema.OrderBy(p => p.Film_name).ToList();
        }

        private void UpdateActor(List<Actor> t)
        {
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

            currentcinema = currentcinema.Where(p => p.FIO.ToLower().Contains(Txserarch.Text.ToLower())).ToList();

            Lvactor.ItemsSource = currentcinema.OrderBy(p => p.FIO).ToList();
        }
        private void UpdateDirector(List<Director> t)
        {
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

            currentcinema = currentcinema.Where(p => p.FIO.ToLower().Contains(Txserarch.Text.ToLower())).ToList();

          Lvdirector.ItemsSource = currentcinema.OrderBy(p => p.FIO).ToList();
        }

        private void UpdateSession(List<Session> t)
        {
            Calend.Visibility = Visibility.Visible;
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

            

            LVsession.ItemsSource = currentcinema.OrderBy(p => p.Data_session).ToList();
        }

        private void UpdatePoster(List<Poster> t)
        {
           
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

            currentcinema = currentcinema.Where(p => p.Author.ToLower().Contains(Txserarch.Text.ToLower())).ToList();

            Lvposter.ItemsSource = currentcinema.OrderBy(p => p.Author).ToList();
        }


        private void UpdateLounge(List<Lounge> t)
        {
            Calend.Visibility = Visibility.Collapsed;
            Poisk.Visibility = Visibility.Collapsed;
            Txserarch.Visibility = Visibility.Collapsed;
            var currentcinema = t;

            currentcinema = currentcinema.Where(p => p.Row.ToString().ToLower().Contains(Txserarch.Text.ToLower())).ToList();

            LVlounge.ItemsSource = currentcinema.OrderBy(p => p.Row).ToList();
        }


        private void Txserarch_TextChanged(object sender, TextChangedEventArgs e)
        {
          
                UpdateCinema();
            
            UpdateFilmes();
            
     
        }

        private void LVcinema_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

           
            m3 = (Cinema)LVcinema.SelectedItem;
          

            LVcinema.Visibility = Visibility.Collapsed;

            LVFilm.Visibility = Visibility.Visible;
            List<Film> h = KursovaiaEntities1.GetContext().Films.ToList();

            List<Film> t = new List<Film>();
            foreach(Film r in h)
            {
                if(r.ID_cinema == m3.ID_cinema)
                {
                    t.Add(r);
                }
            }
            
            UpdateFilm(t);

            Header.Text = "Фильмы из кинотеатра " + m3.Name_cinema;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void panelheader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LVFilm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            m1 = (Film)LVFilm.SelectedItem;

            MessageBoxResult result4 = MessageBox.Show("Вы хотите посмотреть сенансы для данного фильма?", "My App", MessageBoxButton.YesNo);
            switch (result4)
            {
                case MessageBoxResult.Yes:
                    LVFilm.Visibility = Visibility.Collapsed;
                    LVsession.Visibility = Visibility.Visible;
                    List<Session> h3 = KursovaiaEntities1.GetContext().Sessions.ToList();
                    Header.Text = "Сеансы для фильма "+m1.Film_name;
                    List<Session> t3 = new List<Session>();
                    foreach (Session r in h3)
                    {
                        if (r.ID_film == m1.ID_film)
                        {
                            t3.Add(r);
                        }
                    }
                    UpdateSession(t3);
                    break;

                case MessageBoxResult.No:
                    MessageBoxResult result = MessageBox.Show("Вы хотите посмотреть актеров данного фильма?", "My App", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            LVFilm.Visibility = Visibility.Collapsed;
                            Lvactor.Visibility = Visibility.Visible;
                            List<Actor> h = KursovaiaEntities1.GetContext().Actors.ToList();
                            Header.Text = "Актеры из фильма " + m1.Film_name;
                            List<Actor> t = new List<Actor>();
                            foreach (Actor r in h)
                            {
                                if (r.ID_film == m1.ID_film)
                                {
                                    t.Add(r);
                                }
                            }
                            UpdateActor(t);

                            break;

                        case MessageBoxResult.No:
                            MessageBoxResult result1 = MessageBox.Show("Вы хотите посмотреть ржиссерский состав?", "My App", MessageBoxButton.YesNo);
                            switch (result1)
                            {
                                case MessageBoxResult.Yes:
                                    LVFilm.Visibility = Visibility.Collapsed;
                                    Lvdirector.Visibility = Visibility.Visible;

                                    List<Director> h1 = KursovaiaEntities1.GetContext().Directors.ToList();
                                    Header.Text = "Режиссеры/операторы из фильма " + m1.Film_name;
                                    List<Director> t1 = new List<Director>();
                                    foreach (Director r in h1)
                                    {
                                        if (r.ID_film == m1.ID_film)
                                        {
                                            t1.Add(r);
                                        }
                                    }
                                    UpdateDirector(t1);
                                    break;

                                case MessageBoxResult.No:
                                    MessageBoxResult result2 = MessageBox.Show("Вы хотите посмотреть постер к фильму?", "My App", MessageBoxButton.YesNo);
                                    switch (result2)
                                    {
                                        case MessageBoxResult.Yes:
                                            LVFilm.Visibility = Visibility.Collapsed;
                                            Lvposter.Visibility = Visibility.Visible;
                                            Header.Text = "Постер к фильму " + m1.Film_name;
                                            List<Poster> h5 = KursovaiaEntities1.GetContext().Posters.ToList();

                                            List<Poster> t5 = new List<Poster>();
                                            foreach (Poster r in h5)
                                            {
                                                if (r.ID_film == m1.ID_film)
                                                {
                                                    t5.Add(r);
                                                }
                                            }
                                            UpdatePoster(t5);
                                            break;

                                        case MessageBoxResult.No:

                                            break;
                                    }
                                    break;


                            }
                            break;

                    }
                    break;
            }


            
        }

        private void Lvactor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Lvdirector_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LVFilm.Visibility = Visibility.Collapsed;
            Lvactor.Visibility = Visibility.Collapsed;
            Lvdirector.Visibility = Visibility.Collapsed;
            LVsession.Visibility = Visibility.Collapsed;
            Lvposter.Visibility = Visibility.Collapsed;
            LVlounge.Visibility = Visibility.Collapsed;
            LVFilmsses.Visibility = Visibility.Collapsed;
            LVcinema.Visibility = Visibility.Visible;
            
            UpdateCinema();
        }

        private void Lvposter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void LVsession_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            m2 = (Session)LVsession.SelectedItem;
            LVsession.Visibility = Visibility.Collapsed;
            LVlounge.Visibility = Visibility.Visible;
            List<Lounge> h = KursovaiaEntities1.GetContext().Lounges.ToList();
            Header.Text = "Метса на " + m2.Session_time + " в зал "+ m2.Lounge_number;
            List<Lounge> t = new List<Lounge>();
            foreach (Lounge r in h)
            {
                if (r.ID_session == m2.ID_session)
                {
                    t.Add(r);
                }
            }
            UpdateLounge(t);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LVFilm.Visibility = Visibility.Collapsed;
            Lvactor.Visibility = Visibility.Collapsed;
            Lvdirector.Visibility = Visibility.Collapsed;
            LVsession.Visibility = Visibility.Collapsed;
            Lvposter.Visibility = Visibility.Collapsed;
            LVcinema.Visibility = Visibility.Collapsed;
            LVlounge.Visibility = Visibility.Collapsed;
            LVFilmsses.Visibility = Visibility.Visible;
         
            UpdateFilmes();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Mainmenu k = new Mainmenu();
            k.Show();
            this.Close();
          
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calend_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string r = Calend.SelectedDate.ToString();
            string result = new string(r.Take(10).ToArray());

            List<Session> y = LVsession.ItemsSource.Cast<Session>().ToList();
            List<Session> l = new List<Session>();
            foreach(Session q in y)
            {
                if(q.Data_session == result)
                {
                    l.Add(q);
                }
            }
            UpdateSession(l);
        }
    }
}
