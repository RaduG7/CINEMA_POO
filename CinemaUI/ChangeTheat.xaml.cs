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
    /// Interaction logic for ChangeTheat.xaml
    /// </summary>
    public partial class ChangeTheat : Window
    {
        public ChangeTheat()
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

        private void MoviesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (moviesListBox.SelectedItem != null)
            {
                string selectedMovieName = moviesListBox.SelectedItem.ToString();

                datesListBox.Items.Clear();
                DataManager dataManager = new DataManager();
                dataManager.GetMoviesFromTxt();
                List<Movie> movies = dataManager.GetMovies();
                foreach (Movie movie in movies)
                {
                    if (movie.GetName() == selectedMovieName)
                    {
                        foreach (DateTime date in movie.GetDataDeAfisare())
                        {
                            datesListBox.Items.Add(date);
                        }
                        break;
                    }
                }
            }
        }

        private void ChangeSala(object sender, RoutedEventArgs e)
        {
            string selectedMovie = moviesListBox.SelectedItem.ToString();
            if (selectedMovie == null || datesListBox.SelectedItem == null)
            {
                MessageBox.Show("Selectați un film și un interval înainte de a modifica.");
                return;
            }

            try
            {
                DataManager dataManager = new DataManager();
                dataManager.GetMoviesFromTxt();
                List<Movie> movies = dataManager.GetMovies();
                string selectedDateStr = datesListBox.SelectedItem.ToString();
                DateTime selectedDate = DateTime.Parse(selectedDateStr);
                foreach (Movie movie in movies)
                {
                    if (movie.GetName() == selectedMovie)
                    {
                        var dates = movie.GetDataDeAfisare();
                        var sali = movie.GetSala();
                        for (int i = 0; i < dates.Count; i++)
                        {
                            if (dates[i] == selectedDate)
                            {
                                sali[i] = int.Parse(idSala.Text);
                                dataManager.SaveMovieToTxt(movies);
                                MessageBox.Show("Sala modificata cu succes!");
                                MoviesListBox_SelectionChanged(null, null); // Actualizează lista
                                return;
                            }
                        }
                        MessageBox.Show("Sala nu a fost găsit.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void Back1(object sender, RoutedEventArgs e)
        {
            AdminPage adminWindow = new AdminPage();
            adminWindow.Show();
            this.Close();
        }
    }
}
