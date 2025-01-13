namespace Proiect_Cinema;

public class Movie
{
    private string _name; 
    private int _duration; //minute
    private string _movieDescription;
    private List<DateTime> _dataDeAfisare=new List<DateTime>();

    public Movie( string name, int duration, string movieDescription )
    {
        _name = name;
        _duration = duration;
        _movieDescription = movieDescription;
    }

    public void MakeDate(int year, int month, int day,int hour, int minute)
    {
        DateTime date = new DateTime(year, month, day, hour, minute,0);
        _dataDeAfisare.Add(date);
    }

    public void AfisareMovie()
    {
        Console.WriteLine($"Titlu: {_name}");
        Console.WriteLine($"Durata: {_duration}");
        Console.WriteLine($"Despre film:\n{_movieDescription}");
        
        foreach (DateTime data in _dataDeAfisare)
        {
            Console.WriteLine($"Data: {data.ToShortDateString()} de la ora: {data.ToShortTimeString()}");
        }
        Console.WriteLine();
    }
    
    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetMovieDescription()
    {
        return _movieDescription;
    }

    public List<DateTime> GetDataDeAfisare()
    {
        return _dataDeAfisare;
    }
}