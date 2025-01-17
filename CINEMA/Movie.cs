﻿namespace Proiect_Cinema;

public class Movie
{
    private string _name; 
    private int _duration; //minute
    private string _movieDescription;
    private List<DateTime> _dataDeAfisare=new List<DateTime>();
    private List<int> _takenSeats=new List<int>();
    private List<int> _sala= new List<int>();

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

    public void AddTakenSeat(int seat)
    {
        _takenSeats.Add(seat);
    }

    public void AddSala(int idSala)
    {
        _sala.Add(idSala);
    }

    public void AfisareMovie()
    {
        Console.WriteLine($"Titlu: {_name}");
        Console.WriteLine($"Durata: {_duration} minute");
        Console.WriteLine($"Despre film:\n{_movieDescription}");

        int i = 0;
        for (i=0; i<_takenSeats.Count; i++)
        {
            Console.WriteLine($"Data: {_dataDeAfisare[i].ToShortDateString()} de la ora: {_dataDeAfisare[i].ToShortTimeString()}");
            Console.WriteLine($"Locuri ocupate: {_takenSeats[i]}");
        }
        Console.WriteLine();
    }

    public void AfisareDate()
    {
        int i = 0;
        foreach (DateTime date in _dataDeAfisare)
        {
            Console.WriteLine($"{i}) Data: {_dataDeAfisare[i].ToShortDateString()} de la ora: {_dataDeAfisare[i].ToShortTimeString()}");
            i++;
        }
    }

    public void IncrementTakenSeat(int i,int rezervedSeats)
    {
        _takenSeats[i]+=rezervedSeats;
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

    public List<int> GetTakenSeats()
    {
        return _takenSeats;
    }

    public List<int> GetSala()
    {
        return _sala;
    }
}