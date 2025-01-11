namespace Proiect_Cinema;

public class Sala
{
    private int _idSala;
    private int _numberOfSeats;
    private int _taken_seats;
    private bool _available;
    private List<Movie> _movies=new List<Movie>();

    public Sala(int numberOfSeats, int takenSeats, bool available,int idSala)
    {
        _numberOfSeats = numberOfSeats;
        _taken_seats = takenSeats;
        _available = available;
        _idSala = idSala;
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }

    public void AfisareSala()
    {
        Console.WriteLine($"Sala cu numarul{_idSala}");
        Console.WriteLine($"Locuri totale in sala:{_numberOfSeats}");
        Console.WriteLine($"Locuri ocupate:{_taken_seats}");
        Console.WriteLine($"Disponibilitate: {_available}");
        Console.WriteLine("Filmele care se afiseaza in sala:");
        foreach (Movie movie in _movies)
        {
            Console.WriteLine(movie.GetName());
        }
        Console.WriteLine();
    }

    public int GetNumberOfSeats()
    {
        return _numberOfSeats;
    }

    public int GetTakenSeats()
    {
        return _taken_seats;
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