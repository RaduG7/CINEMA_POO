namespace Proiect_Cinema;

public class Sala
{
    private int _idSala;
    private int _numberOfSeats; 
    private List<Movie> _movies=new List<Movie>();

    public Sala(int numberOfSeats,int idSala)
    {
        _numberOfSeats = numberOfSeats;
        _idSala = idSala;
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }

    public void AfisareSala()
    {
        Console.WriteLine($"Sala cu numarul {_idSala}");
        Console.WriteLine($"Locuri totale in sala:{_numberOfSeats}");
        Console.WriteLine("Filmele care se afiseaza in sala:");
        foreach (Movie movie in _movies)
        {
            Console.WriteLine(movie.GetName());
        }
        Console.WriteLine();
    }

    /*public int GetAvailableSeats(Movie movie)
    {
        int takenSeats = movie.GetTakenSeats().Sum(); 
        int availableSeats = _numberOfSeats - takenSeats; 
        return availableSeats;
    }*/
    public int GetNumberOfSeats()
    {
        return _numberOfSeats;
    }
    
    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public int GetIdSala()
    {
        return _idSala;
    }
}