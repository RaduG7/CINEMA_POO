namespace Proiect_Cinema;

public interface IAdmin
{
    public void AddNewMovie(int movie_id,string name, string description, int duration); 
    public void DeleteMovie(string name);/*sa scoata complet un film de la rulare*/
    public void ChangeMovieTheater(string rooms)/*sa modifice numarul maxim de locuri pentru o rulare (sa schimbe sala)*/;

    public void OcupiedSeats(); 
}