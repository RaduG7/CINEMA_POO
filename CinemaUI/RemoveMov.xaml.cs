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
    /// Interaction logic for RemoveMov.xaml
    /// </summary>
    public partial class RemoveMov : Window
    {
        public RemoveMov()
        {
            InitializeComponent();

            DataManager dataManager = new DataManager();

            PopulateMoviesList();
        }

        private void PopulateMoviesList()
        {
            moviesListBox.Items.Clear();
            DataManager dataManager = new DataManager();
            dataManager.GetMoviesFromTxt();
            List<Movie> movies = dataManager.GetMovies();
            foreach (Movie movie in movies)
            {
                moviesListBox.Items.Add(movie.GetName());
            }
        }

        private void DeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            DataManager dataManager = new DataManager();
            dataManager.GetMoviesFromTxt();
            dataManager.GetSalaFromTxt();
            List<Sala> sali = dataManager.GetSali();
            List<Movie> movies = dataManager.GetMovies();
            if (moviesListBox.SelectedItem != null)
            {
                string selectedMovie = moviesListBox.SelectedItem.ToString();

                var result = MessageBox.Show($"Sigur doriți să ștergeți filmul '{selectedMovie}'?", "Confirmare", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dataManager.StergereMovie(selectedMovie, sali);
                    dataManager.SaveMovieToTxt(movies);
                    dataManager.SaveSalaToTxt(sali);
                    PopulateMoviesList();

                    MessageBox.Show($"Filmul '{selectedMovie}' a fost șters!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați un film înainte de a șterge!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            AdminPage adminWindow = new AdminPage();
            adminWindow.Show();
            this.Close();
        }
    }
}

