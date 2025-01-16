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
    /// Interaction logic for ModifyHours.xaml
    /// </summary>
    public partial class ModifyHours : Window
    {
        public ModifyHours()
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

        // Afișează datele filmului selectat
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

        // Adaugă un interval
        private void AddInterval_Click(object sender, RoutedEventArgs e)
        {
            string selectedMovie = moviesListBox.SelectedItem.ToString();
            if (selectedMovie == null)
            {
                MessageBox.Show("Selectați un film înainte de a adăuga un interval.");
                return;
            }

            try
            {
                int year = int.Parse(yearTextBox.Text);
                int month = int.Parse(monthTextBox.Text);
                int day = int.Parse(dayTextBox.Text);
                int hour = int.Parse(hourTextBox.Text);
                int minute = int.Parse(minuteTextBox.Text);

                DataManager dataManager = new DataManager();
                dataManager.GetMoviesFromTxt();
                List<Movie> movies = dataManager.GetMovies();
                foreach(Movie movie in movies)
                {
                    if (movie.GetName() == selectedMovie)
                    {
                        if (movie.GetDataDeAfisare().Contains(new DateTime(year, month, day, hour, minute, 0)))
                        {
                            MessageBox.Show("Intervalul există deja.");
                            return;
                        }
                        else
                        {
                            movie.MakeDate(year, month, day, hour, minute);
                            movie.AddTakenSeat(0); // Adaugă locuri disponibile
                            movie.AddSala(int.Parse(idSala.Text)); // Adaugă sala
                            dataManager.SaveMovieToTxt(movies);
                            MessageBox.Show("Interval adăugat cu succes!");
                            MoviesListBox_SelectionChanged(null, null); // Actualizează lista
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        // Șterge un interval
        private void DeleteInterval_Click(object sender, RoutedEventArgs e)
        {
            string selectedMovie = moviesListBox.SelectedItem.ToString();
            if (selectedMovie == null || datesListBox.SelectedItem == null)
            {
                MessageBox.Show("Selectați un film și un interval înainte de a șterge.");
                return;
            }

            try
            {
                DataManager dataManager = new DataManager();
                dataManager.GetMoviesFromTxt();
                List<Movie> movies = dataManager.GetMovies();
                string selectedDateStr = datesListBox.SelectedItem.ToString();
                DateTime selectedDate = DateTime.Parse(selectedDateStr);
                foreach(Movie movie in movies)
                {
                    if (movie.GetName() == selectedMovie)
                    {
                        var dates = movie.GetDataDeAfisare();
                        var seats = movie.GetTakenSeats();
                        var sali = movie.GetSala();
                        for (int i = 0; i < dates.Count; i++)
                        {
                            if (dates[i] == selectedDate)
                            {
                                dates.RemoveAt(i);
                                seats.RemoveAt(i);
                                sali.RemoveAt(i);
                                dataManager.SaveMovieToTxt(movies);
                                MessageBox.Show("Interval șters cu succes!");
                                MoviesListBox_SelectionChanged(null, null); // Actualizează lista
                                return;
                            }
                        }
                        MessageBox.Show("Intervalul nu a fost găsit.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void Back(object sender, EventArgs e)
        {
            AdminPage adminWindow = new AdminPage();
            adminWindow.Show();
            this.Close();
        }
    }
}
