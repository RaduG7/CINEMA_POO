namespace Proiect_Cinema;

public class Utilizator
{
    public void ViewMovieList(DataManager dataManager, List <Movie> movies)
    {
        dataManager.AfisareFilmeUtilizator(movies);
    }

    public void SearchMovieByDate(DataManager dataManager, List<Movie> movies)
    {
        dataManager.CautareFilmeDupaData(movies);
    }
    public void SearchMovieByTitle(DataManager dataManager, List<Movie> movies)
    {
        dataManager.CautareFilmDupaTitlu(movies);
    }

    public void SeatReservation(DataManager dataManager, List<Movie> movies)
    {
        dataManager.RezervareFilm(movies);
    }
}