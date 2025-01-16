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
    /// Interaction logic for AddMov.xaml
    /// </summary>
    public partial class AddMov : Window
    {
        public AddMov()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            AdminPage adminWindow = new AdminPage();
            adminWindow.Show();
            this.Close();
        }

        private void AddNewMovie(object sender, RoutedEventArgs e)
        {
            DataManager dataManager = new DataManager();
            dataManager.GetMoviesFromTxt();
            dataManager.GetSalaFromTxt();
            List<Sala> sali = dataManager.GetSali();
            List<Movie> movies = dataManager.GetMovies();
            try
            {
                int id=int.Parse(room.Text);
                int durata = int.Parse(duration.Text);
                int an = int.Parse(year.Text);
                int luna = int.Parse(month.Text);
                int zi = int.Parse(day.Text);
                int ora = int.Parse(hour.Text);
                int minut = int.Parse(minute.Text);
                dataManager.AdaugareMovie(id, title.Text, durata, description.Text, an, luna, zi, ora, minut, sali);
                dataManager.SaveMovieToTxt(movies);
                dataManager.SaveSalaToTxt(sali);
                title.Text = "";
                duration.Text = "";
                description.Text = "";
                room.Text = "";
                year.Text = "";
                month.Text = "";
                day.Text = "";
                hour.Text = "";
                minute.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datele nu au fost introduse corect!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Filmul a fost adaugat cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
