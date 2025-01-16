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
using Proiect_Cinema;

namespace CinemaUI
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddMovie(object sender, RoutedEventArgs e)
        {
            AddMov addMovie = new AddMov();
            addMovie.Show();
            this.Close();
        }

        private void RemoveMovie(object sender, RoutedEventArgs e)
        {
            RemoveMov removeMovie = new RemoveMov();
            removeMovie.Show();
            this.Close();
        }

        private void ModifyHoursForMovies(object sender, RoutedEventArgs e)
        {
            ModifyHours modifyHoursForMovie = new ModifyHours();
            modifyHoursForMovie.Show();
            this.Close();
        }

        private void ChangeTheater(object sender, RoutedEventArgs e)
        {
            ChangeTheat changeTheater = new ChangeTheat();
            changeTheater.Show();
            this.Close();
        }

        private void SeatsOcup(object sender, RoutedEventArgs e)
        {
            OcupiedSts seatsOcupied = new OcupiedSts();
            seatsOcupied.Show();
            this.Close();
        }
    }
}
