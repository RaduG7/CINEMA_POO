using Proiect_Cinema;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataManager dataManager = new DataManager();
        private List<Movie> movies = new List<Movie>();

        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            dataManager.GetMoviesFromTxt();
            movies = dataManager.GetMovies().Where(m => m.GetDataDeAfisare().Any(d => d > DateTime.Now)).ToList();
            moviesListBox.ItemsSource = movies.Select(m => m.GetName()).ToList();
        }

        private void MoviesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (moviesListBox.SelectedItem == null) return;

            string selectedMovieName = moviesListBox.SelectedItem.ToString();
            Movie selectedMovie = movies.FirstOrDefault(m => m.GetName() == selectedMovieName);

            if (selectedMovie != null)
            {
                var movieDetailsText = new StringBuilder();
                movieDetailsText.AppendLine($"Descriere: {selectedMovie.GetMovieDescription()}");
                movieDetailsText.AppendLine($"Durata: {selectedMovie.GetDuration()} minute");

                var dates = selectedMovie.GetDataDeAfisare();
                var salas = selectedMovie.GetSala();
                for (int i = 0; i < dates.Count; i++)
                {
                    movieDetailsText.AppendLine($"Rulaj {i + 1}: {dates[i].ToString("dd/MM/yyyy HH:mm")} - Sala {salas[i].ToString("")}");
                }

                movieDetails.Text = movieDetailsText.ToString();
            }
        }

        private void RezervareButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Locurile au fost rezervate!");
        }
        private void AdminLogger(object sender, RoutedEventArgs e)
        {
            AdminLoggerPage adminLoggerPage = new AdminLoggerPage();
            this.Close();
            adminLoggerPage.Show();
        }

        private void SearchBar_KeyUp(object sender, KeyEventArgs e)
        {
            string searchTerm = searchBar.Text.ToLower();

            var filteredMovies = movies.Where(m =>
                m.GetName().ToLower().Contains(searchTerm) ||
                m.GetDataDeAfisare().Any(d => d.ToString("dd/MM/yyyy").Contains(searchTerm))
            ).ToList();

            moviesListBox.ItemsSource = filteredMovies.Select(m => m.GetName()).ToList();
        }
    }
}