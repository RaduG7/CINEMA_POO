using Proiect_Cinema;
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

namespace CinemaUI
{
    /// <summary>
    /// Interaction logic for OcupiedSts.xaml
    /// </summary>
    public partial class OcupiedSts : Window
    {
        private DataManager dataManager = new DataManager();
        private List<Movie> movies = new List<Movie>();
        private List<Sala> sali = new List<Sala>();

        public OcupiedSts()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            dataManager.GetMoviesFromTxt();
            movies = dataManager.GetMovies();
            dataManager.GetSalaFromTxt();
            sali = dataManager.GetSali();
            moviesComboBox.ItemsSource = movies.Select(m => m.GetName()).ToList();
        }

        private void MoviesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datesListBox.Items.Clear();

            if (moviesComboBox.SelectedItem == null) return;

            string selectedMovie = moviesComboBox.SelectedItem.ToString();
            Movie movie = movies.FirstOrDefault(m => m.GetName() == selectedMovie);

            if (movie != null)
            {
                datesListBox.ItemsSource = movie.GetDataDeAfisare().Select(d => d.ToString("dd/MM/yyyy HH:mm")).ToList();
            }
        }

        private void DatesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (datesListBox.SelectedItem == null) return;

            string selectedMovie = moviesComboBox.SelectedItem.ToString();
            string selectedDateStr = datesListBox.SelectedItem.ToString();
            DateTime selectedDate = DateTime.ParseExact(selectedDateStr, "dd/MM/yyyy HH:mm", null);

            Movie movie = movies.FirstOrDefault(m => m.GetName() == selectedMovie);
            if (movie == null) return;

            var dates = movie.GetDataDeAfisare();
            var seats = movie.GetTakenSeats();

            int index = dates.IndexOf(selectedDate);
            if (index == -1) return;

            int totalSeats = sali[index+1].GetNumberOfSeats();
            int occupiedSeats = seats[index];
            int availableSeats = totalSeats - occupiedSeats;

            seatsListBox.Items.Add($"Locuri disponibile: {availableSeats}/{totalSeats}");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Close();
        }
    }
}
