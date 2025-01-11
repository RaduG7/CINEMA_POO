namespace Proiect_Cinema;

public interface IUtilizator
{
    public void ViewMovieList(string title);//trebuie lista de filme
    public void SearchMovieByDate(DateTime airdate);
    public void InspectMovie(string title, DateTime airdate, int theater, int duration, string details);//detaliile unui film
    public void SearchMovieByTitle(string title);
    public void SeatReservation(string title, int theater, int seatNumber);//rezervare intre 1-5 locuri a unui film    
}