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
        private List<Sala> sali = new List<Sala>();
        private int selectedShowtimeIndex;

        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            dataManager.GetMoviesFromTxt();
            dataManager.GetSalaFromTxt();
            sali = dataManager.GetSali();
            movies = dataManager.GetMovies().Where(m => m.GetDataDeAfisare().Any(d => d > DateTime.Now)).ToList();
            moviesListBox.ItemsSource = movies.Select(m => m.GetName()).ToList();
        }

        private void MoviesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (moviesListBox.SelectedItem != null)
            {
                string selectedMovieName = moviesListBox.SelectedItem.ToString();
                Movie selectedMovie = movies.FirstOrDefault(m => m.GetName() == selectedMovieName);

                if (selectedMovie != null)
                {
                    // Afișăm detalii despre film
                    MovieNameText.Text = selectedMovie.GetName();
                    MovieDescriptionText.Text = selectedMovie.GetMovieDescription();
                    MovieDurationText.Text = $"Durata: {selectedMovie.GetDuration()} minute";

                    // Populăm ComboBox cu orele disponibile
                    ShowtimeComboBox.Items.Clear();
                    for (int i = 0; i < selectedMovie.GetDataDeAfisare().Count; i++)
                    {
                        ShowtimeComboBox.Items.Add($"{selectedMovie.GetDataDeAfisare()[i]:HH:mm} ({sali[i].GetNumberOfSeats() - selectedMovie.GetTakenSeats()[i]} locuri disponibile)");
                    }
                }
            }
        }

        private void ShowtimeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedShowtimeIndex = ShowtimeComboBox.SelectedIndex;
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

        private void Rezervare(object sender, RoutedEventArgs e)
        {
            string selectedMovieName = moviesListBox.SelectedItem.ToString();
            Movie selectedMovie = movies.FirstOrDefault(m => m.GetName() == selectedMovieName);

            if (selectedMovie == null)
            {
                MessageBox.Show("Selectați un film înainte de a face rezervarea.");
                return;
            }

            
            if (selectedShowtimeIndex == -1)
            {
                MessageBox.Show("Selectați o oră de rulare.");
                return;
            }

            if (!int.TryParse(NumPeopleTextBox.Text, out int numOfSeats) || numOfSeats < 1 || numOfSeats > 5)
            {
                MessageBox.Show("Introduceți un număr valid de persoane (între 1 și 5).");
                return;
            }

            if (sali[selectedShowtimeIndex].GetNumberOfSeats() - selectedMovie.GetTakenSeats()[selectedShowtimeIndex] < numOfSeats)
            {
                MessageBox.Show("Nu sunt suficiente locuri disponibile.");
                return;
            }

            selectedMovie.IncrementTakenSeat(selectedShowtimeIndex, numOfSeats);
            dataManager.SaveMovieToTxt(movies);
            MessageBox.Show($"Rezervarea pentru filmul '{selectedMovie.GetName()}' la ora {selectedMovie.GetDataDeAfisare()[selectedShowtimeIndex]:HH:mm} a fost făcută cu succes!");
            NumPeopleTextBox.Clear();  
            ShowtimeComboBox.SelectedIndex = -1;
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