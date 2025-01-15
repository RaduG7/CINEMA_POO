namespace Proiect_Cinema;

public class Utilizator
{
    public void ViewMovieList(DataManager dataManager)
    {
        dataManager.AfisareFilmeUtilizator();
    }

    public void SearchMovieByDate(DataManager dataManager)
    {
        dataManager.CautareFilmeDupaData();
    }
    public void SearchMovieByTitle(DataManager dataManager)
    {
        dataManager.CautareFilmDupaTitlu();
    }

    public void SeatReservation(DataManager dataManager)
    {
        dataManager.RezervareFilm();
    }
}